using Microsoft.VisualStudio.TestTools.UnitTesting;
using CrmBl.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmBl.Model.Tests
{
    [TestClass()]
    public class CashDeskTests
    {
        [TestMethod()]
        public void CashDeskTest()
        {
            // Arrange
            var customer1 = new Customer()
            {
                CustomerId = 1,
                Name = "testuser"
            };
            var customer2 = new Customer()
            {
                CustomerId = 2,
                Name = "testuser"
            };

            var seller = new Seller()
            {
                SellerId = 1,
                Name = "sellername"
            };

            var product1 = new Product()
            {
                ProductId = 1,
                Name = "prod1",
                Price = 100,
                Count = 10
            };
            var product2 = new Product()
            {
                ProductId = 2,
                Name = "prod2",
                Price = 200,
                Count = 20
            };

            var cart1 = new Cart(customer1);
            cart1.Add(product1);
            cart1.Add(product1);
            cart1.Add(product2);

            var cart2 = new Cart(customer2);
            cart2.Add(product1);
            cart2.Add(product2);
            cart2.Add(product2);

            var cashDesk = new CashDesk(1, seller);
            var cart1ExpectedResult = 400;
            var cart2ExpectedResult = 500;
            //decimal expectedSum = 0;
            //foreach (Product product in cart)
            //{
            //    expectedSum += product.Price;
            //}

            //Act
            cashDesk.Enqueue(cart1);
            cashDesk.Enqueue(cart2);
            var actual1Sum = cashDesk.Dequeue();
            var actual2Sum = cashDesk.Dequeue();

            //Assert
            //Сравнение суммы цен товаров и и суммы чека.
            Assert.AreEqual(cart1ExpectedResult, actual1Sum);
            Assert.AreEqual(cart2ExpectedResult, actual2Sum);
            Assert.AreEqual(7, product1.Count);
            Assert.AreEqual(17, product2.Count);

            //Сравнение продуктов в корзине и в чеке.
            //for (int i = 0; i < cart.GetAll().Count; i++)
            //{
            //    Assert.AreEqual(cart.GetAll()[i], cashDesk.AllSells[0][i].Product);
            //}
        }
        
    }
}