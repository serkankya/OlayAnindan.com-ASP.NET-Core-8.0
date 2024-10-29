using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OA.EntityLayer.Requests.ContactInfoRequests;
using OA.EntityLayer.Requests.ContactMessageRequests;
using OA.UserInterface.Models;
using System.Text;

namespace OA.UserInterface.Areas.User.Controllers
{
    [Area("User")]
    public class ContactController : Controller
    {
        readonly IHttpClientFactory _httpClientFactory;
        readonly ApiSettings _apiSettings;

        public ContactController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSettings)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
        }

        public async Task<IActionResult> Index()
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

        [HttpPost]
        public async Task<IActionResult> SendMessage(InsertContactMessageRequest insertContactMessageRequest)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apiSettings.BaseHostUrl!);
            var jsonData = JsonConvert.SerializeObject(insertContactMessageRequest);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("Contact/Insert", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Home", new { area = "User" });
            }

            return View();
        }
    }
}
