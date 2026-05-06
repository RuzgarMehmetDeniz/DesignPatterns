using DesignPatterns.DesignPatterns.UnitOfWork;
using DesignPatterns.Entites;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatterns.Controllers
{
    public class AdminCustomerProcessController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdminCustomerProcessController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult ProcessList()
        {
            var values = _unitOfWork.CustomerProcesses.GetAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateProcess()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateProcess(CustomerProcess customerProcess)
        {
            _unitOfWork.CustomerProcesses.Add(customerProcess);
            _unitOfWork.Save();
            return RedirectToAction("ProcessList");
        }

        [HttpGet]
        public IActionResult UpdateProcess(int id)
        {
            var value = _unitOfWork.CustomerProcesses.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateProcess(CustomerProcess customerProcess)
        {
            _unitOfWork.CustomerProcesses.Update(customerProcess);
            _unitOfWork.Save();
            return RedirectToAction("ProcessList");
        }

        public IActionResult DeleteProcess(int id)
        {
            _unitOfWork.CustomerProcesses.Delete(id);
            _unitOfWork.Save();
            return RedirectToAction("ProcessList");
        }
    }
}