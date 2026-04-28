using DesignPatterns.Context;
using DesignPatterns.Entites;
using DesignPatterns.Models;

namespace DesignPatterns.ChainOfResponsibility
{
    public class ManagerAssistant : Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            BankContext context = new BankContext();
            if (req.Amount <= 200000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerName = req.CustomerName;
                customerProcess.EmployeeName = "Müdür Yardımcısı - Ahmet Yılmaz";
                customerProcess.Description = "Para çekme işlemi onaylandı, Müşteri Talep ettiği tutar ödendi";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
            }
            else if (NextApprover != null)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerName = req.CustomerName;
                customerProcess.EmployeeName = "Müdür Yardımcısı - Ahmet Yılmaz";
                customerProcess.Description = "Para çekme işlemi onaylanamadı,İşlem şube müdürüne yönlendirdi";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
                NextApprover.ProcessRequest(req);
            }
        }
    }
}
