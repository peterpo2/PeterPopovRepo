using System;

namespace Cosmetics.Models
{
    public class Product
    {
        public const int NameMinLength = 3;
        public const int NameMaxLength = 10;
        public const int BrandMinLength = 2;
        public const int BrandMaxLength = 10;

        // "Each product in the system has name, brand, price and gender."

        public Product(string name, string brand, double price, GenderType gender)
        {
            throw new NotImplementedException("Not implemented yet.");
        }

        public double Price
        {
            get
            {
                throw new NotImplementedException("Not implemented yet.");
            }
            set
            {
                throw new NotImplementedException("Not implemented yet.");
            }
        }

        public string Name
        {
            get
            {
                throw new NotImplementedException("Not implemented yet.");
            }
            set
            {
                throw new NotImplementedException("Not implemented yet.");
            }
        }

        public string Brand
        {
            get
            {
                throw new NotImplementedException("Not implemented yet.");
            }
            set
            {
                throw new NotImplementedException("Not implemented yet.");
            }
        }

        public GenderType Gender
        {
            get
            {
                throw new NotImplementedException("Not implemented yet.");
            }
        }

        public string Print()
        {
            // Format:
            // #[Name] [Brand]
            // #Price: [Price]
            // #Gender: [Gender]
            throw new NotImplementedException("Not implemented yet.");
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