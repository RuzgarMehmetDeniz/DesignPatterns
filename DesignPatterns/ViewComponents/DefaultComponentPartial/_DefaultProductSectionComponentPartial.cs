using DesignPatterns.Context;
using DesignPatterns.Entites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesignPatterns.ViewComponents.DefaultComponentPartial
{
    public class _DefaultProductSectionComponentPartial : ViewComponent
    {
        private readonly BankContext _bankContext;

        public _DefaultProductSectionComponentPartial(BankContext bankContext)
        {
            _bankContext = bankContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _bankContext.Products.Where(p => p.CategoryId == 2).ToListAsync();
            return View(value);
        }
    }
}
