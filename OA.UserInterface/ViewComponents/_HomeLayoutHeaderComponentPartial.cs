using Microsoft.AspNetCore.Mvc;

namespace OA.UserInterface.ViewComponents
{
	public class _HomeLayoutHeaderComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
