using Microsoft.AspNetCore.Mvc;

namespace OA.UserInterface.Areas.User.Controllers
{
    [Area("User")]
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
