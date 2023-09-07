using Cosmetics.Models.Contracts;
using Cosmetics.Models.Enums;
using System;
using System.Text;

namespace Cosmetics.Models
{
    public abstract class Product : IProduct
    {
        private decimal price;
        private string name;
        private string brand;
        private readonly GenderType gender;

        public Product(string name, string brand, decimal price, GenderType gender)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.gender = gender;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Name should not be null.");
                }
                ValidateName(value);
                this.name = value;
            }
        }

        protected abstract void ValidateName(string name);

        public string Brand
        {
            get
            {
                return this.brand;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Brand should not be null.");
                }
                ValidateBrand(value);
                this.brand = value;
            }
        }

        protected abstract void ValidateBrand(string brand);

        public decimal Price
        {
            get
            {
                return this.price;
            }
            private set
            {
                ValidatePrice(value);
                this.price = value;
            }
        }

        protected abstract void ValidatePrice(decimal price);

        public GenderType Gender => this.gender;

        protected abstract string AdditionalInfo();

        public string Print()
        {
            var sb = new StringBuilder();
            sb.AppendLine($" #{this.Name} {this.Brand}");
            sb.AppendLine($" #Price: ${this.Price:0.##}");
            sb.AppendLine($" #Gender: {this.Gender}");
            sb.AppendLine($" {this.AdditionalInfo()}");
            sb.AppendLine();
            return sb.ToString().Trim();
        }
    }
}
