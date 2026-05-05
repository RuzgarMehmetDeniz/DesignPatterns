using DesignPatterns.DesignPatterns.Observer;
using DesignPatterns.DesignPatterns.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

public class ObserverController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public ObserverController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
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
        // 1. Veritabanından işlemi bul (Unit of Work kullanarak)
        var process = _unitOfWork.CustomerProcesses.GetById(id);

        if (process != null)
        {
            // 2. Observer sistemini ayağa kaldır
            var observerObject = new ObserverObject();

            // Gözlemcileri kayıt et
            observerObject.RegisterObserver(new WelcomeMessageObserver());
            // İstersen buraya yeni gözlemciler ekleyebilirsin:
            // observerObject.RegisterObserver(new SmsObserver());

            // 3. Haberi uçur!
            observerObject.NotifyObservers(process);

            TempData["Message"] = $"{process.CustomerName} için bildirimler gönderildi.";
        }

        return RedirectToAction("Index", "CustomerProcess");
    }
}