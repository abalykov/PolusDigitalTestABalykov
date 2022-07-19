using BuyersProductsApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace BuyersProductsApp.Data.Configuration
{
    public class ProductEntityConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.RecId);
            builder.HasMany(x => x.PurchaseRows).WithOne(x => x.Product);
        }
    }
}
