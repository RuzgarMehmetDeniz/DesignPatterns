using DesignPatterns.ChainOfResponsibility;
using DesignPatterns.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatterns.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(CustomerProcessViewModel model)
        {
            Employee treasurer = new Treasurer();
            Employee manager = new Manager();
            Employee managerAssistant = new ManagerAssistant();
            Employee areaDirector = new AreaDirector();

            treasurer.SetNextApprover(managerAssistant);
            managerAssistant.SetNextApprover(manager);
            manager.SetNextApprover(areaDirector);

            treasurer.ProcessRequest(model);
            return View();
        }
    }
}
