using DesignPatterns.Entites;
using Microsoft.EntityFrameworkCore;

namespace DesignPatterns.Context
{
    public class BankContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=NıTRO-AN515-57;initial Catalog=DesignPatternChainDb;TrustServerCertificate=True;Integrated Security=True");
        }
        public DbSet<CustomerProcess> CustomerProcesses { get; set; }
        public DbSet<AboutSection> AboutSections { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Quality> Qualities { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Trend> Trends { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}
