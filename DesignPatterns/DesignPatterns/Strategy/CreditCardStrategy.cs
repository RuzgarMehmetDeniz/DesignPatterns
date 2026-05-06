namespace DesignPatterns.DesignPatterns.Strategy
{
    public class CreditCardStrategy : IOrderStrategy
    {
        public string ProcessOrder(decimal amount) => $"Kredi kartı ile {amount:C2} tutarında güvenli ödeme alındı.";
    }
}
