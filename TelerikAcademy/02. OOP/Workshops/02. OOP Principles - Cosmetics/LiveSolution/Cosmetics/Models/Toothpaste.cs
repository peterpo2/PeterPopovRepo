using Cosmetics.Helpers;
using Cosmetics.Models.Contracts;
using Cosmetics.Models.Enums;
using System;

namespace Cosmetics.Models
{
    public class Toothpaste:Product,IToothpaste
    {
        public const int NameMinLength = 3;
        public const int NameMaxLength = 10;
        public const int BrandMinLength = 2;
        public const int BrandManLength = 10;

        public Toothpaste(string name, string brand, decimal price, GenderType gender, string ingredients)
            :base(name, brand, price, gender)
        {
            ValidationHelper.ValidateStringLength(name, NameMinLength, NameMaxLength);
            ValidationHelper.ValidateStringLength(brand,BrandMinLength, BrandManLength);

            if (String.IsNullOrWhiteSpace(ingredients)) 
            {
                throw new ArgumentNullException("Ingredients cannot be null!");
            }
            this.Ingredients = ingredients;
        }

        public string Ingredients { get; }

        protected override string AdditionalInfo()
        {
            return $" #Ingredients: {this.Ingredients}";
        }
    }
}
