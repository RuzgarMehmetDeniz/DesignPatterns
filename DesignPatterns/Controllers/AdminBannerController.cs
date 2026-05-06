using DesignPatterns.DesignPatterns.UnitOfWork;
using DesignPatterns.Entites;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatterns.Controllers
{
    public class AdminBannerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdminBannerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult BannerList()
        {
            var values = _unitOfWork.Banners.GetAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateBanner()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateBanner(Banner banner)
        {
            _unitOfWork.Banners.Add(banner);
            _unitOfWork.Save();
            return RedirectToAction("BannerList");
        }

        [HttpGet]
        public IActionResult UpdateBanner(int id)
        {
            var value = _unitOfWork.Banners.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateBanner(Banner banner)
        {
            _unitOfWork.Banners.Update(banner);
            _unitOfWork.Save();
            return RedirectToAction("BannerList");
        }

        public IActionResult DeleteBanner(int id)
        {
            _unitOfWork.Banners.Delete(id);
            _unitOfWork.Save();
            return RedirectToAction("BannerList");
        }
    }
}