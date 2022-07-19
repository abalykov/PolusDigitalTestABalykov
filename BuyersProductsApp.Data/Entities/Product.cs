using System.Collections.Generic;
using System.Text;

namespace BuyersProductsApp.Data.Entities
{
    /// <summary>
    /// Продукт
    /// </summary>
    public class Product
    {
        public Product()
        {
            PurchaseRows = new HashSet<PurchaseRow>();
        }

        public long RecId { get; set; }

        public string ProductName { get; set; }

        // Цена закупки
        public decimal InitPrice { get; set; }

        // Цена продажи
        public decimal Price { get; set; }


        public virtual ICollection<PurchaseRow> PurchaseRows { get; set; }
    }
}
