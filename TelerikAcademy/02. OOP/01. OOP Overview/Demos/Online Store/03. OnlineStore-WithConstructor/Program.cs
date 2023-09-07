using System;

namespace Order_WithConstructor
{
    class Program
    {
        static void Main(string[] args)
        {
            Order order1 = new Order(
                "John",
                450,
                "USD",
                new DateTime(2022, 1, 15),
                new string[] { "PC", "Keyboard", "Monitor" }
            );

            Order order2 = new Order(
                "Peter",
                95,
                "BGN",
                new DateTime(2021, 8, 22),
                new string[] { "Sweater", "Jeans" }
            );

            Order[] orders = new Order[] { order1, order2 };
            foreach (var order in orders)
            {
                Console.WriteLine($"To be delivered on: {order.deliveryOn.ToShortDateString()}");
                Console.WriteLine("Items:");
                foreach (var item in order.items)
                {
                    Console.WriteLine($"  {item}");
                }
                Console.WriteLine();
            }
        }
    }

    class Order
    {
        public string recipient;
        public decimal total;
        public string currency;
        public DateTime deliveryOn;
        public string[] items;

        public Order(string recipient, decimal total, string currency, DateTime deliveryOn, string[] items)
        {
            this.recipient = recipient;
            this.total = total;
            this.currency = currency;
            this.deliveryOn = deliveryOn;
            this.items = items;
        }
    }
}
