using CosmeticsShop.Exceptions;

using System.Collections.Generic;
using System.Text;

namespace CosmeticsShop.Models
{
    public class Category
    {
        private string name;
        private readonly List<Product> products;

        public Category(string name)
        {
            this.Name = name;
            this.products = new List<Product>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value.Length < 3 || value.Length > 10)
                {
                    throw new InvalidUserInputException("Category name should be between 3 and 10 symbols.");
                }
                this.name = value;
            }
        }

        public List<Product> Products
        {
            get
            {
                // return a copy
                return new List<Product>(this.products);
            }
        }

        public void AddProduct(Product product)
        {
            this.products.Add(product);
        }

        public void RemoveProduct(Product product)
        {
            this.products.Remove(product);
        }

        public string Print()
        {
            var strBuilder = new StringBuilder();
            strBuilder.AppendLine($"#Category: {this.name}");

            if (this.products.Count == 0)
            {
                strBuilder.AppendLine(" #No products in this category");
                return strBuilder.ToString().Trim();
            }

            foreach (Product product in this.products)
            {
                strBuilder.AppendLine(product.Print());
                strBuilder.AppendLine(" ===");
            }

            return strBuilder.ToString().Trim();
        }
    }
}
