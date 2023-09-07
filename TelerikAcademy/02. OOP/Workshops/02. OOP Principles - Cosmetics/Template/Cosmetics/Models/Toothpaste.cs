using Cosmetics.Models.Enums;
using System;

namespace Cosmetics.Models
{
    public class Toothpaste
    {
        public const int NameMinLength = 3;
        public const int NameMaxLength = 10;
        public const int BrandMinLength = 2;
        public const int BrandManLength = 10;

        public Toothpaste(string name, string brand, decimal price, GenderType gender, string ingredients)
        {
            throw new NotImplementedException("Not implemented yet.");
        }

    }
}
