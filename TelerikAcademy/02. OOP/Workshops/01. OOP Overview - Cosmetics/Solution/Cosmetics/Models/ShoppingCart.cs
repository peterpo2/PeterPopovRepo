using System;
using System.Collections.Generic;

namespace Cosmetics.Models
{
    public class ShoppingCart
    {
        private readonly List<Product> products;

        public ShoppingCart()
        {
            products = new List<Product>();
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
            if (!products.Remove(product))
            {
                throw new ArgumentException($"Product {product.Name} not found.");
            }

            /*if (!ContainsProduct(product))
            {
                throw new ArgumentException($"Product {product.Name} not found.");
            }
            products.Remove(product);*/
        }

        public bool ContainsProduct(Product product)
        {
            /*foreach (Product item in products)
            {
                if (item == product)
                {
                    return true;
                }
            }

            return false;*/

            return products.Contains(product);
        }

        public double TotalPrice()
        {
            double totalPrice = 0;

            foreach (Product item in products)
            {
                totalPrice += item.Price;
            }

            return totalPrice;
        }
    }
}
