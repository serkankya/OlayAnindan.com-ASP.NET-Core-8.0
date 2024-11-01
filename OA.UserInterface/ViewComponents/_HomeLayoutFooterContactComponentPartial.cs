using Microsoft.AspNetCore.Mvc;

namespace OA.UserInterface.ViewComponents
{
	public class _HomeLayoutFooterContactComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
