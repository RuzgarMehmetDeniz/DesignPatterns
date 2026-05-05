using DesignPatterns.Entites;
using DesignPatterns.Repository;

namespace DesignPatterns.DesignPatterns.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<AboutSection> AboutSections { get; }
        IGenericRepository<Banner> Banners { get; }
        IGenericRepository<Blog> Blogs { get; }
        IGenericRepository<Brand> Brands { get; }
        IGenericRepository<Category> Categories { get; }
        IGenericRepository<CustomerProcess> CustomerProcesses { get; }
        IGenericRepository<Product> Products { get; }
        IGenericRepository<Quality> Qualities { get; }
        IGenericRepository<Sale> Sales { get; }
        IGenericRepository<Service> Services { get; }
        IGenericRepository<SocialMedia> SocialMedias { get; }
        IGenericRepository<Testimonial> Testimonials { get; }
        IGenericRepository<Trend> Trends { get; }

        int Save();
    }
}
