using Cosmetics.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cosmetics.Models
{
    public class ShoppingCart : IShoppingCart
    {
        private const string ProductNotFoundErrorMessage = "Shopping cart does not contain product with name {0}!";

        private readonly ICollection<IProduct> products;

        public ShoppingCart()
        {
            this.products = new List<IProduct>();
        }

        public ICollection<IProduct> Products
        {
            get { return new List<IProduct>(this.products); }
        }

        public void AddProduct(IProduct product)
        {
            this.products.Add(product);
        }

        public void RemoveProduct(IProduct product)
        {
            if (!ContainsProduct(product))
            {
                throw new ArgumentException(string.Format(ProductNotFoundErrorMessage, product.Name));
            }
            this.products.Remove(product);
        }

        public bool ContainsProduct(IProduct product)
        {
            return this.products.Any(x => x.Name == product.Name);
        }

        public decimal TotalPrice()
        {
            return this.products.Sum(x => x.Price);
        }
    }
}
