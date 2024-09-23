using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OA.EntityLayer.Requests.ArticleRequests;

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

		public IActionResult ShareNews()
		{
			return View();
		}

		public IActionResult LatestComments()
		{
			return View();
		}
	}
}
