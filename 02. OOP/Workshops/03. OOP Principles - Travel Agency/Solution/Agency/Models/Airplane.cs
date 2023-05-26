using Agency.Models.Contracts;
using System;
using System.Text;

namespace Agency.Models
{
    public class Airplane : Vehicle, IAirplane
    {
        public const int PassengerCapacityMinValue = 1;
        public const int PassengerCapacityMaxValue = 800;
        public const double PricePerKilometerMinValue = 0.10;
        public const double PricePerKilometerMaxValue = 2.50;


        public Airplane(int id, int passengerCapacity, double pricePerKilometer, bool isLowCost)
            : base(id, passengerCapacity, pricePerKilometer)
        {
            IsLowCost = isLowCost;
        }

        public bool IsLowCost
        {
            get;
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine("Airplane ----");
            result.AppendLine(base.ToString());
            result.Append($"Is low-cost: {IsLowCost}");

            return result.ToString();
        }
    }
}
