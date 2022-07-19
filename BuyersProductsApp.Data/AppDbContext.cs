using BuyersProductsApp.Data.Entities;
using BuyersProductsApp.Data.Entities.Projections;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading;
using System.Threading.Tasks;

namespace BuyersProductsApp.Data
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchaseRow> PurchaseRows { get; set; }

        ///// <summary>
        ///// Проекции данных - например для отчетов
        ///// </summary>
        //[NotMapped]        
        
        //public DbSet<SomeReportProjection> SomeReports { get; set; }


        public new EntityEntry<T> Entry<T>(T item) where T: class
        {
            return base.Entry(item);
        }

        public DbSet<T> Set<T>(T item) where T : class
        {
            return base.Set<T>();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            // Зарегистрируем типы наших проекций
            modelBuilder.Entity(typeof(SomeReportProjection)).HasNoKey();
        }
    }
}
