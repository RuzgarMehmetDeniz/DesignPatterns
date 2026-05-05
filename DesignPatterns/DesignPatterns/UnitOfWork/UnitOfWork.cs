using DesignPatterns.Context;
using DesignPatterns.Entites;
using DesignPatterns.Repository;
using Microsoft.EntityFrameworkCore;

namespace DesignPatterns.DesignPatterns.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BankContext _context;

        public UnitOfWork(BankContext context)
        {
            _context = context;
            AboutSections = new GenericRepository<AboutSection>(_context);
            Banners = new GenericRepository<Banner>(_context);
            Blogs = new GenericRepository<Blog>(_context);
            Brands = new GenericRepository<Brand>(_context);
            Categories = new GenericRepository<Category>(_context);
            CustomerProcesses = new GenericRepository<CustomerProcess>(_context);
            Products = new GenericRepository<Product>(_context);
            Qualities = new GenericRepository<Quality>(_context);
            Sales = new GenericRepository<Sale>(_context);
            Services = new GenericRepository<Service>(_context);
            SocialMedias = new GenericRepository<SocialMedia>(_context);
            Testimonials = new GenericRepository<Testimonial>(_context);
            Trends = new GenericRepository<Trend>(_context);
        }

        public IGenericRepository<AboutSection> AboutSections { get; private set; }
        public IGenericRepository<Banner> Banners { get; private set; }
        public IGenericRepository<Blog> Blogs { get; private set; }
        public IGenericRepository<Brand> Brands { get; private set; }
        public IGenericRepository<Category> Categories { get; private set; }
        public IGenericRepository<CustomerProcess> CustomerProcesses { get; private set; }
        public IGenericRepository<Product> Products { get; private set; }
        public IGenericRepository<Quality> Qualities { get; private set; }
        public IGenericRepository<Sale> Sales { get; private set; }
        public IGenericRepository<Service> Services { get; private set; }
        public IGenericRepository<SocialMedia> SocialMedias { get; private set; }
        public IGenericRepository<Testimonial> Testimonials { get; private set; }
        public IGenericRepository<Trend> Trends { get; private set; }

        public int Save() => _context.SaveChanges();
        public void Dispose() => _context.Dispose();
    }
}
