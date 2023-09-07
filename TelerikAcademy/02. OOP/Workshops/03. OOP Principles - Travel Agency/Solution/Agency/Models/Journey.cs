using System;
using System.Collections.Generic;
using System.Text;
using Agency.Exceptions;
using Agency.Models.Contracts;

namespace Agency.Models
{
    public class Journey : IJourney
    {
        public const int StartLocationMinLength = 5;
        public const int StartLocationMaxLength = 25;
        public const int DestinationMinLength = 5;
        public const int DestinationMaxLength = 25;
        public const int DistanceMinValue = 5;
        public const int DistanceMaxValue = 5000;

        private const string StartLocationErrorMessage = "The StartingLocation's length cannot be less than 5 or more than 25 symbols long.";
        private const string DestinationErrorMessage = "The Destination's length cannot be less than 5 or more than 25 symbols long.";
        private const string DistanceErrorMessage = "The Distance cannot be less than 5 or more than 5000 kilometers.";

        private string startLocation;
        private string destination;
        private int distance;

        public Journey(int id, string from, string to, int distance, IVehicle vehicle)
        {
            Id = id;
            StartLocation = from;
            Destination = to;
            Distance = distance;
            Vehicle = vehicle;
        }

        public string StartLocation
        {
            get
            {
                return startLocation;
            }
            private set
            {
                if (value.Length < StartLocationMinLength || value.Length > StartLocationMaxLength)
                {
                    throw new InvalidUserInputException(StartLocationErrorMessage);
                }
                startLocation = value;
            }
        }

        public string Destination
        {
            get
            {
                return destination;
            }
            private set
            {
                if (value.Length < DestinationMinLength || value.Length > DestinationMaxLength)
                {
                    throw new InvalidUserInputException(DestinationErrorMessage);
                }
                destination = value;
            }
        }

        public int Distance
        {
            get
            {
                return distance;
            }
            set
            {
                if (value < DistanceMinValue || value > DistanceMaxValue)
                {
                    throw new InvalidUserInputException(DistanceErrorMessage);
                }
                distance = value;
            }
        }

        public IVehicle Vehicle { get; }

        public int Id { get; }

        public double CalculatePrice()
        {
            return Distance * Vehicle.PricePerKilometer;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine("Journey ----");
            sb.AppendLine($"Start location: {this.StartLocation}");
            sb.AppendLine($"Destination: {this.Destination}");
            sb.AppendLine($"Distance: {this.Distance}");
            sb.Append($"Travel costs: {this.CalculatePrice():F2}");

            return sb.ToString();
        }
    }
}
