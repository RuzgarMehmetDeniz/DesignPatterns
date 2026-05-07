using DesignPatterns.DesignPatterns.UnitOfWork;
using DesignPatterns.Entites;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatterns.Controllers
{
    public class AdminTestimonialController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdminTestimonialController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult TestimonialList()
        {
            var values = _unitOfWork.Testimonials.GetAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateTestimonial()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateTestimonial(Testimonial testimonial)
        {
            _unitOfWork.Testimonials.Add(testimonial);
            _unitOfWork.Save();
            return RedirectToAction("TestimonialList");
        }

        [HttpGet]
        public IActionResult UpdateTestimonial(int id)
        {
            var value = _unitOfWork.Testimonials.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateTestimonial(Testimonial testimonial)
        {
            _unitOfWork.Testimonials.Update(testimonial);
            _unitOfWork.Save();
            return RedirectToAction("TestimonialList");
        }

        public IActionResult DeleteTestimonial(int id)
        {
             _unitOfWork.Testimonials.Delete(id);
            _unitOfWork.Save();
            return RedirectToAction("TestimonialList");
        }
    }
}