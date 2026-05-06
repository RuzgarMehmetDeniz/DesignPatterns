using DesignPatterns.Context;
using DesignPatterns.Entites;
using System;

namespace DesignPatterns.DesignPatterns.Decorator
{
    public class SqlProductService : IProductService
    {
        private readonly BankContext _context;

        public SqlProductService(BankContext context)
        {
            _context = context;
        }

        public List<Product> GetProducts() => _context.Products.ToList();

        public List<Product> GetPagedProducts(int page, int pageSize)
        {
            // Sayfa 1 ise 0 atla, 10 al. Sayfa 2 ise 10 atla, 10 al.
            return _context.Products
                           .OrderBy(x => x.ProductId)
                           .Skip((page - 1) * pageSize)
                           .Take(pageSize)
                           .ToList();
        }
    }
}