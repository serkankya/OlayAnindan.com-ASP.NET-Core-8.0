using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OA.EntityLayer.Requests.ArticleRequests;
using OA.EntityLayer.Requests.CommentRequests;
using OA.UserInterface.Models;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace OA.UserInterface.Areas.User.Controllers
{
    [Area("User")]
    public class NewsController : Controller
    {
        readonly IHttpClientFactory _httpClientFactory;
        readonly ApiSettings _apiSettings;

        public NewsController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSettings)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
        }

        public IActionResult Index()
        {
            if (Convert.ToInt32(TempData["CategoryId"]) > 0 && TempData["DateOpt"] != null)
            {
                ViewBag.SelectedCategoryId = TempData["CategoryId"];
                ViewBag.SelectedDateOpt = TempData["DateOpt"];
            }
            else
            {
                ViewBag.SelectedCategoryId = 0;
                ViewBag.SelectedDateOpt = true;
            }

            ViewBag.CategoryId = TempData["CategoryId"];
            ViewBag.DateOpt = TempData["DateOpt"];

            return View();
        }

        [HttpGet]
        public IActionResult FilterNews(int categoryId, bool dateOpt)
        {
            TempData["CategoryId"] = categoryId;
            TempData["DateOpt"] = dateOpt;

            return RedirectToAction("Index", "News", new { area = "User" });
        }

        [Route("/User/News/SingleNews/{articleId}")]
        public IActionResult SingleNews(int articleId)
        {
            ViewBag.SelectedArticledId = articleId;
            TempData["SelectedArticleId"] = articleId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LeaveComment(InsertCommentRequest insertCommentRequest)
        {
            var token = Request.Cookies["AuthToken"];

            if (string.IsNullOrEmpty(token) || !IsUserOnline(token))
            {
                TempData["MustBeLoggedInError"] = "Yorum yapmak için giriş yapmak zorundasınız.";
                return RedirectToAction("SingleNews", "News", new { area = "User", articleId = insertCommentRequest.ArticleId });
            }

            var tokenHandler = new JwtSecurityTokenHandler();

            if (token.StartsWith("Bearer ", StringComparison.InvariantCultureIgnoreCase))
            {
                token = token.Substring("Bearer ".Length);  
            }

            JwtSecurityToken jwtToken;
            try
            {
                jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

                if (jwtToken == null)
                {
                    TempData["Error"] = "Geçersiz token.";
                    return RedirectToAction("SingleNews", "News", new { area = "User", articleId = insertCommentRequest.ArticleId });
                }
            }
            catch (Exception)
            {
                TempData["Error"] = "Token çözümleme hatası.";
                return RedirectToAction("SingleNews", "News", new { area = "User", articleId = insertCommentRequest.ArticleId });
            }

            var userId = jwtToken?.Claims.FirstOrDefault(c => c.Type == "userId")?.Value;

            ViewBag.UserId = userId;

            var updatedRequest = new InsertCommentRequest
            (
                insertCommentRequest.ArticleId,
                Convert.ToInt32(userId),
                insertCommentRequest.CommentText
            );

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apiSettings.BaseHostUrl!);
            var jsonData = JsonConvert.SerializeObject(updatedRequest);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("Comment/Insert", stringContent);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("SingleNews", "News", new { area = "User", articleId = insertCommentRequest.ArticleId });
            }

            TempData["Error"] = "Yorum gönderilemedi. Lütfen tekrar deneyin.";
            return RedirectToAction("SingleNews", "News", new { area = "User", articleId = insertCommentRequest.ArticleId });
        }

        private bool IsUserOnline(string token)
        {
            try
            {
                if (string.IsNullOrEmpty(token) || token.Split('.').Length != 3)
                {
                    TempData["Error"] = "Geçersiz token formatı.";
                    return false;
                }

                var tokenHandler = new JwtSecurityTokenHandler();
                JwtSecurityToken jwtToken = tokenHandler.ReadJwtToken(token); 

                if (jwtToken == null)
                {
                    TempData["Error"] = "Geçersiz token.";
                    return false;
                }

                var expiryDate = jwtToken.ValidTo;
                return expiryDate > DateTime.UtcNow;
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Token doğrulama hatası: {ex.Message}";
                return false;
            }
        }




        public async Task<IActionResult> SearchArticles(string keyWord)
        {
            if (keyWord != null)
            {
                var client = _httpClientFactory.CreateClient();
                client.BaseAddress = new Uri(_apiSettings.BaseHostUrl!);

                var encodedKeyWord = Uri.EscapeDataString(keyWord); //safer.
                var response = await client.GetAsync($"Article/SearchArticles?keyWord={encodedKeyWord}");

                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<ResultArticleRequest>>(jsonData);

                    return View("SearchArticles", values);
                }
                else
                {
                    ModelState.AddModelError("SearchArticles", "Arama işlemi başarısız oldu.");
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("SearchArticles", "Lütfen bir anahtar kelime girin.");
                return View();
            }
        }
    }
}
