using System;

namespace OnlineStore_WithPrivateFields
{
    public class Product
    {
        private string name;
        private decimal price;
        private readonly Currency currency = Currency.USD; // default currency for all products

        public Product(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Name cannot be empty");
                }
                if (value.Length < 2 || value.Length > 15)
                {
                    throw new ArgumentOutOfRangeException("Product name must be between 2 and 15 characters");
                }
                this.name = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            private set
            {
                if (value <= 0.00m)
                {
                    throw new ArgumentOutOfRangeException("Product price must be positive");
                }
                this.price = value;
            }
        }

        public Currency Currency // no setter needed - currency is a always default value
        {
            get
            {
                return this.currency;
            }
        }

        public string DisplayInfo()
        {
            return $"{this.name} - {this.price} {this.currency}";
        }
    }
}
