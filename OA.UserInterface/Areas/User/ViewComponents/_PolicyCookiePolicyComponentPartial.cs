using Microsoft.AspNetCore.Mvc;

namespace OA.UserInterface.Areas.User.ViewComponents
{
	public class _PolicyCookiePolicyComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
