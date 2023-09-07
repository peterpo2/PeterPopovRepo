using CosmeticsShop.Exceptions;

using System.Text;

namespace CosmeticsShop.Models
{
    public class Product
    {
        private string name;
        private string brand;
        private double price;
        private readonly GenderType gender;

        public Product(string name, string brand, double price, GenderType gender)
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
            set
            {
                if (value.Length < 3 || value.Length > 10)
                {
                    throw new InvalidUserInputException("Product name should be between 3 and 10 symbols.");
                }
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
                if (value.Length < 2 || value.Length > 10)
                {
                    throw new InvalidUserInputException("Product brand should be between 2 and 10 symbols.");
                }
                this.brand = value;
            }
        }

        public double Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value < 0)
                {
                    throw new InvalidUserInputException("Price can't be negative.");
                }
                this.price = value;
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
            var strBulder = new StringBuilder();
            strBulder.AppendLine($"#{this.name} {this.brand}");
            strBulder.AppendLine($" #Price: ${this.price}");
            strBulder.AppendLine($" #Gender: {this.gender}");

            return strBulder.ToString().Trim();
        }
    }
}
