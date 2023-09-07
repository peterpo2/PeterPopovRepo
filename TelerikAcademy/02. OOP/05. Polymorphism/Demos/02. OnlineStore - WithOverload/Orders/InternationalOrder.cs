using OnlineStore_WithOverload;
using OnlineStore_WithOverload.Orders;
using OnlineStore_WithOverload.Orders.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore_WithOverload
{
    class InternationalOrder : Order, IOrder
    {
        public InternationalOrder(string recipient, Currency currency, DateTime deliveryOn, string carrier, int customsPercentage) 
            : base(recipient, currency, deliveryOn)
        {
            this.Carrier = carrier;
            this.CustomsPercentage = customsPercentage;
        }

        public string Carrier { get; private set; }
        public int CustomsPercentage { get; private set; }

        public override string DisplayGeneralInfo()
        {
            string dateFormat = this.DisplayDeliveryDate();

            return $"International order to {base.Recipient} | Delivery on: {dateFormat} | Total: {this.DisplayPrice()} | Carrier: {this.Carrier} | *NOTE* - customs of {this.CustomsPercentage}% expected but to be calculated on arrival";
        }

        public override void AddItem(Product item)
        {
            if (items.Count > 5)
            {
                throw new InvalidOperationException("International orders are limited to 5 products per order");
            }
            if (items.Contains(item))
            {
                throw new InvalidOperationException("This item is already in this order");
            }

            items.Add(item);
        }
    }
}
