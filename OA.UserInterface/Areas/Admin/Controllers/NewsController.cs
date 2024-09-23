using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OA.EntityLayer.Requests.ArticleRequests;
using System.Text;

namespace OA.UserInterface.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class NewsController : Controller
	{
		readonly IHttpClientFactory _httpClientFactory;

        public NewsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> LatestNews()
		{
			var client = _httpClientFactory.CreateClient();
			var response = await client.GetAsync("https://localhost:7090/api/Article/GetActives");

			if (response.IsSuccessStatusCode)
			{
				var jsonData = await response.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultArticleRequest>>(jsonData);

				return View(values);
			}

			return View();
		}

		[HttpGet]
		public IActionResult ShareNews()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> ShareNews(InsertArticleRequest insertArticleRequest)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(insertArticleRequest);
			StringContent content = new StringContent(jsonData,Encoding.UTF8, "application/json");
			var response = await client.PostAsync("https://localhost:7090/api/Article/Insert", content);

			if(response.IsSuccessStatusCode)
			{
				return RedirectToAction("LatestNews","News");
			}

			return View();
		}

		public IActionResult LatestComments()
		{
			return View();
		}
	}
}
