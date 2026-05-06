using DesignPatterns.DesignPatterns.UnitOfWork;
using DesignPatterns.Entites;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DesignPatterns.Controllers
{
    public class AdminCategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        // Context yerine IUnitOfWork enjekte ediyoruz
        public AdminCategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult CategoryList()
        {
            // Unit of Work üzerinden tüm kategorileri çekiyoruz
            var values = _unitOfWork.Categories.GetAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
                _unitOfWork.Categories.Add(category);
                _unitOfWork.Save(); // Tüm işlemler tek bir Save() ile biter
                return RedirectToAction("CategoryList");
        }

        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            var value = _unitOfWork.Categories.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            _unitOfWork.Categories.Update(category);
            _unitOfWork.Save();
            return RedirectToAction("CategoryList");
        }

        public IActionResult DeleteCategory(int id)
        {
            _unitOfWork.Categories.Delete(id);
            _unitOfWork.Save();
            return RedirectToAction("CategoryList");
        }
    }
}