using System;
using System.Collections.Generic;
using System.Text;

namespace BuyersProductsApp.Data.Entities.Projections
{
    public class SomeReportProjection: IDbProjection
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string MiddleName { get; set; }

        public decimal PurchaseSum { get; set; }
    }
}
