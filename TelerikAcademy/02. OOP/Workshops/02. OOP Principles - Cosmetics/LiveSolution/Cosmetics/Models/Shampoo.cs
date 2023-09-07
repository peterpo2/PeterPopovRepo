using Cosmetics.Helpers;
using Cosmetics.Models.Contracts;
using Cosmetics.Models.Enums;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Cosmetics.Models
{
    public class Shampoo:Product,IShampoo
    {
        public const int NameMinLength = 3;
        public const int NameMaxLength = 10;
        public const int BrandMinLength = 2;
        public const int BrandManLength = 10;

        public Shampoo(string name, string brand, decimal price, GenderType gender, int millilitres, UsageType usage)
            :base(name,brand,price,gender)
        {
            ValidationHelper.ValidateNonNegative(millilitres, "millilitres");
            ValidationHelper.ValidateStringLength(name,NameMinLength,NameMaxLength);
            ValidationHelper.ValidateStringLength(brand,BrandMinLength,BrandManLength);

            this.Millilitres = millilitres;
            this.Usage = usage;
        }

        public int Millilitres { get; }

        public UsageType Usage { get; }

        protected override string AdditionalInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($" #Millilitres: {this.Millilitres}");
            sb.Append($" #Usage type: {this.Usage}");
            return sb.ToString();
        }
    }
}
