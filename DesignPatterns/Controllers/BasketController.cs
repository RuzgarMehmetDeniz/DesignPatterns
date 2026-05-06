using DesignPatterns.DesignPatterns.ChainOfResponsibility;
using DesignPatterns.DesignPatterns.Observer;
using DesignPatterns.DesignPatterns.Strategy;
using DesignPatterns.DesignPatterns.UnitOfWork;
using DesignPatterns.Entites;
using DesignPatterns.Extensions;
using DesignPatterns.Models;
using Microsoft.AspNetCore.Mvc;
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
        [HttpGet]
        public IActionResult Checkout()
        {
            var cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            if (!cart.Any())
            {
                return RedirectToAction("Index", "Product");
            }

            var model = new CheckoutViewModel
            {
                CartItems = cart
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Checkout(CheckoutViewModel model, string paymentType)
        {
            // 1. Session üzerinden mevcut sepeti alıyoruz
            var cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");

            if (cart == null || !cart.Any())
            {
                return RedirectToAction("Index", "Product");
            }

            // 2. Toplam tutarı hesaplıyoruz
            decimal totalAmount = cart.Sum(x => x.Price * x.Quantity);

            // ---------------------------------------------------------
            // 3. STRATEGY PATTERN: Ödeme Yöntemini Belirle
            // ---------------------------------------------------------
            var orderContext = new OrderContext();

            if (paymentType == "CreditCard")
            {
                orderContext.SetStrategy(new CreditCardStrategy());
            }
            else
            {
                orderContext.SetStrategy(new BankTransferStrategy());
            }

            string paymentStatus = orderContext.Execute(totalAmount);

            // ---------------------------------------------------------
            // 4. CHAIN OF RESPONSIBILITY: Yetkili Atamasını Yap
            // ---------------------------------------------------------
            var cashier = new CashierHandler();
            var assistantManager = new AssistantManagerHandler();
            var manager = new ManagerHandler();
            var regionalManager = new RegionalManagerHandler();

            cashier.SetNextHandler(assistantManager);
            assistantManager.SetNextHandler(manager);
            manager.SetNextHandler(regionalManager);

            string assignedEmployee = cashier.ProcessRequest(totalAmount);

            // ---------------------------------------------------------
            // 5. MÜŞTERİ İŞLEMİ (ENTITY) HAZIRLAMA
            // ---------------------------------------------------------
            var process = new CustomerProcess
            {
                CustomerName = model.FullName,
                Amount = totalAmount,
                EmployeeName = assignedEmployee,
                Description = $"{paymentStatus} | Ürünler: " + string.Join(", ", cart.Select(x => $"{x.ProductName} ({x.Quantity} Adet)"))
            };

            // ---------------------------------------------------------
            // 6. UNIT OF WORK: Veritabanı İşlemleri
            // ---------------------------------------------------------
            _unitOfWork.CustomerProcesses.Add(process);
            _unitOfWork.Save(); // Önce kaydetmeliyiz ki ID oluşsun ve Observer'a dolu gitsin

            // ---------------------------------------------------------
            // 7. OBSERVER PATTERN: Bildirimleri Uçur! [yeni eklenen]
            // ---------------------------------------------------------
            var observerObject = new ObserverObject();

            // Kayıtlı olan gözlemcileri listeye ekle
            observerObject.RegisterObserver(new WelcomeMessageObserver());

            // İleride SmsObserver veya LogObserver yazarsan buraya tek satır eklersin
            // observerObject.RegisterObserver(new LogObserver());

            // Tüm gözlemcilere "işlem tamamlandı" haberini ver
            observerObject.NotifyObservers(process);

            // ---------------------------------------------------------
            // 8. TEMİZLİK VE YÖNLENDİRME
            // ---------------------------------------------------------
            HttpContext.Session.Remove("Cart");
            TempData["Message"] = "Siparişiniz başarıyla alındı ve birimlere iletildi.";

            return RedirectToAction("OrderComplete");
        }
        public IActionResult OrderComplete()
        {
            return View();
        }
    }
}