using DesignPatterns.DesignPatterns.UnitOfWork;
using DesignPatterns.Entites;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatterns.Controllers
{
    public class AdminBlogController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdminBlogController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult BlogList()
        {
            var values = _unitOfWork.Blogs.GetAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateBlog()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateBlog(Blog blog)
        {
            _unitOfWork.Blogs.Add(blog);
            _unitOfWork.Save();
            return RedirectToAction("BlogList");
        }

        [HttpGet]
        public IActionResult UpdateBlog(int id)
        {
            var value = _unitOfWork.Blogs.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateBlog(Blog blog)
        {
            _unitOfWork.Blogs.Update(blog);
            _unitOfWork.Save();
            return RedirectToAction("BlogList");
        }

        public IActionResult DeleteBlog(int id)
        {
            _unitOfWork.Blogs.Delete(id);
            _unitOfWork.Save();
            return RedirectToAction("BlogList");
        }
    }
}