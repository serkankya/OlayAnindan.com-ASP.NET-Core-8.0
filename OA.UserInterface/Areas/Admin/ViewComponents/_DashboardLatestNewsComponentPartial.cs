using Microsoft.AspNetCore.Mvc;

namespace OA.UserInterface.Areas.Admin.ViewComponents
{
    public class _DashboardLatestNewsComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
