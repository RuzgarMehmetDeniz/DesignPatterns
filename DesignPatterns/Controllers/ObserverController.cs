using DesignPatterns.Context;
using DesignPatterns.DesignPatterns.Observer;
using DesignPatterns.DesignPatterns.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesignPatterns.Controllers
{
    public class ObserverController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ObserverObject _observerObject;
        private readonly BankContext _context;

        public ObserverController(IUnitOfWork unitOfWork, ObserverObject observerObject, BankContext context)
        {
            _unitOfWork = unitOfWork;
            _observerObject = observerObject;
            _context = context;
        }

        [HttpGet]
        public IActionResult NotifyCustomer()
        {
            // Müşteri işlemlerini listele
            var processes = _unitOfWork.CustomerProcesses.GetAll();
            return View(processes);
        }

        [HttpPost]
        public IActionResult NotifyCustomer(int id)
        {
            var process = _context.CustomerProcesses.Find(id);

            if (process != null)
            {
                // Ürünü CustomerProcess üzerinden dinamik çek
                var urun = _context.Products.FirstOrDefault(p => p.ProductId == process.CustomerProcessId);

                if (urun != null)
                {
                    process.Amount = urun.Price;
                    process.ProductName = urun.Name; 
                    _observerObject.NotifyObservers(process);
                }
            }

            return RedirectToAction("Index");
        }
    }
}