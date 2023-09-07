using System;
using Agency.Models.Contracts;

namespace Agency.Models
{
    public class Journey
    {
        public const int StartLocationMinLength = 5;
        public const int StartLocationMaxLength = 25;
        public const int DestinationMinLength = 5;
        public const int DestinationMaxLength = 25;
        public const int DistanceMinValue = 5;
        public const int DistanceMaxValue = 5000;

        public Journey(int id, string from, string to, int distance, IVehicle vehicle)
        {
            throw new NotImplementedException();
        }
    }
}
