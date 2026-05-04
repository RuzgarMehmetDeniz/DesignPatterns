using DesignPatterns.Context;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatterns.ViewComponents.DefaultComponentPartial
{
    public class _DefaultBrandComponentPartial:ViewComponent
    {
        private readonly BankContext _bankContext;

        public _DefaultBrandComponentPartial(BankContext bankContext)
        {
            _bankContext = bankContext;
        }

        public async Task<IViewComponentResult >InvokeAsync()
        {
                var brands = _bankContext.Brands.ToList();
            return View(brands);
        }
    }
}
