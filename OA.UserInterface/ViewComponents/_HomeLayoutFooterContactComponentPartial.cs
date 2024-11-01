using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OA.EntityLayer.Requests.ContactInfoRequests;
using OA.UserInterface.Models;

namespace OA.UserInterface.ViewComponents
{
	public class _HomeLayoutFooterContactComponentPartial : ViewComponent
	{
		readonly IHttpClientFactory _httpClientFactory;
		readonly ApiSettings _apiSettings;

		public _HomeLayoutFooterContactComponentPartial(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSettings)
		{
			_httpClientFactory = httpClientFactory;
			_apiSettings = apiSettings.Value;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			client.BaseAddress = new Uri(_apiSettings.BaseHostUrl!);
			var response = await client.GetAsync("ContactInfo/GetActives");

			if (response.IsSuccessStatusCode)
			{
				var jsonData = await response.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultContactInfoRequest>>(jsonData);

				var value = values!.FirstOrDefault();

				return View(value);
			}

			return View();
		}
	}
}
