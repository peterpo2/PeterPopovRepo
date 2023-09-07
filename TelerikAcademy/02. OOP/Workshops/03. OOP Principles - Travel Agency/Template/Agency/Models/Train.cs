using System;

namespace Agency.Models
{
    public class Train
    {
        public const int PassengerCapacityMinValue = 30;
        public const int PassengerCapacityMaxValue = 150;
        public const double PricePerKilometerMinValue = 0.10;
        public const double PricePerKilometerMaxValue = 2.50;
        public const int CartsMinValue = 1;
        public const int CartsMaxValue = 15;

        public Train(int id, int passengerCapacity, double pricePerKilometer, int carts)
        {
            throw new NotImplementedException();
        }
    }
}
