using DesignPatterns.Context;
using DesignPatterns.Entites;
using DesignPatterns.Models;

namespace DesignPatterns.ChainOfResponsibility
{
    public class Treasurer : Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            BankContext context = new BankContext();
            if (req.Amount <= 80000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerName = req.CustomerName;
                customerProcess.EmployeeName = "Veznedar - Murat Kılıç";
                customerProcess.Description = "Para çekme işlemi onaylandı, Müşteri Talep ettiği tutar ödendi";
            }
            else if (NextApprover != null)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerName = req.CustomerName;
                customerProcess.EmployeeName = "Veznedar - Murat Kılıç";
                customerProcess.Description = "Para çekme işlemi onaylanamadı,İşlem şube müdür yardımcısına yönlendirdi";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
                NextApprover.ProcessRequest(req);
            }
        }
    }
}
