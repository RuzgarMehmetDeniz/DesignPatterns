using DesignPatterns.DesignPatterns.UnitOfWork;
using DesignPatterns.Entites;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatterns.Controllers
{
    public class AdminAboutController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        // Context yerine IUnitOfWork enjekte ediyoruz
        public AdminAboutController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult AboutList()
        {
            // Unit of Work üzerinden tüm hakkımızda bölümlerini çekiyoruz
            var values = _unitOfWork.AboutSections.GetAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateAbout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateAbout(AboutSection aboutSection)
        {
            _unitOfWork.AboutSections.Add(aboutSection);
            _unitOfWork.Save(); // Tüm işlemler tek bir Save() ile biter
            return RedirectToAction("AboutList");
        }

        [HttpGet]
        public IActionResult UpdateAbout(int id)
        {
            var value = _unitOfWork.AboutSections.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateAbout(AboutSection aboutSection)
        {
            _unitOfWork.AboutSections.Update(aboutSection);
            _unitOfWork.Save();
            return RedirectToAction("AboutList");
        }

        public IActionResult DeleteAbout(int id)
        {
            // Kategorideki pratik yöntemin aynısı: Doğrudan id ile silme komutu
            _unitOfWork.AboutSections.Delete(id);
            _unitOfWork.Save();
            return RedirectToAction("AboutList");
        }
    }
}