using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OA.EntityLayer.Requests.SubscriberRequests;
using OA.UserInterface.Models;
using System.Net;
using System.Net.Mail;
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

        Random _random = new Random();
        int _code;
        string _email;

		[HttpPost]
		public IActionResult SendCode(string email)
		{
			if (string.IsNullOrEmpty(email))
			{
				return BadRequest("Geçersiz e-posta adresi.");
			}

			_code = _random.Next(10000, 100000);
			_email = email;

			string smtpServer = "smtp.gmail.com";
			int smtpPort = 587;
			string smtpUser = "serkankaya0721@gmail.com";
			string smtpPassword = "code1";

			MailMessage mailMessage = new MailMessage();
			SmtpClient smtpClient = new SmtpClient();

			smtpClient.Host = smtpServer;
			smtpClient.Port = smtpPort;
			smtpClient.Credentials = new NetworkCredential(smtpUser, smtpPassword);
			smtpClient.EnableSsl = true;

			mailMessage.From = new MailAddress(smtpUser);
			mailMessage.To.Add(email);
			mailMessage.Subject = "OlayAnindan.com Abonelik Doğrulama Kodu";
			mailMessage.Body = $"5 Haneli Doğrulama Kodunuz : {_code} \n\nEğer bu işlemi siz gerçekleştirmediyseniz lütfen görmezden geliniz.";

			smtpClient.Send(mailMessage);

			TempData["CodeForVerification"] = _code;
			TempData["EmailForRecord"] = _email;

			return Ok();
		}

		[HttpPost]
		public IActionResult VerifyCode(int verificationCode)
		{
			if (verificationCode == Convert.ToInt32(TempData["CodeForVerification"]))
			{
				InsertSubscriberRequest insertSubscriberRequest = new(TempData["EmailForRecord"].ToString());
				SubscribeToNews(insertSubscriberRequest);

				return Json(new { success = true });
			}
			else
			{
				return Json(new { success = false });
			}
		}

		public ActionResult Error()
		{
			return View();
		}
	}
}