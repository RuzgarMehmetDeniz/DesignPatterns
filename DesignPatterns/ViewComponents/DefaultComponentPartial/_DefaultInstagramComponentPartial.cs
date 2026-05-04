using DesignPatterns.Context;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatterns.ViewComponents.DefaultComponentPartial
{
    public class _DefaultInstagramComponentPartial:ViewComponent
    {
        private readonly BankContext _context;
        public _DefaultInstagramComponentPartial(BankContext context)
        {
            _context = context;
        }
        public async Task< IViewComponentResult >InvokeAsync()
        {
            var values = _context.SocialMedias.ToList();
            return View(values);
        }
    }
}
