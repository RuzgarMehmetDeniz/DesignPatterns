using DesignPatterns.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesignPatterns.ViewComponents.DefaultComponentPartial
{
    public class _DefaultTrendComponentPartial:ViewComponent
    {
        private readonly BankContext _context;

        public _DefaultTrendComponentPartial(BankContext context)
        {
            _context = context;
        }

        public async Task< IViewComponentResult >InvokeAsync()
        {
            var value = await _context.Trends.OrderBy(x => x.TrendId).Take(3).ToListAsync();
            return View(value);
        }
    }
}
