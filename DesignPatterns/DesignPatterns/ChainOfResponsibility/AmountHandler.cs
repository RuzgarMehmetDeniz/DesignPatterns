namespace DesignPatterns.DesignPatterns.ChainOfResponsibility
{
    public class AmountHandler : OrderHandler
    {

        public override void Handle(int productId, int quantity, decimal userBalance)
        {
            // Örnek: Tek seferde 5000 TL üzerinde meyve alımı için özel onay gereksin
            if (quantity * 100 > 5000) // Temsili hesaplama
            {
                throw new Exception("Yüksek tutarlı işlem! Lütfen müşteri hizmetleri ile görüşün.");
            }
            NextHandler?.Handle(productId, quantity, userBalance);
        }
    }
}
