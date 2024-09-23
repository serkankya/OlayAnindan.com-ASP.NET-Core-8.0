using Microsoft.AspNetCore.Mvc;

namespace OA.UserInterface.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class LoginController : Controller
	{
		public IActionResult Login()
		{
			return View();
		}
	}
}
