using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OA.EntityLayer.Requests.CategoryRequests;
using OA.UserInterface.Models;
using System.Text;

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

		public async Task<IActionResult> InsertCategory(InsertCategoryRequest insertCategoryRequest)
		{
			var client = _httpClientFactory.CreateClient();
			client.BaseAddress = new Uri(_apiSettings.BaseHostUrl!);
			var jsonData = JsonConvert.SerializeObject(insertCategoryRequest);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var response = await client.PostAsync("Category/Insert", content);

			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Manage", "Category");
			}

			return View();
		}

		[HttpGet]
		public async Task<IActionResult> UpdateCategory(int id)
		{
			var client = _httpClientFactory.CreateClient();
			client.BaseAddress = new Uri(_apiSettings.BaseHostUrl!);
			var response = await client.GetAsync("Category/Get/" + id);

			if (response.IsSuccessStatusCode)
			{
				var jsonData = await response.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<ResultCategoryRequest>(jsonData);
				return View(values);
			}

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> UpdateCategory(UpdateCategoryRequest updateCategoryRequest)
		{
			var update = new UpdateCategoryRequest(
				updateCategoryRequest.CategoryId,
				updateCategoryRequest.CategoryName,
				updateCategoryRequest.Description,
				DateTime.Now,
				updateCategoryRequest.Status
			);

			var client = _httpClientFactory.CreateClient();
			client.BaseAddress = new Uri(_apiSettings.BaseHostUrl!);
			var jsonData = JsonConvert.SerializeObject(update);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var response = await client.PutAsync("Category/Update", content);

			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Manage", "Category");
			}

			return View();
		}

		public async Task<IActionResult> ActivateCategory(int id)
		{
			var client = _httpClientFactory.CreateClient();
			client.BaseAddress = new Uri(_apiSettings.BaseHostUrl!);
			StringContent content = new StringContent(string.Empty);

			var response = await client.PutAsync("Category/ActivateCategory/" + id, content);

			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Manage", "Category");
			}

			return View();
		}
	}
}
