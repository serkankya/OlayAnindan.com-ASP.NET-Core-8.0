using Microsoft.AspNetCore.Mvc;

namespace OA.UserInterface.Areas.Admin.ViewComponents
{
    public class _DashboardGraphicsComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
