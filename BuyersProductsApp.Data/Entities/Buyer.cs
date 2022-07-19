using System;
using System.Collections.Generic;

namespace BuyersProductsApp.Data.Entities
{
    /// <summary>
    /// Покупатель
    /// </summary>
    public class Buyer
    {
        public Buyer()
        {
            Purchases = new HashSet<Purchase>();
        }

        public long RecId { get; set; }

        /// <summary>
        /// ФИО
        /// </summary>
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string MiddleName { get; set; }

        // Дата рождения
        public DateTime? BirthDate { get; set; }

        // Пол
        public string Sex { get; set; }

        // Дата регистрации
        public DateTime RegistrationDate { get; set; }

        // согласие на обработку ПД
        public bool IsAgree { get; set; }

        // Фото
        public byte[] Photo { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; }

    }
}
