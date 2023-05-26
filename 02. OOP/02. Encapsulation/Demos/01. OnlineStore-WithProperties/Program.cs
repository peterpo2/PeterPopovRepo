using System;

namespace OnlineStore_WithProperties
{
    class Program
    {
        static void Main(string[] args)
        {
            Order order1 = new Order("John", Currency.BGN, new DateTime(2022, 1, 15));
            order1.items.Add(new Product("Keyboard", 56));
            order1.items.Add(new Product("Monitor", 125));

            Order order2 = new Order("Peter", Currency.USD, new DateTime(2021, 8, 22));
            order2.items.Add(new Product("Sweater", 25));
            order2.items.Add(new Product("Jeans", 30));

            Order[] orders = new Order[] { order1, order2 };
            foreach (var order in orders)
            {
                Console.WriteLine(order.DisplayGeneralInfo());
                Console.WriteLine(order.DisplayOrderItems());
            }
        }
    }
}
