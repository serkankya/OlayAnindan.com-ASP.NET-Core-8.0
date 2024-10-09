using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OA.EntityLayer.Requests.CategoryRequests;
using OA.UserInterface.Models;

namespace OA.UserInterface.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class CategoryController : Controller
	{
		readonly IHttpClientFactory _httpClientFactory;
		readonly ApiSettings _apiSettings;

		public CategoryController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSettings)
		{
			_httpClientFactory = httpClientFactory;
			_apiSettings = apiSettings.Value;
		}

		public async Task<IActionResult> Manage()
		{
			var client = _httpClientFactory.CreateClient();
			client.BaseAddress = new Uri(_apiSettings.BaseHostUrl!);
			var response = await client.GetAsync("Category/GetAll");

			if (response.IsSuccessStatusCode)
			{
				var jsonData = await response.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultCategoryRequest>>(jsonData);

				return View(values);
			}

			return View();
		}

		public async Task<IActionResult> RemoveCategory(int id)
		{
			var client = _httpClientFactory.CreateClient();
			client.BaseAddress = new Uri(_apiSettings.BaseHostUrl!);
			var content = new StringContent(string.Empty);

			var response = await client.PutAsync("Category/Remove/" + id, content);

			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Manage", "Category");
			}

			return View();
		}
	}
}
