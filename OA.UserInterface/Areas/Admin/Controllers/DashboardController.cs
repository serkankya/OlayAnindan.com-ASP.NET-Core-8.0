using Microsoft.AspNetCore.Mvc;

namespace OA.UserInterface.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
