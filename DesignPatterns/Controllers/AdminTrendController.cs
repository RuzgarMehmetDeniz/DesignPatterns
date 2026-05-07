using DesignPatterns.DesignPatterns.UnitOfWork;
using DesignPatterns.Entites;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatterns.Controllers
{
    public class AdminTrendController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdminTrendController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult TrendList()
        {
            var values = _unitOfWork.Trends.GetAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateTrend()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateTrend(Trend trend)
        {
            _unitOfWork.Trends.Add(trend);
            _unitOfWork.Save();
            return RedirectToAction("TrendList");
        }

        [HttpGet]
        public IActionResult UpdateTrend(int id)
        {
            var value = _unitOfWork.Trends.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateTrend(Trend trend)
        {
            _unitOfWork.Trends.Update(trend);
            _unitOfWork.Save();
            return RedirectToAction("TrendList");
        }

        public IActionResult DeleteTrend(int id)
        {
             _unitOfWork.Trends.Delete(id);
            _unitOfWork.Save();
            return RedirectToAction("TrendList");
        }
    }
}