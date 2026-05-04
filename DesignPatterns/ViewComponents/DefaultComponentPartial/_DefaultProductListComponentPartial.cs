using DesignPatterns.Context;
using DesignPatterns.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesignPatterns.ViewComponents.DefaultComponentPartial
{
    public class _DefaultProductListComponentPartial : ViewComponent
    {
        private readonly BankContext _context;

        public _DefaultProductListComponentPartial(BankContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Hem kategorileri hem ürünleri çekiyoruz
            var categories = await _context.Category.ToListAsync();
            var products = await _context.Products.ToListAsync();

            var model = new CategoryProductViewModel
            {
                Categories = categories,
                Products = products
            };

            return View(model);
        }
    }
}