using Microsoft.AspNetCore.Mvc;

namespace OA.UserInterface.Areas.User.ViewComponents
{
    public class _NewsFilterSectionComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
