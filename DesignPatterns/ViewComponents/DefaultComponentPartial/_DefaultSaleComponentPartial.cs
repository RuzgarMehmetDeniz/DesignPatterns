using DesignPatterns.Context;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatterns.ViewComponents.DefaultComponentPartial
{
    public class _DefaultSaleComponentPartial:ViewComponent
    {
        private readonly BankContext _bankContext;

        public _DefaultSaleComponentPartial(BankContext bankContext)
        {
            _bankContext = bankContext;
        }

        public async Task<IViewComponentResult >InvokeAsync()
        {
            var sales = _bankContext.Sales.FirstOrDefault();
            return View(sales);
        }
    }
}
