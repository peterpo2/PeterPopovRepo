using Cosmetics.Helpers;
using Cosmetics.Models.Contracts;
using Cosmetics.Models.Enums;
using System;

namespace Cosmetics.Models
{
    public class Toothpaste : Product, IToothpaste
    {
        public const int NameMinLength = 3;
        public const int NameMaxLength = 10;
        public const int BrandMinLength = 2;
        public const int BrandManLength = 10;

        private string ingredients;

        public Toothpaste(string name, string brand, decimal price, GenderType gender, string ingredients)
            : base(name, brand, price, gender)
        {
            this.Ingredients = ingredients;
        }

        public string Ingredients
        {
            get
            {
                return this.ingredients;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                this.ingredients = value;
            }
        }

        protected override void ValidateBrand(string brand)
        {
            ValidationHelper.ValidateStringLength(brand, BrandMinLength, BrandManLength);
        }

        protected override void ValidateName(string name)
        {
            ValidationHelper.ValidateStringLength(name, NameMinLength, NameMaxLength);
        }

        protected override void ValidatePrice(decimal price)
        {
            ValidationHelper.ValidateNonNegative(price, "Price");
        }

        protected override string AdditionalInfo()
        {
            return $"#Ingredients: {this.ingredients}";
        }

    }
}
