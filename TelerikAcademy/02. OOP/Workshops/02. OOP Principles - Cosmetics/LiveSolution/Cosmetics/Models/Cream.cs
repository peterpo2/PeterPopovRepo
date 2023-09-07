using Cosmetics.Helpers;
using Cosmetics.Models.Contracts;
using Cosmetics.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Models
{
    public class Cream : Product, ICream
    {
        public const int NameMinLength = 3;
        public const int NameMaxLength = 15;
        public const int BrandMinLength = 3;
        public const int BrandManLength = 15;
        public Cream(string name, string brand, decimal price, GenderType gender,ScentType scent) 
            : base(name, brand, price, gender)
        {
            ValidationHelper.ValidateStringLength(name, NameMinLength, NameMaxLength);
            ValidationHelper.ValidateStringLength(brand, BrandMinLength, BrandManLength);

            this.ScentType = scent;
        }

        public ScentType ScentType { get; }

        protected override string AdditionalInfo()
        {
            return $" #Scent: {this.ScentType}";
        }
    }
}
