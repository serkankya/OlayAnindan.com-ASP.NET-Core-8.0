using Microsoft.AspNetCore.Mvc;

namespace OA.UserInterface.Areas.User.Controllers
{
    [Area("User")]
    public class NewsController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.CategoryId = TempData["CategoryId"];
            ViewBag.DateOpt = TempData["DateOpt"];
            
            return View();
        }

        [HttpGet]
        public IActionResult FilterNews(int categoryId, bool dateOpt)
        {
            TempData["CategoryId"] = categoryId;
            TempData["DateOpt"] = dateOpt;

            return RedirectToAction("Index","News", new {area="User"});
        }

		[Route("/User/News/SingleNews/{articleId}")]
		public IActionResult SingleNews(int articleId)
		{
			ViewBag.SelectedArticledId = articleId;
			return View();
		}
	}
}
