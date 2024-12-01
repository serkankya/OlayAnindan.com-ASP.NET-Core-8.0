using Microsoft.AspNetCore.Mvc;

namespace OA.UserInterface.Areas.User.Controllers
{
	[Area("User")]
	public class PolicyController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
