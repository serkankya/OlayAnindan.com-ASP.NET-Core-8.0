using Microsoft.AspNetCore.Mvc;

namespace OA.UserInterface.Areas.Admin.Controllers
{
    [Area("Admin")]
	[RoleBasedAuthorize(1)]
	public class DashboardController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
