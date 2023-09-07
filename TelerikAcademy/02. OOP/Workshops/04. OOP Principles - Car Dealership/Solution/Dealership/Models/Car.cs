
using Dealership.Models.Contracts;
using System.Text;

namespace Dealership.Models
{
    public class Car : Vehicle, ICar
    {
        
        public const int MinSeats = 1;
        public const int MaxSeats = 10;
        public const string InvalidSeatsError = "Seats must be between 1 and 10!";

        public Car(string make, string model, decimal price, int seats)
            : base(make, model, price, VehicleType.Car)
        {
            Validator.ValidateIntRange(seats, MinSeats, MaxSeats, InvalidSeatsError);
            Seats = seats;
        }

        public int Seats { get; }

        protected override string PrintAdditionalInfo()
        {
            return $"  Seats {Seats}";
        }
    }
}
