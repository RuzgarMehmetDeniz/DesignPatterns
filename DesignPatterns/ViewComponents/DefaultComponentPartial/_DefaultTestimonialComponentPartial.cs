using DesignPatterns.Context;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatterns.ViewComponents.DefaultComponentPartial
{
    public class _DefaultTestimonialComponentPartial: ViewComponent
    {
        private readonly BankContext _bankContext;

        public _DefaultTestimonialComponentPartial(BankContext bankContext)
        {
            _bankContext = bankContext;
        }

        public async Task <IViewComponentResult >InvokeAsync()
        {
            var value = _bankContext.Testimonials.ToList();
            return View(value);
        }
    }
}
