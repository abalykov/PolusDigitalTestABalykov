namespace BuyersProductsApp.Data.Entities
{
    // Строка покупки
    public class PurchaseRow
    {
        public long RecId { get; set; }

        // Идентификатор покупки
        public long PurchaseId { get; set; }

        // Идентификатор продукта
        public long ProductId { get; set; }

        // Кол-во 
        public int Count { get; set; }

        // Цена
        public decimal Price { get; set; }

        // Итоговая сумма покупки
        public decimal Summ { get; set; }


        public virtual Purchase Purchase { get; set; }
        public virtual Product Product { get; set; }
    }
}
