using System.Collections.Generic;

namespace Cosmetics.Models.Contracts
{
    public interface IShoppingCart
    {
        ICollection<IProduct> Products { get; }

        void AddProduct(IProduct product);

        void RemoveProduct(IProduct product);

        bool ContainsProduct(IProduct product);

        decimal TotalPrice();
    }
}