using System;
using System.Text;
using Agency.Exceptions;
using Agency.Models.Contracts;

namespace Agency.Models
{
    public class Ticket : ITicket
    {
        private double administrativeCosts;

        public Ticket(int id, IJourney journey, double administrativeCosts)
        {
            Id = id;
            AdministrativeCosts = administrativeCosts;
        }

        public double AdministrativeCosts
        {
            get
            {
                return administrativeCosts;
            }
            private set
            {
                if (value < 0)
                {
                    throw new InvalidUserInputException($"Value of 'costs' must be a positive number. Actual value: {value:F2}");
                }
                administrativeCosts = value;
            }
        }

        public IJourney Journey { get; }

        public int Id { get; }

        public double CalculatePrice()
        {
            return AdministrativeCosts * Journey.CalculatePrice();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine("Ticket ----");
            sb.AppendLine($"Destination: {this.Journey.Destination}");
            sb.AppendLine($"Price: {this.CalculatePrice():F2}");

            return sb.ToString().Trim();
        }
    }
}
