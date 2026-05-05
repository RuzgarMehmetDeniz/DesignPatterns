using DesignPatterns.Entites;

namespace DesignPatterns.DesignPatterns.Observer
{
    public class WelcomeMessageObserver : IObserver
    {
        public void CreateObserver(CustomerProcess process)
        {
            // Burada örneğin veritabanına bir bildirim veya log atılır
            Console.WriteLine($"{process.CustomerName} için yeni bir işlem oluşturuldu: {process.Amount} TL.");
        }
    }
}
