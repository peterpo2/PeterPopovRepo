using System;

namespace OnlineStore_WithMultipleOrders
{
    class Program
    {
        static void Main(string[] args)
        {
            Order order1 = new Order("John", Currency.BGN, new DateTime(2022, 1, 15));
            order1.AddItem(new Product("Keyboard", 56));
            order1.AddItem(new Product("Monitor", 125));

            Order order2 = new Order("Peter", Currency.USD, new DateTime(2021, 8, 22));
            order2.AddItem(new Product("Sweater", 25));
            order2.AddItem(new Product("Jeans", 30));

            InternationalOrder order3 = new InternationalOrder("Roger", Currency.USD, new DateTime(2021, 5, 28), "Movers&Shakers", 20);
            order3.AddItem(new Product("Backpack", 16));
            order3.AddItem(new Product("Speakers", 90));
            
            //Domestic orders
            Order[] orders = new Order[] { order1, order2, order3};
            foreach (var order in orders)
            {
                Console.WriteLine(order.DisplayGeneralInfo());
                Console.WriteLine(order.DisplayOrderItems());
            }

            //International orders
            InternationalOrder[] orders2 = new InternationalOrder[] { order3 };
            foreach (var order in orders2)
            {
                Console.WriteLine(order.DisplayGeneralInfo());
                Console.WriteLine(order.DisplayOrderItems());
            }
        }
    }
}
