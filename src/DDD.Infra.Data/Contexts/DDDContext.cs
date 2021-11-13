using DDD.Domain.Entities;
using DDD.Infra.Data.EntityConfig;
using Microsoft.EntityFrameworkCore;

namespace DDD.Infra.Data.Contexts
{
    public class DDDContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }

        public DDDContext(DbContextOptions<DDDContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) { 
            modelBuilder.ApplyConfiguration(new CustomerDbConfig());    
            modelBuilder.ApplyConfiguration(new ProductDbConfig());    
        }
    }
}
