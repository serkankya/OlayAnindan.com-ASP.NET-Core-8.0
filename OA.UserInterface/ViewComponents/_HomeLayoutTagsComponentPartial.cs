using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OA.EntityLayer.Requests.ArticleTagRequests;
using OA.UserInterface.Models;

namespace OA.UserInterface.ViewComponents
{
	public class _HomeLayoutTagsComponentPartial : ViewComponent
	{
		readonly IHttpClientFactory _httpClientFactory;
		readonly ApiSettings _apiSettings;

        public _HomeLayoutTagsComponentPartial(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSettings)
        {
			_httpClientFactory = httpClientFactory;
			_apiSettings = apiSettings.Value;
        }

        public async  Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			client.BaseAddress = new Uri(_apiSettings.BaseHostUrl!);

			if (TempData["SelectedArticleId"] != null)
			{
				int articleId = Convert.ToInt32(TempData["SelectedArticleId"]);

				var responseForArticle = await client.GetAsync($"ArticleTag/GetResultArticleTags/{articleId}");

				if (responseForArticle.IsSuccessStatusCode)
				{
					var jsonData = await responseForArticle.Content.ReadAsStringAsync();
					var values = JsonConvert.DeserializeObject<List<ResultArticleTagRequest>>(jsonData);

					return View(values);
				}
			}

			var response = await client.GetAsync("ArticleTag/GetResultArticleTags");

			if (response.IsSuccessStatusCode)
			{
				var jsonData = await response.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultArticleTagRequest>>(jsonData);

				return View(values);
			}

			return View();
		}
	}
}
