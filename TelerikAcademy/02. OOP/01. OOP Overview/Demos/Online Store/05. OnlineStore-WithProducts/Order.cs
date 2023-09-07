using System;
using System.Collections.Generic;
using System.Text;

namespace Order_WithProducts
{
    class Order
    {
        public string recipient;
        public Currency currency;
        public DateTime deliveryOn;
        public List<Product> items;

        public Order(string recipient, Currency currency, DateTime deliveryOn)
        {
            this.recipient = recipient;
            this.currency = currency;
            this.deliveryOn = deliveryOn;
            this.items = new List<Product>();
        }

        public decimal CalculateTotalPrice()
        {
            decimal total = 0;
            foreach (var item in items)
            {
                total += item.price;
            }

            if (this.currency == Currency.BGN)
            {
                total = total * 1.75m;
            }

            return total;
        }

        public string DisplayPrice()
        {
            return $"{this.CalculateTotalPrice()} {this.currency}";
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
            if (this.items.Count == 0)
            {
                return "No items";
            }

            StringBuilder sb = new StringBuilder();
            foreach (Product item in this.items)
            {
                sb.AppendLine($"  {item.DisplayInfo()}");
            }

            return sb.ToString();
        }
    }
}
