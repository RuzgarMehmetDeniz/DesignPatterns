using Microsoft.AspNetCore.Mvc;

namespace DesignPatterns.ViewComponents.AdminComponentPartial
{
    public class _AdminLayoutNavbarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
