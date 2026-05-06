using DesignPatterns.DesignPatterns.UnitOfWork;
using DesignPatterns.Entites;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatterns.Controllers
{
    public class AdminBrandController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdminBrandController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult BrandList()
        {
            var values = _unitOfWork.Brands.GetAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateBrand()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateBrand(Brand brand)
        {
            _unitOfWork.Brands.Add(brand);
            _unitOfWork.Save();
            return RedirectToAction("BrandList");
        }

        [HttpGet]
        public IActionResult UpdateBrand(int id)
        {
            var value = _unitOfWork.Brands.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateBrand(Brand brand)
        {
            _unitOfWork.Brands.Update(brand);
            _unitOfWork.Save();
            return RedirectToAction("BrandList");
        }

        public IActionResult DeleteBrand(int id)
        {
            _unitOfWork.Brands.Delete(id);
            _unitOfWork.Save();
            return RedirectToAction("BrandList");
        }
    }
}