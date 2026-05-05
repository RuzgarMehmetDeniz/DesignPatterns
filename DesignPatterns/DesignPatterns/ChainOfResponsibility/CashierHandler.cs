namespace DesignPatterns.DesignPatterns.ChainOfResponsibility
{
    public class CashierHandler : OrderHandler
    {
        public override void Handle(Entites.CustomerProcess process)
        {
            if (process.Amount <= 100)
            {
                process.EmployeeName = "Kasiyer - Ahmet Yılmaz";
                process.Description = "İşlem tutarı limit dahilinde olduğu için kasiyer tarafından onaylandı.";
            }
            else if (NextHandler != null)
            {
                NextHandler.Handle(process);
            }
        }
    }
}