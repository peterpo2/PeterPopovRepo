using OnlineStore_WithAbstractClass;
using OnlineStore_WithAbstractClass.Orders;
using OnlineStore_WithAbstractClass.Orders.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore_WithAbstractClass
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

    }
}
