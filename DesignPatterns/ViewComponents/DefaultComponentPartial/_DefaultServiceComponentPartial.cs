using DesignPatterns.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesignPatterns.ViewComponents.DefaultComponentPartial
{
    public class _DefaultServiceComponentPartial:ViewComponent
    {
        private readonly BankContext _bankContext;
        public _DefaultServiceComponentPartial(BankContext bankContext)
        {
            _bankContext = bankContext;
        }
        public async Task<IViewComponentResult >InvokeAsync()
        {
            var services = await _bankContext.Services.ToListAsync();
            return View(services);
        }
    }
}
