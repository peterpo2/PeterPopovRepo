using System;

namespace Agency.Models
{
    public class Airplane
    {
        public const int PassengerCapacityMinValue = 1;
        public const int PassengerCapacityMaxValue = 800;
        public const double PricePerKilometerMinValue = 0.10;
        public const double PricePerKilometerMaxValue = 2.50;
        
        public Airplane(int id, int passengerCapacity, double pricePerKilometer, bool isLowCost)
        {
            throw new NotImplementedException();
        }
    }
}
