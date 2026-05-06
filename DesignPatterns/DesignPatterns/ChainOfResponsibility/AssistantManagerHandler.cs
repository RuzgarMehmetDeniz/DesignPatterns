namespace DesignPatterns.DesignPatterns.ChainOfResponsibility
{
    public class AssistantManagerHandler : OrderHandler
    {
        public override string ProcessRequest(decimal amount)
        {
            if (amount > 500 && amount <= 1000)
            {
                return "Müdür Yardımcısı Selin";
            }
            return NextHandler?.ProcessRequest(amount) ?? "Onay Bekleniyor";
        }
    }
}