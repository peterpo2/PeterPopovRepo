using System;

namespace Agency.Models
{
    public class Bus
    {
        public const int PassengerCapacityMinValue = 10;
        public const int PassengerCapacityMaxValue = 50;
        public const double PricePerKilometerMinValue = 0.10;
        public const double PricePerKilometerMaxValue = 2.50;
        
        public Bus(int id, int passengerCapacity, double pricePerKilometer, bool hasFreeTv)
        {
            throw new NotImplementedException();
        }
    }
}
