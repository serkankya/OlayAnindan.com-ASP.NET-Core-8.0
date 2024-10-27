using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OA.EntityLayer.Requests.CommentRequests;
using OA.UserInterface.Models;
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
	}
}
