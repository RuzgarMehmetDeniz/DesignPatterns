using DesignPatterns.DesignPatterns.UnitOfWork;
using DesignPatterns.Entites;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatterns.Controllers
{
    public class AdminSaleController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdminSaleController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult SaleList()
        {
            var values = _unitOfWork.Sales.GetAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateSale()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateSale(Sale sale)
        {
            _unitOfWork.Sales.Add(sale);
            _unitOfWork.Save();
            return RedirectToAction("SaleList");
        }

        [HttpGet]
        public IActionResult UpdateSale(int id)
        {
            var value = _unitOfWork.Sales.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateSale(Sale sale)
        {
            _unitOfWork.Sales.Update(sale);
            _unitOfWork.Save();
            return RedirectToAction("SaleList");
        }

        public IActionResult DeleteSale(int id)
        {
            _unitOfWork.Sales.Delete(id);
            _unitOfWork.Save();
            return RedirectToAction("SaleList");
        }
    }
}