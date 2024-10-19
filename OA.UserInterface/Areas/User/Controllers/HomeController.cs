using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OA.UserInterface.Models;

namespace OA.UserInterface.Areas.User.Controllers
{
    [Area("User")]
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
