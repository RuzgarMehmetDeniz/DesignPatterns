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

        [HttpGet]
        public IActionResult Index()
        {
            // Unit of Work üzerinden tüm işlemleri listele
            var values = _unitOfWork.CustomerProcesses.GetAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddProcess()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProcess(CustomerProcess customerProcess)
        {
            try
            {
                // 1. Chain of Responsibility Halkalarını Tanımla
                var amountHandler = new AmountHandler();
                var nameHandler = new CustomerNameHandler();

                // 2. Zinciri Birbirine Bağla
                // Önce tutar kontrolü, sonra isim/miktar kontrolü
                amountHandler.SetNextHandler(nameHandler);

                // 3. Zinciri Başlat 
                // (Senin sınıfındaki Amount ve CustomerName verilerini gönderiyoruz)
                amountHandler.Handle(0, (int)customerProcess.Amount, 0);

                // 4. Eğer zincirde hata fırlatılmadıysa veriyi kaydet
                _unitOfWork.CustomerProcesses.Add(customerProcess);

                // Unit of Work ile tüm değişiklikleri veritabanına mühürle
                _unitOfWork.Save();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Zincirdeki herhangi bir halkada (Handler) hata oluşursa mesajı yakala
                ModelState.AddModelError("", ex.Message);
                return View(customerProcess);
            }
        }

        public IActionResult DeleteProcess(int id)
        {
            _unitOfWork.CustomerProcesses.Delete(id);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}