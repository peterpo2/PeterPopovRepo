using System;
using System.Collections.Generic;
using System.Text;

namespace Cosmetics.Models
{
    public class Category
    {
        public const int NameMinLength = 2;
        public const int NameMaxLength = 15;

        private string name;
        private readonly List<Product> products;

        public Category(string name)
        {
            Name = name;
            products = new List<Product>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value.Length < NameMinLength || value.Length > NameMaxLength)
                {
                    throw new ArgumentException($"Name must be between {NameMinLength} and {NameMaxLength} symbols");
                }
                this.name = value;
            }
        }

        public List<Product> Products
        {
            get
            {
                return new List<Product>(products);
            }
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public void RemoveProduct(Product product)
        {
            if (!products.Contains(product))
            {
                throw new ArgumentException("No such product");
            }
            products.Remove(product);
        }

        public string Print()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"#Category: {Name}");

            if (products.Count == 0)
            {
                result.AppendLine(" #No products in this category.");
            }
            else
            {
                foreach (Product product in products)
                {
                    result.AppendLine(product.Print());
                    result.AppendLine(" ===");
                }
            }

            return result.ToString();
        }
    }
}

