using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OA.EntityLayer.Requests.SubscriberRequests;
using OA.UserInterface.Models;
using System.Text;

namespace OA.UserInterface.Areas.User.Controllers
{
	[Area("User")]
	public class HomeController : Controller
	{
		readonly IHttpClientFactory _httpClientFactory;
		readonly ApiSettings _apiSettings;

		public HomeController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSettings)
		{
			_httpClientFactory = httpClientFactory;
			_apiSettings = apiSettings.Value;
		}

		public IActionResult Index()
		{
			return View();
		}

		public async Task<IActionResult> SubscribeToNews(InsertSubscriberRequest insertSubscriberRequest)
		{
			var client = _httpClientFactory.CreateClient();
			client.BaseAddress = new Uri(_apiSettings.BaseHostUrl!);
			var jsonData = JsonConvert.SerializeObject(insertSubscriberRequest);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var response = await client.PostAsync("Subscriber/Insert", stringContent);

			if (response.IsSuccessStatusCode)
			{
				TempData[("SuccessfulSubscription")] = $"{insertSubscriberRequest.Email} adresiyle abonelik sistemine kayıt oldunuz.";
				return RedirectToAction("Index", "Home", new { area = "User" });
			}

			return View();
		}
	}
}
