using Cosmetics.Helpers;
using Cosmetics.Models.Contracts;
using Cosmetics.Models.Enums;

namespace Cosmetics.Models
{
    public class Cream : Product, ICream
    {
        public const int NameMinLength = 3;
        public const int NameMaxLength = 15;
        public const int BrandMinLength = 3;
        public const int BrandManLength = 15;

        private readonly ScentType scent;

        public Cream(string name, string brand, decimal price, GenderType gender, ScentType scent)
            : base(name, brand, price, gender)
        {
            this.scent = scent;
        }

        public ScentType Scent => this.scent;

        protected override void ValidateName(string name)
        {
            ValidationHelper.ValidateStringLength(name, NameMinLength, NameMaxLength);
        }

        protected override void ValidateBrand(string brand)
        {
            ValidationHelper.ValidateStringLength(brand, BrandMinLength, BrandManLength);
        }

        protected override void ValidatePrice(decimal price)
        {
            ValidationHelper.ValidateNonNegative(price, "Price");
        }

        protected override string AdditionalInfo()
        {
            return $"#Scent: {this.Scent}";
        }
    }
}
