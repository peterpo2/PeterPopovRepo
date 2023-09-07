using Agency.Commands.Abstracts;
using Agency.Core.Contracts;
using Agency.Exceptions;
using System;
using System.Collections.Generic;

namespace Agency.Commands
{
    public class CreateAirplaneCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 3;

        public CreateAirplaneCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {
            if (this.CommandParameters.Count < ExpectedNumberOfArguments)
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: {ExpectedNumberOfArguments}, Received: {this.CommandParameters.Count}");
            }

            int passengerCapacity = ParseIntParameter(CommandParameters[0], "passengerCapacity");
            double pricePerKm = ParseDoubleParameter(CommandParameters[1], "pricePerKm");
            bool isLowCost = ParseBoolParameter(CommandParameters[2], "isLowCost");

            var airplane = Repository.CreateAirplane(passengerCapacity, pricePerKm, isLowCost);
            return $"Vehicle with ID {airplane.Id} was created.";
        }
    }
}
