namespace DesignPatterns.DesignPatterns.Strategy
{
    public interface IOrderStrategy
    {
        // Her ödeme yöntemi kendi onay mesajını veya işlem sonucunu döner
        string ProcessOrder(decimal amount);
    }
}
