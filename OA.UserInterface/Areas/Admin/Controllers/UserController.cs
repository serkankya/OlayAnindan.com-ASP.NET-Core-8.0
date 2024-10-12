using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OA.EntityLayer.Requests.UserRequests;
using OA.UserInterface.Models;
using System.Text;

namespace OA.UserInterface.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class UserController : Controller
	{
		readonly IHttpClientFactory _httpClientFactory;
		readonly ApiSettings _apiSettings;

		public UserController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSettings)
		{
			_httpClientFactory = httpClientFactory;
			_apiSettings = apiSettings.Value;
		}

		public async Task<IActionResult> Manage()
		{
			var client = _httpClientFactory.CreateClient();
			client.BaseAddress = new Uri(_apiSettings.BaseHostUrl!);
			var response = await client.GetAsync("User/GetUserDetails");

			if (response.IsSuccessStatusCode)
			{
				var jsonData = await response.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultUserRequest>>(jsonData);

				return View(values);
			}

			return View();
		}

		[HttpGet]
		public IActionResult InsertUser()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> InsertUser(InsertUserRequest insertUserRequest)
		{
			var client = _httpClientFactory.CreateClient();
			client.BaseAddress = new Uri(_apiSettings.BaseHostUrl!);
			var jsonData = JsonConvert.SerializeObject(insertUserRequest);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var response = await client.PostAsync("User/Insert", content);

			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Manage", "User");
			}

			return View();
		}

		public async Task<IActionResult> BlockedUsers()
		{
			var client = _httpClientFactory.CreateClient();
			client.BaseAddress = new Uri(_apiSettings.BaseHostUrl!);
			var response = await client.GetAsync("User/GetBlockedUsers");

			if (response.IsSuccessStatusCode)
			{
				var jsonData = await response.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultUserRequest>>(jsonData);
				return View(values);
			}

			return View();
		}

		public async Task<IActionResult> GetUser(int id)
		{
			var client = _httpClientFactory.CreateClient();
			client.BaseAddress = new Uri(_apiSettings.BaseHostUrl!);
			var response = await client.GetAsync("User/GetUser/" + id);

			if (response.IsSuccessStatusCode)
			{
				var jsonData = await response.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<ResultUserRequest>(jsonData);
				return View(values);
			}

			return View();
		}

		public async Task<IActionResult> BlockUser(int id)
		{
			var client = _httpClientFactory.CreateClient();
			client.BaseAddress = new Uri(_apiSettings.BaseHostUrl!);
			StringContent content = new StringContent(string.Empty);

			var response = await client.PutAsync("User/BlockUser/" + id, content);

			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Manage", "User");
			}

			return View();
		}

		public async Task<IActionResult> UnblockUser(int id)
		{
			var client = _httpClientFactory.CreateClient();
			client.BaseAddress = new Uri(_apiSettings.BaseHostUrl!);
			StringContent content = new StringContent(string.Empty);

			var response = await client.PutAsync("User/UnblockUser/" + id, content);

			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Manage", "User");
			}

			return View();
		}
	}
}
