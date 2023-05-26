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
                // TODO: Validate name
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
                // TODO: Validate brand
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
                // TODO: Validate price
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
