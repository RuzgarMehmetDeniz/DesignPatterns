using DesignPatterns.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesignPatterns.ViewComponents.DefaultComponentPartial
{
    public class _DefaultBlogComponentPartial : ViewComponent
    {
        private readonly BankContext _context;

        public _DefaultBlogComponentPartial(BankContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _context.Blogs.OrderBy(a => a.BlogId).Take(4).ToListAsync();
            return View(value);
        }
    }
}
