using Microsoft.AspNetCore.Mvc;

namespace OA.UserInterface.ViewComponents
{
	public class _HomeLayoutNavbarComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
