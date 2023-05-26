using System;

namespace OnlineStore_WithOverload.Orders
{
    interface IOrder
    {
        public string Recipient { get; }
        public Currency Currency { get; }
        DateTime DeliveryOn { get; }

        void AddItem(Product item);
        decimal CalculateTotalPrice();
        string DisplayPrice();
        string DisplayDeliveryDate();
        string DisplayGeneralInfo();
        string DisplayOrderItems();
        Product FindProduct(string productName);
        Product FindProduct(decimal price);
    }
}