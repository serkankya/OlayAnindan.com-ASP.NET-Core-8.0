using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OA.EntityLayer.Requests.CommentRequests;
using OA.UserInterface.Models;

namespace OA.UserInterface.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class CommentController : Controller
	{
		readonly IHttpClientFactory _httpClientFactory;
		readonly ApiSettings _apiSettings;

		public CommentController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSettings)
		{
			_httpClientFactory = httpClientFactory;
			_apiSettings = apiSettings.Value;
		}

		public async Task<IActionResult> LatestComments()
		{
			var client = _httpClientFactory.CreateClient();
			client.BaseAddress = new Uri(_apiSettings.BaseHostUrl!);
			var response = await client.GetAsync("Comment/GetResultComments");

			if (response.IsSuccessStatusCode)
			{
				var jsonData = await response.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultCommentRequest>>(jsonData);

				return View(values);
			}

			return View();
		}

		public async Task<IActionResult> RemoveComment(int id)
		{
			var client = _httpClientFactory.CreateClient();
			client.BaseAddress = new Uri(_apiSettings.BaseHostUrl!);
			var content = new StringContent(string.Empty);

			var response = await client.PutAsync("Comment/Remove/" + id, content);

			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("LatestComments", "Comment");
			}

			return View();
		}

		public async Task<IActionResult> ActivateComment(int id)
		{
			var client = _httpClientFactory.CreateClient();
			client.BaseAddress = new Uri(_apiSettings.BaseHostUrl!);
			var content = new StringContent(string.Empty);

			var response = await client.PutAsync("Comment/ActivateComment/" + id, content);

			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("LatestComments", "Comment");
			}

			return View();
		}
	}
}
