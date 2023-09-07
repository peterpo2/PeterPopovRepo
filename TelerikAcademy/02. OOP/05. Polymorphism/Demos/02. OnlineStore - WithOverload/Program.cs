using OnlineStore_WithOverload.Orders;
using System;

namespace OnlineStore_WithOverload
{
    class Program
    {
        static void Main(string[] args)
        {
            IOrder order1 = new DomesticOrder("John", Currency.BGN, new DateTime(2022, 1, 15));
            order1.AddItem(new Product("Keyboard", 56));
            order1.AddItem(new Product("Monitor", 125));

            IOrder order2 = new DomesticOrder("Peter", Currency.USD, new DateTime(2021, 8, 22));
            order2.AddItem(new Product("Sweater", 25));
            order2.AddItem(new Product("Jeans", 30));

            IOrder order3 = new InternationalOrder("Roger", Currency.USD, new DateTime(2021, 5, 28), "Movers&Shakers", 20);
            order3.AddItem(new Product("Backpack", 16));
            order3.AddItem(new Product("Speakers", 90));
            
            //Domestic AND International orders
            IOrder[] orders = new IOrder[] { order1, order2, order3};
            foreach (var order in orders)
            {
                Console.WriteLine(order.DisplayGeneralInfo());
                Console.WriteLine(order.DisplayOrderItems());
            }
        }
    }
}
