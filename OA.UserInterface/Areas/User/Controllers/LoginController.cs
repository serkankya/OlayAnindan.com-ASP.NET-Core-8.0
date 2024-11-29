using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OA.UserInterface.Models;
using System.Text;

namespace OA.UserInterface.Areas.User.Controllers
{
    [Area("User")]
    public class LoginController : Controller
    {
        readonly IHttpClientFactory _httpClientFactory;
        readonly ApiSettings _apiSettings;

        public LoginController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSettings)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string username, string password)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apiSettings.BaseHostUrl!);
            var loginRequest = new { username = username, passwordHash = password };
            var jsonData = JsonConvert.SerializeObject(loginRequest);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("Login/Login", stringContent);
            
            ViewBag.Username = username;

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var parsedResponse = JsonConvert.DeserializeObject<dynamic>(jsonResponse);
                var token = parsedResponse.token.ToString();

                Response.Cookies.Append("AuthToken", token.ToString(), new CookieOptions { HttpOnly = true });

                return RedirectToAction("Index", "Home", new { area = "User" });
            }
            else
            {
                TempData["LoginError"] = "Geçersiz kullanıcı adı veya şifre.";
                return View();
            }
        }


    }
}
