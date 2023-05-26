using Cosmetics.Models.Enums;
using System;

namespace Cosmetics.Models
{
    public class Shampoo
    {
        public const int NameMinLength = 3;
        public const int NameMaxLength = 10;
        public const int BrandMinLength = 2;
        public const int BrandManLength = 10;

        public Shampoo(string name, string brand, decimal price, GenderType gender, int millilitres, UsageType usage)
        {
            throw new NotImplementedException("Not implemented yet.");
        }

    }
}
