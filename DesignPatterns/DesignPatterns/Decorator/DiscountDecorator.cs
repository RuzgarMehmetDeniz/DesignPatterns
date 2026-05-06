using DesignPatterns.Entites;

namespace DesignPatterns.DesignPatterns.Decorator
{
    public class DiscountDecorator : ProductDecorator
    {
        public DiscountDecorator(IProductService innerService) : base(innerService) { }

        public override List<Product> GetProducts()
        {
            var products = base.GetProducts();
            foreach (var item in products)
            {
                item.Price *= 0.9m; // SQL'den gelen fiyata %10 indirim uygula
                item.Name += " (%10 İndirimli)";
            }
            return products;
        }
    }
}
