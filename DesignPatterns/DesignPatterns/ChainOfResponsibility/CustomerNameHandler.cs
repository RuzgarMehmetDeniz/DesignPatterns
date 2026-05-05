namespace DesignPatterns.DesignPatterns.ChainOfResponsibility
{
    public class CustomerNameHandler : OrderHandler
    {
        public override void Handle(int productId, int quantity, decimal userBalance)
        {
            // CustomerProcess içindeki CustomerName kontrolü gibi düşün
            if (quantity <= 0)
            {
                throw new Exception("Geçersiz miktar! En az 1 adet/kg meyve seçmelisiniz.");
            }
            NextHandler?.Handle(productId, quantity, userBalance);
        }
    }
}
