namespace DesignPatterns.DesignPatterns.ChainOfResponsibility
{
    public class CashierHandler : OrderHandler
    {
        public override string ProcessRequest(decimal amount)
        {
            if (amount <= 500)
            {
                return "Kasiyer Mehmet";
            }
            return NextHandler?.ProcessRequest(amount) ?? "Onay Bekleniyor";
        }
    }
}