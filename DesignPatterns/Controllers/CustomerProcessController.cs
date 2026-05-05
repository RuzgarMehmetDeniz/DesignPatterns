using Microsoft.AspNetCore.Mvc;
using DesignPatterns.Entites;
using DesignPatterns.DesignPatterns.UnitOfWork;
using DesignPatterns.DesignPatterns.ChainOfResponsibility;

namespace DesignPatterns.Controllers
{
    public class CustomerProcessController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerProcessController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Dinamik Veri Yönetim Paneli - Listeleme Sayfası
        [HttpGet]
        public IActionResult Index()
        {
            var values = _unitOfWork.CustomerProcesses.GetAll();
            return View(values);
        }

        // Yeni İşlem Ekleme Sayfası (Görünüm)
        [HttpGet]
        public IActionResult AddProcess()
        {
            return View();
        }

        // Yeni İşlem Ekleme (İşlem ve Zincir Tetikleme)
        [HttpPost]
        public IActionResult AddProcess(CustomerProcess customerProcess)
        {
            // 1. Zincirin Halkalarını Tanımla
            var cashier = new CashierHandler();
            var manager = new ManagerHandler();
            var assistant = new AssistantManagerHandler();
            var regionalManager = new RegionalManagerHandler();

            // 2. Hiyerarşiyi Birbirine Bağla (Kasiyer -> Müdür -> Asistan -> Bölge Müdürü)
            cashier.SetNextHandler(manager);
            manager.SetNextHandler(assistant);
            assistant.SetNextHandler(regionalManager);

            try
            {
                // 3. Zinciri Başlat (Tüm nesneyi gönderiyoruz)
                // Bu metot içinde EmployeeName ve Description otomatik dolacak
                cashier.Handle(customerProcess);

                // 4. Eğer hiçbir hata (Exception) fırlatılmadıysa veriyi kaydet
                _unitOfWork.CustomerProcesses.Add(customerProcess);

                // Unit of Work ile veritabanına mühürle
                _unitOfWork.Save();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Zincirde bir engel çıkarsa (Örn: 10.000 TL üzeri tutar) hatayı yakala
                ModelState.AddModelError("", ex.Message);
                return View(customerProcess);
            }
        }
    }
}