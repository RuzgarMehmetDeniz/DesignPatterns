using DesignPatterns.DesignPatterns.Observer;
using DesignPatterns.DesignPatterns.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatterns.Controllers
{
    public class ObserverController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ObserverObject _observerObject;

        public ObserverController(IUnitOfWork unitOfWork, ObserverObject observerObject)
        {
            _unitOfWork = unitOfWork;
            _observerObject = observerObject;
        }

        [HttpGet]
        public IActionResult NotifyCustomer()
        {
            // Müşteri işlemlerini listele
            var processes = _unitOfWork.CustomerProcesses.GetAll();
            return View(processes);
        }

        [HttpPost]
        public IActionResult NotifyCustomer(int id)
        {
            // 1. Veritabanından ilgili süreci getir
            var process = _unitOfWork.CustomerProcesses.GetById(id);

            if (process != null)
            {
                // 2. Program.cs'de kayıtlı olan tüm Observer'ları (Welcome, Discount vb.) tetikle
                _observerObject.NotifyObservers(process);

                // 3. Kullanıcıya bilgi mesajı gönder
                TempData["Message"] = $"{process.CustomerName} için indirim ve hoş geldin bildirimleri başarıyla iletildi.";
            }
            else
            {
                TempData["Error"] = "İşlem kaydı bulunamadı.";
            }

            // Kendi GET metoduna (listeye) geri dön
            return RedirectToAction("NotifyCustomer");
        }
    }
}