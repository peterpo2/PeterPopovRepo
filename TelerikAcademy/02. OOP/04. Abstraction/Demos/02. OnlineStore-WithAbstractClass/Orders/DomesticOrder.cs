using OnlineStore_WithAbstractClass.Orders;
using OnlineStore_WithAbstractClass.Orders.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore_WithAbstractClass
{
    class DomesticOrder : Order, IOrder
    {
        public DomesticOrder(string recipient, Currency currency, DateTime deliveryOn) 
            : base(recipient, currency, deliveryOn)
        {
        }

        public override string DisplayGeneralInfo()
        {
            string dateFormat = this.DisplayDeliveryDate();

            return $"Domestic order to {base.Recipient} | Delivery on: {dateFormat} | Total: {this.DisplayPrice()} | Carrier: Domestic";
        }
    }
}
