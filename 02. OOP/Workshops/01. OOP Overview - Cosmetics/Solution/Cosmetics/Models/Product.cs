using Cosmetics.Helpers;
using System;
using System.Text;

namespace Cosmetics.Models
{
    public class Product
    {
        public const int NameMinLength = 3;
        public const int NameMaxLength = 10;
        public const int BrandMinLength = 2;
        public const int BrandMaxLength = 10;

        private const string NameErrorMessage = "Name must be between {0} and {1}";
        private const string BrandErrorMessage = "Brand must be between {0} and {1} symbols";

        private double price;
        private string name;
        private string brand;
        private readonly GenderType gender;

        // "Each product in the system has name, brand, price and gender."

        public Product(string name, string brand, double price, GenderType gender)
        {
            Name = name;
            Brand = brand;
            Price = price;
            this.gender = gender;
        }

        public double Price
        {
            get
            {
                return this.price;
            }
            set
            {
                ValidationHelpers.ValidateNonNegative(value, "Price cannot be negative.");
                this.price = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Name cannot be null.");
                }


                string errorMessage = string.Format(NameErrorMessage, NameMinLength, NameMaxLength);
                ValidationHelpers.ValidateStringLength(value, NameMinLength, NameMaxLength, errorMessage);
                this.name = value;
            }
        }

        public string Brand
        {
            get
            {
                return this.brand;
            }
            set
            {
                string errorMessage = string.Format(BrandErrorMessage, BrandMinLength, BrandMaxLength);
                ValidationHelpers.ValidateStringLength(value, BrandMinLength, BrandMaxLength, errorMessage);
                this.brand = value;
            }
        }

        public GenderType Gender
        {
            get
            {
                return this.gender;
            }
        }

        public string Print()
        {
            // Format:
            // #[Name] [Brand]
            // #Price: [Price]
            // #Gender: [Gender]
            StringBuilder result = new StringBuilder();
            result.AppendLine($" #{Name} {Brand}");
            result.AppendLine($" #Price: {Price:f2}");
            result.AppendLine($" #Gender: {Gender}");
            return result.ToString();
        }

        public override bool Equals(object p)
        {
            if (p == null || !(p is Product))
            {
                return false;
            }

            if (this == p)
            {
                return true;
            }

            Product otherProduct = (Product)p;

            return this.Price == otherProduct.Price
                    && this.Name == otherProduct.Name
                    && this.Brand == otherProduct.Brand
                    && this.Gender == otherProduct.Gender;
        }
    }
}