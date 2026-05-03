using DesignPatterns.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesignPatterns.ViewComponents.DefaultComponentPartial
{
    public class _DefaultProductComponentPartial:ViewComponent
    {
        private readonly BankContext _context;

        public _DefaultProductComponentPartial(BankContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult >InvokeAsync()
        {
            var value = await _context.AboutSections.ToListAsync();
            return View(value);
        }
    }
}
