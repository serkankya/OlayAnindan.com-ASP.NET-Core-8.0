using Microsoft.AspNetCore.Mvc;

namespace OA.UserInterface.Areas.User.ViewComponents
{
	public class _PolicyTermsOfUseComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
