using Microsoft.AspNetCore.Mvc;
using DesignPatterns.DesignPatterns.UnitOfWork;
using DesignPatterns.Models; // CartItem burada
using DesignPatterns.Extensions; // GetJson ve SetJson burada
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

        // Sepet Sayfası
        public IActionResult Index()
        {
            // Session'dan mevcut sepeti oku, yoksa boş liste oluştur
            var cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();
            return View(cart);
        }

        // Sepete Ürün Ekle
        public IActionResult AddToCart(int id)
        {
            // 1. Session'daki mevcut sepeti al
            var cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            // 2. Bu ürün sepette zaten var mı kontrol et
            var cartItem = cart.FirstOrDefault(x => x.ProductId == id);

            if (cartItem != null)
            {
                // Ürün varsa miktarını artır
                cartItem.Quantity++;
            }
            else
            {
                // Ürün yoksa veritabanından çek ve listeye ekle
                var product = _unitOfWork.Products.GetById(id);

                if (product != null)
                {
                    cart.Add(new CartItem
                    {
                        ProductId = id,
                        ProductName = product.Name, // Entity'deki isimle aynı olmalı
                        Price = product.Price,
                        Quantity = 1
                    });
                }
            }

            // 3. Güncel listeyi Session'a geri yaz
            HttpContext.Session.SetJson("Cart", cart);

            // Ürün eklendikten sonra sepet sayfasına yönlendir
            return RedirectToAction("Index");
        }

        // Sepetten Ürün Sil
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