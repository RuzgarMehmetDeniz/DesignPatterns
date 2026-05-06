namespace DesignPatterns.DesignPatterns.ChainOfResponsibility
{
    public class ManagerHandler : OrderHandler
    {
        public override string ProcessRequest(decimal amount)
        {
            if (amount > 1000 && amount <= 1500)
            {
                return "Ahmet Müdür"; // İstediğin Ahmet Müdür senaryosu
            }
            return NextHandler?.ProcessRequest(amount) ?? "Onay Bekleniyor";
        }
    }
}