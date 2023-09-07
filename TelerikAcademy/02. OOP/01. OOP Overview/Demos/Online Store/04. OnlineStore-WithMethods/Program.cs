using System;
using System.Text;

namespace Order_WithMethods
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
                Console.WriteLine(order.DisplayGeneralInfo());
                Console.WriteLine(order.DisplayOrderItems());
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

            public string DisplayPrice()
            {
                return $"{this.total} {this.currency}";
            }

            public string DisplayDeliveryDate()
            {
                return this.deliveryOn.ToShortDateString();
            }

            public string DisplayGeneralInfo()
            {
                string deliveryDateInfo = this.DisplayDeliveryDate();
                string priceInfo = this.DisplayPrice();

                return $"Order to {this.recipient} | Delivery on: {deliveryDateInfo} | Total: {priceInfo}";
            }

            public string DisplayOrderItems()
            {
                if (this.items.Length == 0)
                {
                    return "No items";
                }

                var sb = new StringBuilder();
                foreach (var item in this.items)
                {
                    sb.AppendLine($"  {item}");
                }

                return sb.ToString();
            }
        }
    }
}
