using DesignPatterns.Context;
using DesignPatterns.Entites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DesignPatterns.Controllers
{
    public class AdminCategoryController : Controller
    {
        private readonly BankContext _context;

        public AdminCategoryController(BankContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> CategoryList()
        {
            var value = await _context.Category.ToListAsync();
            return View(value);
        }
        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(Category category)
        {
            await _context.Category.AddAsync(category);
            await _context.SaveChangesAsync();
            return RedirectToAction("CategoryList");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var value = await _context.Category.FindAsync(id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(Category category)
        {
            _context.Category.Update(category);
            await _context.SaveChangesAsync();
            return RedirectToAction("CategoryList");
        }
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var value = await _context.Category.FindAsync(id);
            _context.Category.Remove(value);
            await _context.SaveChangesAsync();
            return RedirectToAction("CategoryList");
        }
    }
}
