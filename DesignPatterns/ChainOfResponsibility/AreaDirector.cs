using DesignPatterns.Context;
using DesignPatterns.Entites;
using DesignPatterns.Models;

namespace DesignPatterns.ChainOfResponsibility
{
    public class AreaDirector : Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            BankContext context = new BankContext();
            if (req.Amount <= 500000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerName = req.CustomerName;
                customerProcess.EmployeeName = "Bölge Müdürü - Adem Aslan";
                customerProcess.Description = "Para çekme işlemi onaylandı, Müşteri Talep ettiği tutar ödendi";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
            }
            else
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerName = req.CustomerName;
                customerProcess.EmployeeName = "Bölge Müdürü - Adem Aslan";
                customerProcess.Description = "Para çekme işlemi reddedildi, İşlem İçin bir talep kaydı oluşturuldu";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
            }
        }
    }
}
