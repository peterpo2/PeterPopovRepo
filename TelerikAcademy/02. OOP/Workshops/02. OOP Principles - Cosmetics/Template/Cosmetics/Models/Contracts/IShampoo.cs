using Cosmetics.Models.Enums;

namespace Cosmetics.Models.Contracts
{
    public interface IShampoo
    {
        int Millilitres { get; }

        UsageType Usage { get; }
    }
}