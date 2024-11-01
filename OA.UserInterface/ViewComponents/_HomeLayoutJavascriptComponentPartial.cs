using Microsoft.AspNetCore.Mvc;

namespace OA.UserInterface.ViewComponents
{
	public class _HomeLayoutJavascriptComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
