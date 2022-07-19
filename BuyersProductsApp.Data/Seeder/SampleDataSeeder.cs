using BuyersProductsApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BuyersProductsApp.Data
{
    public class SampleDataSeeder
    {
        private readonly IAppDbContext db;

        public SampleDataSeeder(IAppDbContext db)
        {
            this.db = db;
        }

        public async Task SeedAll(CancellationToken cancellationToken)
        {
            await SeedBuyers(cancellationToken);
            await SeedProducts(cancellationToken);
            await Purchases(cancellationToken);

        }

        private Task Purchases(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        private async Task SeedProducts(CancellationToken cancellationToken)
        {
            if (db.Products.Any())
                return;

            var products = new List<Product>();

            products.Add(new Product { ProductName = "Скатерть белая", InitPrice = 1000.50m, Price = 1500.99m });
            products.Add(new Product { ProductName = "Стул коричневый", InitPrice = 2000.50m, Price = 2500.99m });
            products.Add(new Product { ProductName = "Стол", InitPrice = 3000.50m, Price = 3500.99m });
            products.Add(new Product { ProductName = "Шкаф угловой", InitPrice = 4000.50m, Price = 4500.99m });
            products.Add(new Product { ProductName = "Кровать односпальная", InitPrice = 5000.50m, Price = 5500.99m });
            products.Add(new Product { ProductName = "Спальный гарнитур бежевый", InitPrice = 6000.50m, Price = 6500.99m });

            foreach (var item in products)
            {
                db.Products.Add(item);
            }

            await db.SaveChangesAsync(cancellationToken);

        }

        private async Task SeedBuyers(CancellationToken cancellationToken)
        {
            if (db.Buyers.Any())
                return;
            Random r = new Random();

            var buyers = new List<Buyer>();

            buyers.Add(new Buyer { Sex = "M", FirstName = "Ivanov", SecondName = "Ivan", MiddleName = "I", BirthDate = new DateTime(r.Next(1975, 2022), r.Next(1, 12), r.Next(1, 28)), IsAgree = true, RegistrationDate = DateTime.Now });
            buyers.Add(new Buyer { Sex = "M", FirstName = "Petrov", SecondName = "Petr", MiddleName = "P", BirthDate = new DateTime(r.Next(1975, 2022), r.Next(1, 12), r.Next(1, 28)), IsAgree = false, RegistrationDate = DateTime.Now });
            buyers.Add(new Buyer { Sex = "M", FirstName = "Sidorov", SecondName = "Sid", MiddleName = "S", BirthDate = new DateTime(r.Next(1975, 2022), r.Next(1, 12), r.Next(1, 28)), IsAgree = true, RegistrationDate = DateTime.Now });
            buyers.Add(new Buyer { Sex = "M", FirstName = "Tarakanov", SecondName = "Tar", MiddleName = "T", BirthDate = new DateTime(r.Next(1975, 2022), r.Next(1, 12), r.Next(1, 28)), IsAgree = true, RegistrationDate = DateTime.Now });
            buyers.Add(new Buyer { Sex = "M", FirstName = "Kuznetson", SecondName = "Stas", MiddleName = "M", BirthDate = new DateTime(r.Next(1975, 2022), r.Next(1, 12), r.Next(1, 28)), IsAgree = false, RegistrationDate = DateTime.Now });
            buyers.Add(new Buyer { Sex = "M", FirstName = "Telephonov", SecondName = "Andrey", MiddleName = "A", BirthDate = new DateTime(r.Next(1975, 2022), r.Next(1, 12), r.Next(1, 28)), IsAgree = true, RegistrationDate = DateTime.Now });
            buyers.Add(new Buyer { Sex = "M", FirstName = "Baranov", SecondName = "Boris", MiddleName = "I", BirthDate = new DateTime(r.Next(1975, 2022), r.Next(1, 12), r.Next(1, 28)), IsAgree = true, RegistrationDate = DateTime.Now });
            buyers.Add(new Buyer { Sex = "M", FirstName = "Kozlov", SecondName = "Alex", MiddleName = "I", BirthDate = new DateTime(r.Next(1975, 2022), r.Next(1, 12), r.Next(1, 28)), IsAgree = false, RegistrationDate = DateTime.Now });
            buyers.Add(new Buyer { Sex = "M", FirstName = "Korovkin", SecondName = "Vovan", MiddleName = "I", BirthDate = new DateTime(r.Next(1975, 2022), r.Next(1, 12), r.Next(1, 28)), IsAgree = true, RegistrationDate = DateTime.Now });
            buyers.Add(new Buyer { Sex = "M", FirstName = "Podushkin", SecondName = "Boban", MiddleName = "I", BirthDate = new DateTime(r.Next(1975, 2022), r.Next(1, 12), r.Next(1, 28)), IsAgree = false, RegistrationDate = DateTime.Now });
            buyers.Add(new Buyer { Sex = "M", FirstName = "Serezhkin", SecondName = "Goran", MiddleName = "I", BirthDate = new DateTime(r.Next(1975, 2022), r.Next(1, 12), r.Next(1, 28)), IsAgree = true, RegistrationDate = DateTime.Now });

            buyers.Add(new Buyer { Sex = "F", FirstName = "Ivanova", SecondName = "Sveta", MiddleName = "I", BirthDate = new DateTime(r.Next(1975, 2022), r.Next(1, 12), r.Next(1, 28)), IsAgree = true, RegistrationDate = DateTime.Now });
            buyers.Add(new Buyer { Sex = "F", FirstName = "Petrova", SecondName = "Olga", MiddleName = "P", BirthDate = new DateTime(r.Next(1975, 2022), r.Next(1, 12), r.Next(1, 28)), IsAgree = false, RegistrationDate = DateTime.Now });
            buyers.Add(new Buyer { Sex = "F", FirstName = "Sidorova", SecondName = "Elena", MiddleName = "S", BirthDate = new DateTime(r.Next(1975, 2022), r.Next(1, 12), r.Next(1, 28)), IsAgree = true, RegistrationDate = DateTime.Now });
            buyers.Add(new Buyer { Sex = "F", FirstName = "Tarakanova", SecondName = "Marina", MiddleName = "T", BirthDate = new DateTime(r.Next(1975, 2022), r.Next(1, 12), r.Next(1, 28)), IsAgree = false, RegistrationDate = DateTime.Now });
            buyers.Add(new Buyer { Sex = "F", FirstName = "Kuznetsova", SecondName = "Olesya", MiddleName = "M", BirthDate = new DateTime(r.Next(1975, 2022), r.Next(1, 12), r.Next(1, 28)), IsAgree = true, RegistrationDate = DateTime.Now });
            buyers.Add(new Buyer { Sex = "F", FirstName = "Telephonova", SecondName = "Nadezhda", MiddleName = "A", BirthDate = new DateTime(r.Next(1975, 2022), r.Next(1, 12), r.Next(1, 28)), IsAgree = true, RegistrationDate = DateTime.Now });
            buyers.Add(new Buyer { Sex = "F", FirstName = "Baranova", SecondName = "Nina", MiddleName = "I", BirthDate = new DateTime(r.Next(1975, 2022), r.Next(1, 12), r.Next(1, 28)), IsAgree = true, RegistrationDate = DateTime.Now });
            buyers.Add(new Buyer { Sex = "F", FirstName = "Kozlova", SecondName = "Alexandra", MiddleName = "I", BirthDate = new DateTime(r.Next(1975, 2022), r.Next(1, 12), r.Next(1, 28)), IsAgree = false, RegistrationDate = DateTime.Now });
            buyers.Add(new Buyer { Sex = "F", FirstName = "Korovkina", SecondName = "Alexa", MiddleName = "I", BirthDate = new DateTime(r.Next(1975, 2022), r.Next(1, 12), r.Next(1, 28)), IsAgree = true, RegistrationDate = DateTime.Now });
            buyers.Add(new Buyer { Sex = "F", FirstName = "Podushkina", SecondName = "Zhasmin", MiddleName = "I", BirthDate = new DateTime(r.Next(1975, 2022), r.Next(1, 12), r.Next(1, 28)), IsAgree = false, RegistrationDate = DateTime.Now });
            buyers.Add(new Buyer { Sex = "F", FirstName = "Serezhkina", SecondName = "Dasha", MiddleName = "I", BirthDate = new DateTime(r.Next(1975, 2022), r.Next(1, 12), r.Next(1, 28)), IsAgree = true, RegistrationDate = DateTime.Now });

            foreach (var item in buyers)
            {
                db.Buyers.Add(item);
            }

            await db.SaveChangesAsync(cancellationToken);
        }
    }
}
