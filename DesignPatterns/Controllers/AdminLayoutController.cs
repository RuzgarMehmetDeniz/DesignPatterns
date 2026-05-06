using DesignPatterns.Context;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatterns.Controllers
{
    public class AdminLayoutController : Controller
    {
        private readonly BankContext _context;

        public AdminLayoutController(BankContext context)
        {
            _context = context;
        }

        public async Task< IActionResult >Index()
        {
            return View();
        }
    }
}
