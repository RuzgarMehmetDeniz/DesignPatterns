using Microsoft.AspNetCore.Mvc;

namespace DesignPatterns.ViewComponents.AdminComponentPartial
{
    public class _AdminLayoutHeadComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
