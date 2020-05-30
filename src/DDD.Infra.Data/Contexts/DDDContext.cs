using DDD.Domain.Entities;
using DDD.Infra.Data.EntityConfig;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Infra.Data.Contexts
{
    public class DDDContext : DbContext
    {
        public DbSet<Customer> Customers { get; }
        public DbSet<Product> Products { get; }

        public DDDContext(DbContextOptions<DDDContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) { 
            modelBuilder.ApplyConfiguration(new CustomerDbConfig());    
            modelBuilder.ApplyConfiguration(new ProductDbConfig());    
        }
    }
}
