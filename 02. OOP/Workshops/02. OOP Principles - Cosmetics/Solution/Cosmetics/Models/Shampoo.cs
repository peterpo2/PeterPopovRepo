using Cosmetics.Helpers;
using Cosmetics.Models.Contracts;
using Cosmetics.Models.Enums;
using System.Text;

namespace Cosmetics.Models
{
    public class Shampoo : Product, IShampoo
    {
        public const int NameMinLength = 3;
        public const int NameMaxLength = 10;
        public const int BrandMinLength = 2;
        public const int BrandMaxLength = 10;

        private int millilitres;
        private readonly UsageType usage;

        public Shampoo(string name, string brand, decimal price, GenderType gender, int millilitres, UsageType usage)
            : base(name, brand, price, gender)
        {
            this.Millilitres = millilitres;
            this.usage = usage;
        }

        public int Millilitres
        {
            get
            {
                return this.millilitres;
            }
            private set
            {
                ValidationHelper.ValidateNonNegative(value, "Millilitres");
                this.millilitres = value;
            }
        }

        public UsageType Usage => this.usage;

        protected override void ValidateName(string name)
        {
            ValidationHelper.ValidateStringLength(name, NameMinLength, NameMaxLength);
        }

        protected override void ValidateBrand(string brand)
        {
            ValidationHelper.ValidateStringLength(brand, BrandMinLength, BrandMaxLength);
        }

        protected override void ValidatePrice(decimal price)
        {
            ValidationHelper.ValidateNonNegative(price, "Price");
        }
        protected override string AdditionalInfo()
        {
            var sb = new StringBuilder();
            sb.AppendLine($" #Millilitres: {this.Millilitres}");
            sb.AppendLine($" #Usage: {this.Usage}");
            return sb.ToString().Trim();
        }

    }
}
