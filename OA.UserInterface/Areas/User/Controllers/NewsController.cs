using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OA.EntityLayer.Requests.ArticleRequests;
using OA.EntityLayer.Requests.CommentRequests;
using OA.UserInterface.Models;
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
			return View();
		}

        [HttpPost]
        public async Task<IActionResult> LeaveComment(InsertCommentRequest insertCommentRequest)
        {
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", ""); 

            if (string.IsNullOrEmpty(token) || !IsUserOnline(token))
            {
                TempData["MustBeLoggedInError"] = "Yorum yapmak için giriş yapmak zorundasınız.";
                return RedirectToAction("SingleNews", "News", new { area = "User", articleId = insertCommentRequest.ArticleId });
            }

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apiSettings.BaseHostUrl!);
            var jsonData = JsonConvert.SerializeObject(insertCommentRequest);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("Comment/Insert", stringContent);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("SingleNews", "News", new { area = "User", articleId = insertCommentRequest.ArticleId });
            }

            return View();
        }

        private bool IsUserOnline(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);
            var expiryDate = jwtToken.ValidTo;
            return expiryDate > DateTime.UtcNow;
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

                    return View("SearchArticles",values);
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
