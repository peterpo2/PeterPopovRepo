using Agency.Exceptions;
using Agency.Models.Contracts;
using System;
using System.Text;

namespace Agency.Models
{
    public class Bus : Vehicle, IBus
    {
        public const int PassengerCapacityMinValue = 10;
        public const int PassengerCapacityMaxValue = 50;
        private const string PassengerCapacityErrorMessage = "A bus cannot have less than {0} passengers or more than {1} passengers.";
        public const double PricePerKilometerMinValue = 0.10;
        public const double PricePerKilometerMaxValue = 2.50;
        
        public Bus(int id, int passengerCapacity, double pricePerKilometer, bool hasFreeTv)
            : base(id, passengerCapacity, pricePerKilometer)
        {
            HasFreeTv = hasFreeTv;
        }

        public bool HasFreeTv { get; }

        protected override void ValidatePassengerCapacity(int value)
        {
            if (value < PassengerCapacityMinValue || value > PassengerCapacityMaxValue)
            {
                string errorMsg = string.Format(PassengerCapacityErrorMessage, PassengerCapacityMinValue, PassengerCapacityMaxValue);
                throw new InvalidUserInputException(errorMsg);
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine("Bus ----");
            result.AppendLine(base.ToString());
            result.Append($"Has free TV: {HasFreeTv}");

            return result.ToString();
        }
    }

}
