using DesignPatterns.Context;
using DesignPatterns.DesignPatterns.Decorator;
using DesignPatterns.DesignPatterns.Decorator.DesignPatterns.DesignPatterns.Decorator;
using DesignPatterns.Entites;
using DesignPatterns.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.Controllers
{
    public class DecoratorController : Controller
    {
        private readonly BankContext _context;

        public DecoratorController(BankContext context)
        {
            _context = context;
        }

        // 1. ÜRÜN LİSTELEME (Index)
        // Dikkat: Bu View '@model List<DesignPatterns.Entites.Product>' beklemeli.
        public IActionResult Index(int page = 1)
        {
            int pageSize = 6;
            IProductService myService = new SqlProductService(_context);

            // İndirim dekoratörünü kullanarak ürün fiyatlarını manipüle ediyoruz
            myService = new DiscountDecorator(myService);

            var products = myService.GetPagedProducts(page, pageSize);

            ViewBag.CurrentPage = page;
            return View(products);
        }

        // 2. SEPET DETAY SAYFASI (CartIndex)
        // Dikkat: Bu View '@model List<DesignPatterns.Models.CartItem>' beklemeli.
        public IActionResult CartIndex()
        {
            // Decorator yapımızla session'ı sarmalıyoruz
            var sessionWrapper = new JsonSessionDecorator(new StandardSession(HttpContext.Session));

            var cart = sessionWrapper.GetObject<List<CartItem>>("Cart") ?? new List<CartItem>();

            return View(cart);
        }

        // 3. SEPETE EKLEME (AddToCart)
        public IActionResult AddToCart(int id)
        {
            var sessionWrapper = new JsonSessionDecorator(new StandardSession(HttpContext.Session));
            var cart = sessionWrapper.GetObject<List<CartItem>>("Cart") ?? new List<CartItem>();

            var cartItem = cart.FirstOrDefault(x => x.ProductId == id);

            if (cartItem != null)
            {
                cartItem.Quantity++;
            }
            else
            {
                // Veritabanından ürünü buluyoruz
                var product = _context.Products.Find(id);
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

            sessionWrapper.SetObject("Cart", cart);

            // Ürün eklendikten sonra doğrudan sepet detayına gitmesi için Redirect
            return RedirectToAction("CartIndex");
        }

        // 4. MİKTAR ARTIRMA (+)
        public IActionResult IncreaseQuantity(int id)
        {
            var sessionWrapper = new JsonSessionDecorator(new StandardSession(HttpContext.Session));
            var cart = sessionWrapper.GetObject<List<CartItem>>("Cart");
            var item = cart?.FirstOrDefault(x => x.ProductId == id);

            if (item != null)
            {
                item.Quantity++;
                sessionWrapper.SetObject("Cart", cart);
            }
            return RedirectToAction("CartIndex");
        }

        // 5. MİKTAR AZALTMA (-)
        public IActionResult DecreaseQuantity(int id)
        {
            var sessionWrapper = new JsonSessionDecorator(new StandardSession(HttpContext.Session));
            var cart = sessionWrapper.GetObject<List<CartItem>>("Cart");
            var item = cart?.FirstOrDefault(x => x.ProductId == id);

            if (item != null)
            {
                if (item.Quantity > 1)
                    item.Quantity--;
                else
                    cart.Remove(item);

                sessionWrapper.SetObject("Cart", cart);
            }
            return RedirectToAction("CartIndex");
        }

        // 6. SEPETTEN SİLME
        public IActionResult RemoveFromCart(int id)
        {
            var sessionWrapper = new JsonSessionDecorator(new StandardSession(HttpContext.Session));
            var cart = sessionWrapper.GetObject<List<CartItem>>("Cart");
            var item = cart?.FirstOrDefault(x => x.ProductId == id);

            if (item != null)
            {
                cart.Remove(item);
                sessionWrapper.SetObject("Cart", cart);
            }
            return RedirectToAction("CartIndex");
        }
    }
}