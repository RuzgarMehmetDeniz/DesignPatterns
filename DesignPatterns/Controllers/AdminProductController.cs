using DesignPatterns.DesignPatterns.UnitOfWork;
using DesignPatterns.Entites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DesignPatterns.Controllers
{
    public class AdminProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdminProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Ürünleri Kategorileriyle Birlikte Listele
        public IActionResult ProductList()
        {
            // Unit of Work içinde GetProductsWithCategories gibi özel bir metodunuz yoksa 
            // GetAll kullanabilirsiniz. İlişkili veriyi Include ile çekmek gerekebilir.
            var values = _unitOfWork.Products.GetAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateProduct()
        {
            // 1. Kategorileri veritabanından çekiyoruz
            var categories = _unitOfWork.Categories.GetAll();

            // 2. View'daki (SelectList)ViewBag.CategoryList kısmını besliyoruz
            // "CategoryId" veritabanındaki ID, "CategoryName" ise ekranda görünecek isimdir.
            ViewBag.CategoryList = new SelectList(categories, "CategoryId", "CategoryName");

            return View();
        }

        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Products.Add(product);
                _unitOfWork.Save();
                return RedirectToAction("ProductList");
            }

            // KRİTİK: Eğer validation hatası olursa (örneğin isim boşsa) sayfa geri döner.
            // Sayfa geri döndüğünde Dropdown'ın patlamaması için listeyi BURADA DA doldurmalısın.
            var categories = _unitOfWork.Categories.GetAll();
            ViewBag.CategoryList = new SelectList(categories, "CategoryId", "CategoryName");

            return View(product);
        }

        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            var categories = _unitOfWork.Categories.GetAll();
            ViewBag.CategoryList = new SelectList(categories, "CategoryId", "CategoryName");

            var value = _unitOfWork.Products.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            _unitOfWork.Products.Update(product);
            _unitOfWork.Save();
            return RedirectToAction("ProductList");
        }

        public IActionResult DeleteProduct(int id)
        {
            _unitOfWork.Products.Delete(id);
            _unitOfWork.Save();
            return RedirectToAction("ProductList");
        }
    }
}