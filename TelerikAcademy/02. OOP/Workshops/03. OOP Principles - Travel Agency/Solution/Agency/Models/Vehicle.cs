using Agency.Exceptions;
using Agency.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Models
{
    public abstract class Vehicle : IVehicle
    {
        private const int PassengerCapacityMinValue = 1;
        private const int PassengerCapacityMaxValue = 800;
        private const string PassengerCapacityErrorMessage = "A vehicle with less than {0} passengers or more than {1} passengers cannot exist!";

        private const double PricePerKilometerMinValue = 0.10;
        private const double PricePerKilometerMaxValue = 2.50;
        private const string PricePerKmErrorMessage = "A vehicle with a price per kilometer lower than {0} or higher than {1} cannot exist!";

        private int passengerCapacity;
        private double pricePerKm;

        protected Vehicle(int id, int passengerCapacity, double pricePerKilometer)
        {
            //ValidatePassengerCapacity(passengerCapacity);

            Id = id;
            PassengerCapacity = passengerCapacity;
            PricePerKilometer = pricePerKilometer;
        }
        //public int PassengerCapacity { get; }

        public int PassengerCapacity
        {
            get
            {
                return passengerCapacity;
            }
            private set
            {
                ValidatePassengerCapacity(value);
                passengerCapacity = value;
            }
        }


        public double PricePerKilometer
        {
            get
            {
                return pricePerKm;
            }
            private set
            {
                ValidatePricePerKm(value);
                pricePerKm = value;
            }
        }

        public int Id { get; }

        //protected abstract string GetName();
        

        protected virtual void ValidatePassengerCapacity(int value)
        {
            if (value < PassengerCapacityMinValue || value > PassengerCapacityMaxValue)
            {
                string errorMsg = string.Format(PassengerCapacityErrorMessage, PassengerCapacityMinValue, PassengerCapacityMaxValue);
                throw new InvalidUserInputException(errorMsg);
            }
        }

        public virtual void ValidatePricePerKm(double value)
        {
            if (value < PricePerKilometerMinValue || value > PricePerKilometerMaxValue)
            {
                string errorMsg = string.Format(PricePerKmErrorMessage, PricePerKilometerMinValue, PricePerKilometerMaxValue);
                throw new InvalidUserInputException(errorMsg);
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine($"Passenger capacity: {PassengerCapacity}");
            result.AppendLine($"Price per kilometer: {PricePerKilometer:F2}");
            return result.ToString().Trim();
        }
    }
}
