using Agency.Commands.Abstracts;
using Agency.Core.Contracts;
using Agency.Exceptions;

using System.Collections.Generic;

namespace Agency.Commands
{
    public class CreateBusCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 3;

        public CreateBusCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {
            if (this.CommandParameters.Count < ExpectedNumberOfArguments)
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: {ExpectedNumberOfArguments}, Received: {this.CommandParameters.Count}");
            }

            // Parameters:
            //  [0] - passenger capacity
            //  [1] - price per km
            //  [2] - has free TV?
            int passengerCapacity = this.ParseIntParameter(this.CommandParameters[0], "passengerCapacity");
            double pricePerKilometer = this.ParseDoubleParameter(this.CommandParameters[1], "pricePerKilometer");
            bool hasFreeTv = this.ParseBoolParameter(this.CommandParameters[2], "hasFreeTv");

            var bus = this.Repository.CreateBus(passengerCapacity, pricePerKilometer, hasFreeTv);
            return $"Vehicle with ID {bus.Id} was created.";
        }
    }
}
