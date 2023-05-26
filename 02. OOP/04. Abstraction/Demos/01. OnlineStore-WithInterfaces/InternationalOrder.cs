using OnlineStore_WithInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore_WithInterfaces
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

        public new string DisplayGeneralInfo()
        {
            string dateFormat = this.DisplayDeliveryDate();

            return $"International order to {this.Recipient} | Delivery on: {dateFormat} | Total: {this.DisplayPrice()} | Carrier: {this.Carrier} | *NOTE* - customs of {this.CustomsPercentage}% expected but to be calculated on arrival.";
        }
    }
}
