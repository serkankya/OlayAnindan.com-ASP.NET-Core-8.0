using Microsoft.AspNetCore.Mvc;

namespace OA.UserInterface.Areas.Admin.ViewComponents
{
    public class _DashboardStatisticsComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
