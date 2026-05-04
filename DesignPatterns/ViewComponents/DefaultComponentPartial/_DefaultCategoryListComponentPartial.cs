using DesignPatterns.Context;
using DesignPatterns.Entites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesignPatterns.ViewComponents.DefaultComponentPartial
{
    public class _DefaultCategoryListComponentPartial : ViewComponent
    {
        private readonly BankContext _context;

        public _DefaultCategoryListComponentPartial(BankContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Veritabanındaki kategori listesini çeker
            var values = await _context.Category.ToListAsync();
            return View(values);
        }
    }
}