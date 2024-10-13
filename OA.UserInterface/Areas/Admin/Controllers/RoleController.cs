using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OA.EntityLayer.Requests.RoleRequests;
using OA.UserInterface.Models;

namespace OA.UserInterface.Areas.Admin.Controllers
{
	public class RoleController : Controller
	{
		readonly IHttpClientFactory _httpClientFactory;
		readonly ApiSettings _apiSettings;

        public RoleController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSettings)
        {
			_httpClientFactory = httpClientFactory;
			_apiSettings = apiSettings.Value;
        }

        public IActionResult Index()
		{
			return View();
		}

		public async Task<IActionResult> GetActiveRoles()
		{
			var client = _httpClientFactory.CreateClient();
			client.BaseAddress = new Uri(_apiSettings.BaseHostUrl!);
			var response = await client.GetAsync("Role/GetActives");

			if (response.IsSuccessStatusCode)
			{
				var jsonData = await response.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultRoleRequest>>(jsonData);

				ViewBag.Roles = values;
			}

			return View();
		}
	}
}
