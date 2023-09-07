using Agency.Exceptions;
using Agency.Models.Contracts;
using System;
using System.Text;

namespace Agency.Models
{
    public class Train : Vehicle, ITrain
    {
        public const int PassengerCapacityMinValue = 30;
        public const int PassengerCapacityMaxValue = 150;
        private const string PassengerCapacityErrorMessage = "A train with less than {0} passengers or more than {1} passengers cannot exist!";
        public const double PricePerKilometerMinValue = 0.10;
        public const double PricePerKilometerMaxValue = 2.50;
        public const int CartsMinValue = 1;
        public const int CartsMaxValue = 15;

        public Train(int id, int passengerCapacity, double pricePerKilometer, int carts)
            : base (id, passengerCapacity, pricePerKilometer)
        {
            ValidateCarts(carts);
            Carts = carts;
        }

        public int Carts { get; }

        private void ValidateCarts(int carts)
        {
            if (carts < CartsMinValue || carts > CartsMaxValue)
            {
                string errorMsg = $"A train cannot have less than {CartsMinValue} cart or more than {CartsMaxValue} carts.";
                throw new InvalidUserInputException(errorMsg);
            }
        }

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

            result.AppendLine("Train ----");
            result.AppendLine(base.ToString());
            result.Append($"Carts amount: {Carts}");

            return result.ToString();
        }
    }
}
