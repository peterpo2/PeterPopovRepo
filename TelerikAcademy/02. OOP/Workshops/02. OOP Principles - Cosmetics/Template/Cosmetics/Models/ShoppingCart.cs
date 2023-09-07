using Cosmetics.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cosmetics.Models
{
    public class ShoppingCart : IShoppingCart
    {
        private const string ProductNotFoundErrorMessage = "Shopping cart does not contain product with name {0}!";

        private readonly ICollection<IProduct> productList;

        public ShoppingCart()
        {
            this.productList = new List<IProduct>();
        }

        public ICollection<IProduct> Products
        {
            get { return new List<IProduct>(this.productList); }
        }

        public void AddProduct(IProduct product)
        {
            this.productList.Add(product);
        }

        public void RemoveProduct(IProduct product)
        {
            if (!ContainsProduct(product))
            {
                throw new ArgumentException(string.Format(ProductNotFoundErrorMessage, product.Name));
            }
            this.productList.Remove(product);
        }

        public bool ContainsProduct(IProduct product)
        {
            return this.productList.Any(x => x.Name == product.Name);
        }

        public decimal TotalPrice()
        {
            return this.productList.Sum(x => x.Price);
        }
    }
}
