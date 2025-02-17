using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OA.EntityLayer.Requests.UserRequests;
using OA.UserInterface.Models;
using System.Text;

namespace OA.UserInterface.Areas.User.Controllers
{
	[Area("User")]
	public class RegisterController : Controller
	{
		readonly IHttpClientFactory _httpClientFactory;
		readonly ApiSettings _apiSettings;

		public RegisterController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSettings)
		{
			_httpClientFactory = httpClientFactory;
			_apiSettings = apiSettings.Value;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(InsertUserRequest insertUserRequest, string passwordConfirmation)
		{
			if (passwordConfirmation != insertUserRequest.PasswordHash)
			{
				TempData["PasswordDoesNotMatch"] = "Lütfen aynı şifreyi girdiğinizden emin olunuz.";
				return View();
			}

			var client = _httpClientFactory.CreateClient();
			client.BaseAddress = new Uri(_apiSettings.BaseHostUrl!);

			var newInsertUserRequest = insertUserRequest with { RoleId = 1, Biography = "null", ImageUrl = "null" };

			var jsonData = JsonConvert.SerializeObject(newInsertUserRequest);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var response = await client.PostAsync("User/Insert", content);

			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Login", new { area = "User" });
			}

			var errorContent = await response.Content.ReadAsStringAsync();

			var errorObject = JObject.Parse(errorContent);

			List<string> errorMessages = new List<string>();

			var passwordHashError = errorObject["errors"]?["PasswordHash"]?.FirstOrDefault()?.ToString();
			var usernameError = errorObject["errors"]?["Username"]?.FirstOrDefault()?.ToString();
			var emailError = errorObject["errors"]?["Email"]?.FirstOrDefault()?.ToString();
			var fullNameError = errorObject["errors"]?["FullName"]?.FirstOrDefault()?.ToString();
			var roleIdError = errorObject["errors"]?["RoleId"]?.FirstOrDefault()?.ToString();

			if (!string.IsNullOrEmpty(passwordHashError))
			{
				if (passwordHashError.Contains("Password must contain at least one uppercase letter"))
					errorMessages.Add("Şifre en az bir büyük harf, bir küçük harf ve bir rakam içermelidir.");
				else if (passwordHashError.Contains("Password must be at least 6 characters long"))
					errorMessages.Add("Şifre en az 6 karakter uzunluğunda olmalıdır.");
				else if (passwordHashError.Contains("Password cannot be empty"))
					errorMessages.Add("Şifre boş olamaz.");
			}

			if (!string.IsNullOrEmpty(usernameError))
			{
				if (usernameError.Contains("Username cannot be empty"))
					errorMessages.Add("Kullanıcı adı boş olamaz.");
				else if (usernameError.Contains("Username must be at least 2 characters long"))
					errorMessages.Add("Kullanıcı adı en az 2 karakter uzunluğunda olmalıdır.");
				else if (usernameError.Contains("Username must be smaller than 75 characters long"))
					errorMessages.Add("Kullanıcı adı 75 karakterden kısa olmalıdır.");
			}

			if (!string.IsNullOrEmpty(emailError))
			{
				if (emailError.Contains("Email cannot be empty"))
					errorMessages.Add("E-posta boş olamaz.");
				else if (emailError.Contains("Email must be at least 10 characters long"))
					errorMessages.Add("E-posta en az 10 karakter uzunluğunda olmalıdır.");
				else if (emailError.Contains("Email must be smaller than 175 characters long"))
					errorMessages.Add("E-posta 175 karakterden kısa olmalıdır.");
			}

			if (!string.IsNullOrEmpty(fullNameError))
			{
				if (fullNameError.Contains("Full name cannot be empty"))
					errorMessages.Add("Ad soyad boş olamaz.");
				else if (fullNameError.Contains("Full name must be at least 4 characters long"))
					errorMessages.Add("Ad soyad en az 4 karakter uzunluğunda olmalıdır.");
				else if (fullNameError.Contains("Full name must be smaller than 100 characters long"))
					errorMessages.Add("Ad soyad 100 karakterden kısa olmalıdır.");
			}

			if (!string.IsNullOrEmpty(roleIdError))
			{
				if (roleIdError.Contains("You have to choose a role"))
					errorMessages.Add("Bir rol seçmeniz gerekmektedir.");
			}

			if (errorMessages.Count == 0)
			{
				errorMessages.Add("Bilinmeyen bir hata oluştu.");
			}

			TempData["ResponseErrors"] = errorMessages;

			return View();
		}
	}
}
