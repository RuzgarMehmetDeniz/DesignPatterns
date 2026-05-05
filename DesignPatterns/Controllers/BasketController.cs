using Microsoft.AspNetCore.Mvc;
using DesignPatterns.DesignPatterns.UnitOfWork;
using DesignPatterns.Models;
using DesignPatterns.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.Controllers
{
    public class BasketController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BasketController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();
            return View(cart);
        }

        public IActionResult AddToCart(int id)
        {
            var cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();
            var cartItem = cart.FirstOrDefault(x => x.ProductId == id);

            if (cartItem != null)
            {
                cartItem.Quantity++;
            }
            else
            {
                var product = _unitOfWork.Products.GetById(id);
                if (product != null)
                {
                    cart.Add(new CartItem
                    {
                        ProductId = id,
                        ProductName = product.Name,
                        Price = product.Price,
                        ImageUrl = product.ImageUrl,
                        Quantity = 1
                    });
                }
            }

            HttpContext.Session.SetJson("Cart", cart);
            return RedirectToAction("Index", "Product");
        }

        // --- EKSİK OLAN METOTLAR BURADAN BAŞLIYOR ---

        public IActionResult IncreaseQuantity(int id)
        {
            var cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");
            var item = cart?.FirstOrDefault(x => x.ProductId == id);

            if (item != null)
            {
                item.Quantity++;
                HttpContext.Session.SetJson("Cart", cart);
            }
            return RedirectToAction("Index"); // Sepet sayfasına geri döner
        }

        public IActionResult DecreaseQuantity(int id)
        {
            var cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");
            var item = cart?.FirstOrDefault(x => x.ProductId == id);

            if (item != null)
            {
                if (item.Quantity > 1)
                {
                    item.Quantity--;
                }
                else
                {
                    cart.Remove(item); // Adet 1 ise ve eksiye basılırsa siler
                }
                HttpContext.Session.SetJson("Cart", cart);
            }
            return RedirectToAction("Index");
        }

        // --- EKSİK OLAN METOTLAR BURADA BİTTİ ---

        public IActionResult RemoveFromCart(int id)
        {
            var cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");
            if (cart != null)
            {
                var item = cart.FirstOrDefault(x => x.ProductId == id);
                if (item != null)
                {
                    cart.Remove(item);
                }
                HttpContext.Session.SetJson("Cart", cart);
            }
            return RedirectToAction("Index");
        }
    }
}