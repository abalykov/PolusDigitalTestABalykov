using BuyersProductsApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace BuyersProductsApp.Data.Configuration
{
    public class PurchaseEntityConfig : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder.HasKey(x => x.RecId);
            builder.HasMany(x => x.PurchaseRows).WithOne(x => x.Purchase);
        }
    }
}
