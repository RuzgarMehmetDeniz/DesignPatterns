using DesignPatterns.Entites;

namespace DesignPatterns.DesignPatterns.Decorator
{
    public abstract class ProductDecorator : IProductService
    {
        protected readonly IProductService _innerService;
        public ProductDecorator(IProductService innerService) => _innerService = innerService;

        public virtual List<Product> GetProducts() => _innerService.GetProducts();

        public virtual List<Product> GetPagedProducts(int page, int pageSize)
            => _innerService.GetPagedProducts(page, pageSize);
    }
}
