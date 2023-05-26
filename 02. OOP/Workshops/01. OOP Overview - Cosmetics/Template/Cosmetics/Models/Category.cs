using System;
using System.Collections.Generic;

namespace Cosmetics.Models
{
    public class Category
    {
        public const int NameMinLength = 2;
        public const int NameMaxLength = 15;

        public Category(string name)
        {
            throw new NotImplementedException("Not implemented yet.");
        }

        public string Name
        {
            get
            {
                throw new NotImplementedException("Not implemented yet.");
            }
            set
            {
                throw new NotImplementedException("Not implemented yet.");
            }
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

        public string Print()
        {
            throw new NotImplementedException("Not implemented yet.");
        }
    }
}

