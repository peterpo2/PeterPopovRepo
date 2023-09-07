
using Dealership.Models.Contracts;

namespace Dealership.Models
{
    public class Motorcycle : Vehicle, IMotorcycle
    {
        public const int CategoryMinLength = 3;
        public const int CategoryMaxLength = 10;
        public const string InvalidCategoryError = "Category must be between 3 and 10 characters long!";

        public Motorcycle(string make, string model, decimal price, string category)
            : base(make, model, price, VehicleType.Motorcycle)
        {
            Validator.ValidateIntRange(category.Length,
                                       CategoryMinLength,
                                       CategoryMaxLength,
                                       InvalidCategoryError);

            Category = category;
        }

        public string Category { get; }

        protected override string PrintAdditionalInfo()
        {
            return $"  Category: {Category}";
        }
    }
}
