using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore_WithMultipleOrders
{
    class Order
    {
        private string recipient;
        private Currency currency;
        private DateTime deliveryOn;
        private readonly List<Product> items;

        public Order(string recipient, Currency currency, DateTime deliveryOn)
        {
            this.Recipient = recipient;
            this.Currency = currency;
            this.DeliveryOn = deliveryOn;
            this.items = new List<Product>();
        }

        public string Recipient
        {
            get => this.recipient;
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Recipient cannot be empty");
                }
                if (value.Length < 3 || value.Length > 35)
                {
                    throw new ArgumentOutOfRangeException("Recipient name must be between 3 and 35 characters");
                }
                this.recipient = value;
            }
        }

        public Currency Currency
        {
            get => this.currency;
            private set => this.currency = value;
        }


        public DateTime DeliveryOn
        {
            get => this.deliveryOn;
            private set => this.deliveryOn = value;
        }

        public void AddItem(Product item)
        {
            if (items.Contains(item))
            {
                throw new InvalidOperationException("This item is already in this order");
            }

            items.Add(item);
        }

        public decimal CalculateTotalPrice()
        {
            decimal total = 0;
            foreach (var item in items)
            {
                total += item.Price;
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
            string dateFormat = this.DisplayDeliveryDate();

            return $"Order to {this.recipient} | Delivery on: {dateFormat} | Total: {this.DisplayPrice()}";
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
