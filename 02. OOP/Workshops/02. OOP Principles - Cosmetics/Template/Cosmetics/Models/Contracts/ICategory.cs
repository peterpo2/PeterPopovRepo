using System.Collections.Generic;

namespace Cosmetics.Models.Contracts
{
    public interface ICategory
    {
        string Name { get; }
        ICollection<IProduct> Products { get; }

        void AddProduct(IProduct product);

        void RemoveProduct(IProduct product);

        string Print();
    }
}
