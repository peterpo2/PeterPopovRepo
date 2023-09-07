using System;

namespace Order_NoClass
{
    class Program
    {
        static void Main(string[] args)
        {
            var orders = new[]
            {
                new {
                    Recipient = "John",
                    Items = new string [] { "PC", "Keyboard", "Monitor" },
                    DeliveryOn = "15 Jan 2022",
                    Total = 450,
                    Currency = "USD"
                },
                new {
                    Recipient = "Peter",
                    Items = new string [] { "Sweater", "Jeans" },
                    DeliveryOn = "25 Aug 2021",
                    Total = 95,
                    Currency = "BGN"
                },
            };

            foreach (var order in orders)
            {
                Console.WriteLine($"To be delivered on: {order.DeliveryOn} for {order.Recipient}");
            }
        }
    }
}
