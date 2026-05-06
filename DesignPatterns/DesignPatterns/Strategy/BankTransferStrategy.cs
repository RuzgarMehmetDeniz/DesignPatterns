namespace DesignPatterns.DesignPatterns.Strategy
{
    public class BankTransferStrategy : IOrderStrategy
    {
        public string ProcessOrder(decimal amount) => $"Havale/EFT için {amount:C2} tutarında ödeme kaydı oluşturuldu. Onay bekleniyor.";
    }
}
