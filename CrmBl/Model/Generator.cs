using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmBl.Model
{
    public class Generator
    {
       // public List<Cart> Carts { get; set; }
       // public List<CashDesk> CashDesk { get; set; }
       // public List<Check> Checks { get; set; }
        public List<Customer> Customers { get; set; }
        public List<Product> Products { get; set; }
       // public List<Sell> Sells { get; set; }
        public List<Seller> Sellers { get; set; }

        Random rnd = new Random();

        public Generator()
        {
            Customers = new List<Customer>();
            Products = new List<Product>();
            Sellers = new List<Seller>();
        }
        public List<Customer> GetNewCustomers(int count)
        {
            var result = new List<Customer>();

            for (int i = 0; i < count; i++)
            {
                var customer = new Customer()
                {
                    CustomerId = Customers.Count,
                    Name = GetRandomText()
                };
                Customers.Add(customer);
                result.Add(customer);
            }
            return result;
        }


        public List<Seller> GetNewSellers(int count)
        {
            var result = new List<Seller>();

            for (int i = 0; i < count; i++)
            {
                var seller = new Seller()
                {
                    SellerId = Sellers.Count,
                    Name = GetRandomText()
                };
                Sellers.Add(seller);
                result.Add(seller);
            }
            return result;
        }


        public List<Product> GetNewProducts(int count)
        {
            var result = new List<Product>();

            for (int i = 0; i < count; i++)
            {
                var product = new Product()
                {
                    ProductId = Products.Count,
                    Name = GetRandomText(),
                    Count = rnd.Next(10, 1000),
                    Price = Convert.ToDecimal(rnd.Next(5, 100000) + rnd.NextDouble())
                };
                Products.Add(product);
                result.Add(product);
            }
            return result;
        }

        // Получение случайных продуктов в количестве в соответствии с заданным диапазоном
        public List<Product> GetRandomProducts(int min, int max)
        {
            var result = new List<Product>();

            var count = rnd.Next(min, max);
            for (int i = 0; i < count; i++)
            {
                result.Add(Products[rnd.Next(Products.Count - 1)]);
            }
            return result;
        }

        public static string GetRandomText()
        {
            return Guid.NewGuid().ToString().Substring(0, 5);
        
        }
    }
}
