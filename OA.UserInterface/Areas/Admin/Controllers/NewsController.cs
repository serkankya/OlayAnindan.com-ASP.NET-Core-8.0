using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OA.EntityLayer.Requests.ArticleRequests;
using OA.UserInterface.Models;
using System.Text;

namespace OA.UserInterface.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class NewsController : Controller
	{
		readonly IHttpClientFactory _httpClientFactory;
		readonly ApiSettings _apiSettings;

		public NewsController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSettings)
		{
			_httpClientFactory = httpClientFactory;
			_apiSettings = apiSettings.Value;
		}

		public async Task<IActionResult> LatestNews()
		{
			var client = _httpClientFactory.CreateClient();
			client.BaseAddress = new Uri(_apiSettings.BaseHostUrl!);
			var response = await client.GetAsync("Article/GetActives");

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
		public async Task<IActionResult> ShareNews(InsertArticleTransactionRequest insertArticleTransactionRequest,
	IFormFile MainMediaPath,
	IFormFile FirstMediaPath,
	IFormFile SecondMediaPath,
	string TagName)
		{
			string mainMediaPath = string.Empty;
			string firstMediaPath = string.Empty;
			string secondMediaPath = string.Empty;

			var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");

			if (MainMediaPath != null && MainMediaPath.Length > 0)
			{
				mainMediaPath = Path.Combine(uploadsFolder, MainMediaPath.FileName);
				using (var fileStream = new FileStream(mainMediaPath, FileMode.Create))
				{
					await MainMediaPath.CopyToAsync(fileStream);
				}
			}

			if (FirstMediaPath != null && FirstMediaPath.Length > 0)
			{
				firstMediaPath = Path.Combine(uploadsFolder, FirstMediaPath.FileName);
				using (var fileStream = new FileStream(firstMediaPath, FileMode.Create))
				{
					await FirstMediaPath.CopyToAsync(fileStream);
				}
			}

			if (SecondMediaPath != null && SecondMediaPath.Length > 0)
			{
				secondMediaPath = Path.Combine(uploadsFolder, SecondMediaPath.FileName);
				using (var fileStream = new FileStream(secondMediaPath, FileMode.Create))
				{
					await SecondMediaPath.CopyToAsync(fileStream);
				}
			}

			insertArticleTransactionRequest = insertArticleTransactionRequest with
			{
				MainMediaPath = mainMediaPath,
				MainMediaType = MainMediaPath!.ContentType,
				FirstMediaPath = firstMediaPath,
				FirstMediaType = FirstMediaPath!.ContentType,
				SecondMediaPath = secondMediaPath,
				SecondMediaType = SecondMediaPath!.ContentType,
				TagName = JsonConvert.DeserializeObject<List<string>>(TagName)!
			};

			var client = _httpClientFactory.CreateClient();
			client.BaseAddress = new Uri(_apiSettings.BaseHostUrl!);
			var jsonData = JsonConvert.SerializeObject(insertArticleTransactionRequest);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var response = await client.PostAsync("InsertTransaction", content);

			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("LatestNews", "News");
			}
			else
			{
				var error = await response.Content.ReadAsStringAsync();
				Console.WriteLine("Error occured: " + error);
			}

			return View();
		}
	}
}
