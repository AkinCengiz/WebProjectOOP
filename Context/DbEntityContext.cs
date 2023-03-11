using Microsoft.EntityFrameworkCore;
using WebProjectOOP.Entities;

namespace WebProjectOOP.Context
{
    public class DbEntityContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-U0NLI58\\MSSQLSERVER01; database=DbNewOopCore;integrated security=true; TrustServerCertificate=True");
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
