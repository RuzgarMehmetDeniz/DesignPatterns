using DesignPatterns.DesignPatterns.UnitOfWork;
using DesignPatterns.Entites;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatterns.Controllers
{
    public class AdminQualityController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdminQualityController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult QualityList()
        {
            var values = _unitOfWork.Qualities.GetAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateQuality()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateQuality(Quality quality)
        {
            _unitOfWork.Qualities.Add(quality);
            _unitOfWork.Save();
            return RedirectToAction("QualityList");
        }

        [HttpGet]
        public IActionResult UpdateQuality(int id)
        {
            var value = _unitOfWork.Qualities.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateQuality(Quality quality)
        {
            _unitOfWork.Qualities.Update(quality);
            _unitOfWork.Save();
            return RedirectToAction("QualityList");
        }

        public IActionResult DeleteQuality(int id)
        {
            _unitOfWork.Qualities.Delete(id);
            _unitOfWork.Save();
            return RedirectToAction("QualityList");
        }
    }
}