using System;
using System.Collections.Generic;

namespace BuyersProductsApp.Data.Entities
{
    /// <summary>
    /// Покупки 
    /// </summary>
    public class Purchase
    {
        public Purchase()
        {
            PurchaseRows = new HashSet<PurchaseRow>();
        }

        public long RecId { get; set; }

        // Идентификатор покупателя
        public long BuyerId { get; set; }

        // Дата покупки
        public DateTime PurchaseDate { get; set; }


        public virtual Buyer Buyer { get; set; }

        public virtual ICollection<PurchaseRow> PurchaseRows { get; set; }
    }
}
