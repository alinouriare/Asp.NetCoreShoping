using Microsoft.EntityFrameworkCore;
using Shoping.DAL.EF.Configurations;
using Shoping.Domain.Entities;
using System;

namespace Shoping.DAL.EF
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfig());
            base.OnModelCreating(modelBuilder); 
        }
        public DbSet<Product> Products { get; set; }

        public DbSet<Order>  Orders { get; set; }
    }
}
