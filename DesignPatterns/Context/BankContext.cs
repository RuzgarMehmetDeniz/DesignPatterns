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
    }
}
