using DesignPatterns.Context;
using DesignPatterns.Entites;
using DesignPatterns.Models;

namespace DesignPatterns.ChainOfResponsibility
{
    public class Manager : Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            BankContext context = new BankContext();
            if (req.Amount <= 350000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerName = req.CustomerName;
                customerProcess.EmployeeName = "Şube Müdürü - Fırat Kaya";
                customerProcess.Description = "Para çekme işlemi onaylandı, Müşteri Talep ettiği tutar ödendi";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
            }
            else if (NextApprover != null)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerName = req.CustomerName;
                customerProcess.EmployeeName = "Şube Müdürü - Fırat Kaya";
                customerProcess.Description = "Para çekme işlemi onaylanamadı,İşlem Bölge Müdürüne yönlendirdi";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
                NextApprover.ProcessRequest(req);
            }
        }
    }
}
