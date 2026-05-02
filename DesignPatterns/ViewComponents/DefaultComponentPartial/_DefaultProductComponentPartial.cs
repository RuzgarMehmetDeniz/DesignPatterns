using Microsoft.AspNetCore.Mvc;

namespace DesignPatterns.ViewComponents.DefaultComponentPartial
{
    public class _DefaultProductComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
