using Microsoft.AspNetCore.Mvc;

namespace DesignPatterns.Controllers
{
    public class AdminCategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
