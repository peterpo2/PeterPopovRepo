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
    public abstract class Product : IProduct
    {
        protected Product(string name, string brand, decimal price, GenderType gender)
        {
            ValidationHelper.ValidateNonNegative(price, "price");

            Name = name;
            Brand = brand;
            Price = price;
            Gender = gender;
        }

        public string Name { get; }

        public string Brand { get; }

        public decimal Price { get; }

        public GenderType Gender { get; }

        public string Print()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"#{this.Name} {this.Brand}");
            sb.AppendLine($" #Price: ${this.Price:F2}");
            sb.AppendLine($" #Gender: {this.Gender}");
            sb.AppendLine(AdditionalInfo());
            sb.AppendLine(" ===");
            return sb.ToString();
        }

        protected abstract string AdditionalInfo();
    }
}
