using Dealership.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Models
{
    public abstract class Vehicle : IVehicle
    {
        public const int MakeMinLength = 2;
        public const int MakeMaxLength = 15;
        public const string InvalidMakeError = "Make must be between 2 and 15 characters long!";
        public const int ModelMinLength = 1;
        public const int ModelMaxLength = 15;
        public const string InvalidModelError = "Model must be between 1 and 15 characters long!";
        public const decimal MinPrice = 0.0m;
        public const decimal MaxPrice = 1000000.0m;
        public const string InvalidPriceError = "Price must be between 0.0 and 1000000.0!";

        private readonly IList<IComment> comments = new List<IComment>();

        public Vehicle(string make, string model, decimal price, VehicleType type)
        {
            Validator.ValidateIntRange(make.Length, MakeMinLength, MakeMinLength, InvalidMakeError);
            Validator.ValidateIntRange(model.Length, ModelMinLength, ModelMaxLength, InvalidModelError);
            Validator.ValidateDecimalRange(price, MinPrice, MaxPrice, InvalidPriceError);
            
            Make = make;
            Model = model;
            Price = price;
            Type = type;
            Wheels = (int)Type;
        }

        public string Make { get; }

        public string Model { get; }

        public VehicleType Type { get; }

        public int Wheels { get; }

        public IList<IComment> Comments 
        {
            get 
            {
                return new List<IComment>(comments);
            }
        }

        public decimal Price { get; }

        public void AddComment(IComment comment)
        {
            comments.Add(comment);
        }

        public void RemoveComment(IComment comment)
        {
            comments.Remove(comment);
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.AppendLine($"{Type}:");
            builder.AppendLine($"  Make: {this.Make}");
            builder.AppendLine($"  Model: {this.Model}");
            builder.AppendLine($"  Wheels: {this.Wheels}");
            builder.AppendLine($"  Price: ${this.Price}");
            builder.AppendLine($"{PrintAdditionalInfo()}");
            builder.AppendLine(PrintComments());

            return builder.ToString();

        }

        protected abstract string PrintAdditionalInfo();

        private string PrintComments()
        {
            var sb = new StringBuilder();

            if (Comments.Count <= 0)
            {
                sb.AppendLine("    --NO COMMENTS--");
            }
            else
            {
                sb.AppendLine("    --COMMENTS--");

                foreach (var comment in comments)
                {
                    sb.AppendLine(comment.ToString());
                }

                sb.AppendLine("    --COMMENTS--");
            }

            return sb.ToString();
        }
    }
}
