using Microsoft.AspNetCore.Mvc;

namespace OA.UserInterface.ViewComponents
{
	public class _HomeLayoutMenuComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
