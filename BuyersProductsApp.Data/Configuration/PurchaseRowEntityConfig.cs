using BuyersProductsApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace BuyersProductsApp.Data.Configuration
{
    public class PurchaseRowEntityConfig : IEntityTypeConfiguration<PurchaseRow>
    {
        public void Configure(EntityTypeBuilder<PurchaseRow> builder)
        {
            builder.HasKey(x => x.RecId);
        }
    }
}
