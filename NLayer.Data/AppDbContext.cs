using Microsoft.EntityFrameworkCore;
using NLayer.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Data
{
    public class AppDbContext : DbContext
    {
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        //eğer birden çok connectionstring olursa bunu yazmalısın. Multi-Tenant
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        //{
        //    base.OnConfiguring(optionsBuilder);
        //}
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)//migration her yaptığında buradaki metot çalışır.
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
