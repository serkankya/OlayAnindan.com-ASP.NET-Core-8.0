using Microsoft.AspNetCore.Mvc;

namespace OA.UserInterface.Areas.User.ViewComponents
{
    public class _NewsSingleCommentsComponentPartial : ViewComponent
    {
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
