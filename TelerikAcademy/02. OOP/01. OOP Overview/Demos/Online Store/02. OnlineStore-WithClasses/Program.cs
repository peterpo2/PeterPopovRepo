using System;

namespace Orders_WithClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            Order order1 = new Order();
            order1.recipient = "John";
            order1.items = new string[] { "PC", "Keyboard", "Monitor" };
            order1.deliveryOn = new DateTime(2022, 1, 15);
            order1.total = 450;
            order1.currency = "USD";

            Order order2 = new Order();
            order2.recipient = "Peter";
            order2.items = new string[] { "Sweater", "Jeans" };
            order2.total = 95;
            order2.currency = "BGN";

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
    }
}
