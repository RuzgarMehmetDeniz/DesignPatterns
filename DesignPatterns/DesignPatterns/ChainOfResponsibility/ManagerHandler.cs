namespace DesignPatterns.DesignPatterns.ChainOfResponsibility
{
    public class ManagerHandler : OrderHandler
    {
        public override void Handle(Entites.CustomerProcess process)
        {
            if (process.Amount <= 1000)
            {
                process.EmployeeName = "Mağaza Müdürü - Selin Aydın";
                process.Description = "100 TL üzeri işlem Mağaza Müdürü onayıyla gerçekleştirildi.";
            }
            else if (NextHandler != null)
            {
                NextHandler.Handle(process);
            }
        }
    }
}