using DesignPatterns.DesignPatterns.UnitOfWork;
using DesignPatterns.Entites;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatterns.Controllers
{
    public class AdminServiceController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdminServiceController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult ServiceList()
        {
            var values = _unitOfWork.Services.GetAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateService()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateService(Service service)
        {
            _unitOfWork.Services.Add(service);
            _unitOfWork.Save();
            return RedirectToAction("ServiceList");
        }

        [HttpGet]
        public IActionResult UpdateService(int id)
        {
            var value = _unitOfWork.Services.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateService(Service service)
        {
            _unitOfWork.Services.Update(service);
            _unitOfWork.Save();
            return RedirectToAction("ServiceList");
        }

        public IActionResult DeleteService(int id)
        {
             _unitOfWork.Services.Delete(id);
            _unitOfWork.Save();
            return RedirectToAction("ServiceList");
        }
    }
}