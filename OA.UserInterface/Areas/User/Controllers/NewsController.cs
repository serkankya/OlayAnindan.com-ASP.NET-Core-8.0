using Microsoft.AspNetCore.Mvc;

namespace OA.UserInterface.Areas.User.Controllers
{
    [Area("User")]
    public class NewsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
