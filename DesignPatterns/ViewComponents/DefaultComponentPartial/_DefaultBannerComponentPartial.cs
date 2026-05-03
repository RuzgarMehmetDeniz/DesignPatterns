using DesignPatterns.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesignPatterns.ViewComponents.DefaultComponentPartial
{
    public class _DefaultBannerComponentPartial:ViewComponent
    {
        private readonly BankContext _bankContext;

        public _DefaultBannerComponentPartial(BankContext bankContext)
        {
            _bankContext = bankContext;
        }

        public async Task< IViewComponentResult >InvokeAsync()
        {
            var value = await _bankContext.Banners.FirstOrDefaultAsync();
            return View(value);
        }
    }
}
