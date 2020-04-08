using CrmBl.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //var customer = new Customer()
            //{
            //    CustomerId = 1,
            //    Name = "testuser"
            //};
            //var product1 = new Product()
            //{
            //    ProductId = 1,
            //    Name = "prod1",
            //    Price = 100,
            //    Count = 10
            //};
            //var product2 = new Product()
            //{
            //    ProductId = 2,
            //    Name = "prod2",
            //    Price = 200,
            //    Count = 20
            //};
            //var cart = new Cart(customer);
            //cart.Add(product1);
            //cart.Add(product1);
            //cart.Add(product2);

            //var actualresult = cart.GetAll();
            //foreach (var item in cart.Products)
            //{
            //    Console.WriteLine(item.Key.Count);
            //}

            var shop = new ShopComputerModel();
           
            shop.Start();
            Console.ReadLine();

        }
    }
}
