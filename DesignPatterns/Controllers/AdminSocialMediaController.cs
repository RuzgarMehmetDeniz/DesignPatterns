using DesignPatterns.DesignPatterns.UnitOfWork;
using DesignPatterns.Entites;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatterns.Controllers
{
    public class AdminSocialMediaController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdminSocialMediaController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult SocialMediaList()
        {
            var values = _unitOfWork.SocialMedias.GetAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateSocialMedia(SocialMedia socialMedia)
        {
            _unitOfWork.SocialMedias.Add(socialMedia);
            _unitOfWork.Save();
            return RedirectToAction("SocialMediaList");
        }

        [HttpGet]
        public IActionResult UpdateSocialMedia(int id)
        {
            var value = _unitOfWork.SocialMedias.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateSocialMedia(SocialMedia socialMedia)
        {
            _unitOfWork.SocialMedias.Update(socialMedia);
            _unitOfWork.Save();
            return RedirectToAction("SocialMediaList");
        }

        public IActionResult DeleteSocialMedia(int id)
        {
             _unitOfWork.SocialMedias.Delete(id);
            _unitOfWork.Save();
            return RedirectToAction("SocialMediaList");
        }
    }
}