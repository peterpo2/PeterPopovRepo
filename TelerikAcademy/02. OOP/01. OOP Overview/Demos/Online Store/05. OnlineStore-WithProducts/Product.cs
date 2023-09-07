using System;

namespace Order_WithProducts
{
    public class Product
    {
        public string name;
        public decimal price;
        public Currency currency;

        public Product(string name, decimal price)
        {
            this.name = name;
            this.price = price;
            this.currency = Currency.USD; // default currency for all products
        }

        public string DisplayInfo()
        {
            return $"{this.name} - {this.price} {this.currency}";
        }
    }
}
