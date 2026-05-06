using DesignPatterns.Entites;

namespace DesignPatterns.DesignPatterns.Decorator
{
    public interface IProductService
    {
        List<Product> GetProducts(); // Tümünü getir
        List<Product> GetPagedProducts(int page, int pageSize); // Sayfalı getir
    }
}
