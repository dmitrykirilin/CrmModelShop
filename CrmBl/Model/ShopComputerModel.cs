using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmBl.Model
{
    public class ShopComputerModel
    {
        Generator Generator = new Generator();
        Random rnd = new Random();

        public List<Cart> Carts { get; set; } = new List<Cart>();
        public List<CashDesk> CashDesks { get; set; } = new List<CashDesk>();
        public List<Check> Checks { get; set; } = new List<Check>();
        public List<Sell> Sells { get; set; } = new List<Sell>();
        public Queue<Seller> Sellers { get; set; } = new Queue<Seller>();

        public ShopComputerModel()
        {
            var sellers = Generator.GetNewSellers(20);
            foreach (var seller in sellers)
            {
                Sellers.Enqueue(seller);
            }
            for (int i = 0; i < 3; i++)
            {
                CashDesks.Add(new CashDesk(CashDesks.Count, Sellers.Dequeue()));
            }
        }

        public void Start()
        {
            var customers = Generator.GetNewCustomers(20);
            var products = Generator.GetNewProducts(1000);
            var carts = new List<Cart>();
            
            // Добавление товаров в корзины покупателей
            foreach (var customer in customers)
            {
                carts.Add(new Cart(customer));
            }
            foreach (var cart in carts)
            {
                products = Generator.GetRandomProducts(1, 30);
                foreach (var product in products)
                {
                    cart.Add(product);
                }
            }
            var cartsNum = carts.Count;
            Console.WriteLine("всего корзин с покупками: " + cartsNum);

            // Расставление покупателей (корзин) по кассам.
            while (carts.Count > 0)
            {
                var cashDesk = CashDesks[rnd.Next(CashDesks.Count - 1)]; // TODO:

                cashDesk.Queue.Enqueue(carts[0]);
                carts.RemoveAt(0);
            }

            // Совершение покупки, выход из очереди, создание продажи и чека.
            while (cartsNum > 0)
            {
                var cashDesk = CashDesks[rnd.Next(CashDesks.Count - 1)];
                if (cashDesk.Queue.Count > 0)
                {
                    var money = cashDesk.Dequeue();
                    cartsNum--;
                    Console.WriteLine(money);
                }
                else
                {
                    continue;
                }
            }
        }
    }
}
