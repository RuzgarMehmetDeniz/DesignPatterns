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

        [HttpPost]
        public IActionResult AddProcess(CustomerProcess customerProcess)
        {
            // 1. Zincirin Halkalarını Tanımla
            var cashier = new CashierHandler();
            var assistant = new AssistantManagerHandler();
            var manager = new ManagerHandler();
            var regionalManager = new RegionalManagerHandler();

            // 2. Hiyerarşiyi Mantıksal Sırayla Bağla (Tutar limitlerine göre)
            // Kasiyer (500) -> Asistan (1000) -> Müdür (1500) -> Bölge Müdürü (1500+)
            cashier.SetNextHandler(assistant);
            assistant.SetNextHandler(manager);
            manager.SetNextHandler(regionalManager);

            try
            {
                // 3. Zinciri Başlat 
                // DİKKAT: Metot adını 'ProcessRequest' olarak güncelledik (Hata veren yer burasıydı)
                // customerProcess.Amount değerine göre EmployeeName içeride dolacak
                string approverName = cashier.ProcessRequest(customerProcess.Amount);

                // Atanan ismi entity'ye set et
                customerProcess.EmployeeName = approverName;

                // 4. Veriyi Kaydet
                _unitOfWork.CustomerProcesses.Add(customerProcess);

                // Unit of Work ile Save Et
                _unitOfWork.Save();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Zincirde bir hata oluşursa (örneğin limit aşımı) yakala
                ModelState.AddModelError("", ex.Message);
                return View(customerProcess);
            }
        }
    }
}