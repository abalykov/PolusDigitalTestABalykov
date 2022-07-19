using BuyersProductsApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace BuyersProductsApp.Data.Configuration
{
    public class BuyerEntityConfig : IEntityTypeConfiguration<Buyer>
    {
        public void Configure(EntityTypeBuilder<Buyer> builder)
        {
            builder.HasKey(x => x.RecId);
            builder.HasMany(x => x.Purchases).WithOne(x => x.Buyer);
        }
    }
}
