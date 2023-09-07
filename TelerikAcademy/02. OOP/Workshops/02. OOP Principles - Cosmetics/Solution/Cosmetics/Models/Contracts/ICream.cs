using Cosmetics.Models.Enums;

namespace Cosmetics.Models.Contracts
{
    public interface ICream : IProduct
    {
        ScentType Scent { get; }
    }
}
