using System;
using System.Collections.Generic;

namespace Cosmetics.Models
{
    public class ShoppingCart
    {
        private readonly List<Product> products;

        public ShoppingCart()
        {
            throw new NotImplementedException("Not implemented yet.");
        }

        public List<Product> Products
        {
            get
            {
                // List encapsulation is tricky.
                throw new NotImplementedException("Not implemented yet.");
            }
        }

        public void AddProduct(Product product)
        {
            throw new NotImplementedException("Not implemented yet.");
        }

        public void RemoveProduct(Product product)
        {
            throw new NotImplementedException("Not implemented yet.");
        }

        public bool ContainsProduct(Product product)
        {
            throw new NotImplementedException("Not implemented yet.");
        }

        public double TotalPrice()
        {
            throw new NotImplementedException("Not implemented yet.");
        }
    }
}
