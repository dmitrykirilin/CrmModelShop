using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmBl.Model
{
    public class CashDesk
    {
        CrmContext db = new CrmContext();

        public int Number { get; set; }

        public Seller Seller { get; set; }

        public Queue<Cart> Queue { get; set; }

        public List<List<Sell>> AllSells { get; set; }

        public int MaxQueueLenght { get; set; } = 10;

        public int ExitCustomer { get; set; }

        public bool IsModel { get; set; }

        public int Count => Queue.Count;


        public CashDesk(int number, Seller seller)
        {
            Number = number;
            Seller = seller;
            Queue = new Queue<Cart>();
            IsModel = true;
        }

        public void Enqueue(Cart cart)
        {
            if (Queue.Count <= MaxQueueLenght)
            {
                Queue.Enqueue(cart);
            }
            else
            {
                ExitCustomer++;
            }
        }

        public decimal Dequeue()
        {
            decimal sum = 0;
            if (Queue.Count == 0)
            {
                return 0;
            }
            var cart = Queue.Dequeue();

            if (cart != null)
            {
                var check = new Check()
                {
                    SellerId = Seller.SellerId,
                    Seller = Seller,
                    CustomerId = cart.Customer.CustomerId,
                    Customer = cart.Customer,
                    Created = DateTime.Now
                };

                if (!IsModel)
                {
                    db.Checks.Add(check);
                    db.SaveChanges();
                }
                else
                {
                    check.CheckId = 0;
                }

                var sells = new List<Sell>();

                foreach (Product product in cart)
                {
                    if (product.Count > 0)
                    {
                        var sell = new Sell()
                        {
                            CheckId = check.CheckId,
                            Check = check,
                            Product = product,
                            ProductId = product.ProductId
                        };

                        sells.Add(sell);

                        if (!IsModel)
                        {
                            db.Sells.Add(sell);
                        }

                        product.Count--;
                        sum += product.Price;
                    }
                    
                }

                if (!IsModel)
                {
                    db.SaveChanges();
                }
                //AllSells.Add(sells);
            }

            return sum;
        }
        
    }
}
