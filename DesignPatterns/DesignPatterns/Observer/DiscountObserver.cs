using DesignPatterns.Entites;

namespace DesignPatterns.DesignPatterns.Observer
{
    public class DiscountObserver : IObserver
    {
        public void CreateObserver(CustomerProcess process)
        {
            // Buradaki mantık: Eğer işlem tipi "İndirim" ise müşteriye haber ver
            // Şimdilik simüle ediyoruz:
            Console.WriteLine($"BİLGİLENDİRME: Sayın {process.CustomerName}, takip ettiğiniz ürünün fiyatı {process.Amount} TL olarak güncellendi! Kaçırmayın.");
        }
    }
}