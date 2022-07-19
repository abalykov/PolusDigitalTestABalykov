using BuyersProductsApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading;
using System.Threading.Tasks;

namespace BuyersProductsApp.Data
{
    public interface IAppDbContext
    {
        DbSet<Buyer> Buyers { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<PurchaseRow> PurchaseRows { get; set; }
        DbSet<Purchase> Purchases { get; set; }


        Task<int> SaveChangesAsync(CancellationToken cancelationToken = default);

        EntityEntry<T> Entry<T>(T item) where T : class;
    }
}