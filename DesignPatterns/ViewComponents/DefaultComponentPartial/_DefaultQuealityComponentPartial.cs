using DesignPatterns.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesignPatterns.ViewComponents.DefaultComponentPartial
{
    public class _DefaultQuealityComponentPartial:ViewComponent
    {
        private readonly BankContext _bankContext;

        public _DefaultQuealityComponentPartial(BankContext bankContext)
        {
            _bankContext = bankContext;
        }

        public async Task<IViewComponentResult >InvokeAsync()
        {
            var value = await _bankContext.Qualities.FirstOrDefaultAsync();
            return View(value);
        }
    }
}
