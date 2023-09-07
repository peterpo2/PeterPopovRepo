﻿using System;

namespace OnlineStore_WithOverload
{
    public class Product
    {
        private string name;
        private decimal price;
        private readonly Currency currency = Currency.USD;

        public Product(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name
        {
            get => this.name;
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
            get => this.price;
            private set
            {
                if (value <= 0.00m)
                {
                    throw new ArgumentOutOfRangeException("Product price must be positive");
                }
                this.price = value;
            }
        }

        public Currency Currency
        {
            get => this.currency; 
        }

        public string DisplayInfo()
        {
            return $"{this.name} - {this.price} {this.currency}";
        }
    }
}