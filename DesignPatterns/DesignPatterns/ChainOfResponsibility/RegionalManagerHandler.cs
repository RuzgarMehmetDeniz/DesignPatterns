namespace DesignPatterns.DesignPatterns.ChainOfResponsibility
{
    public class RegionalManagerHandler : OrderHandler
    {
        public override string ProcessRequest(decimal amount)
        {
            if (amount > 1500)
            {
                return "Bölge Müdürü Caner";
            }
            return NextHandler?.ProcessRequest(amount) ?? "Onay Bekleniyor";
        }
    }
}