
using Dealership.Models.Contracts;
using System.Transactions;

namespace Dealership.Models
{
    public class Truck : Vehicle, ITruck
    {
        public const int MinCapacity = 1;
        public const int MaxCapacity = 100;
        public const string InvalidCapacityError = "Weight capacity must be between 1 and 100!";

        public Truck(string make, string model, decimal price, int weightCapacity)
            : base(make, model, price, VehicleType.Truck)
        {
            Validator.ValidateIntRange(weightCapacity, MinCapacity, MaxCapacity, InvalidCapacityError);

            WeightCapacity = weightCapacity;
        }

        public int WeightCapacity { get; }

        protected override string PrintAdditionalInfo()
        {
            return $"  Weight capacity: {WeightCapacity}t";
        }
    }
}
