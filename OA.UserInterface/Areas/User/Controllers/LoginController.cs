using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OA.UserInterface.Models;
using System.IdentityModel.Tokens.Jwt;
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
				var token = parsedResponse!.token.ToString();

				Response.Cookies.Append("AuthToken", token, new CookieOptions { HttpOnly = true });

				var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
				var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

				if (jwtToken != null)
				{
					var roleIdClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "roleId")?.Value;

					if (!string.IsNullOrEmpty(roleIdClaim) && int.TryParse(roleIdClaim, out int roleId))
					{
						if (roleId == 1) 
						{
							return RedirectToAction("ShareNews", "News", new { area = "Admin" });
						}
					}
				}

				return RedirectToAction("Index", "Home", new { area = "User" });
			}
			else
			{
				TempData["LoginError"] = "Geçersiz kullanıcı adı veya şifre.";
				return View();
			}
		}


		public IActionResult LogOut()
        {
            Response.Cookies.Delete("AuthToken");

			return RedirectToAction("Index", "Home", new { area = "User" });
		}
	}
}
