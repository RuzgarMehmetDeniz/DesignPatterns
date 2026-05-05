namespace DesignPatterns.DesignPatterns.ChainOfResponsibility
{
    public class AssistantManagerHandler : OrderHandler
    {
        public override void Handle(Entites.CustomerProcess process)
        {
            if (process.Amount <= 5000)
            {
                process.EmployeeName = "Bölge Asistanı - Mehmet Rüzgar";
                process.Description = "Yüksek tutarlı işlem için Bölge Asistanı onayı alındı.";
            }
            else if (NextHandler != null)
            {
                NextHandler.Handle(process);
            }
        }
    }
}