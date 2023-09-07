using Agency.Commands.Abstracts;
using Agency.Core.Contracts;
using Agency.Exceptions;
using System;
using System.Collections.Generic;

namespace Agency.Commands
{
    public class CreateTicketCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 2;

        public CreateTicketCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }
        
        public override string Execute()
        {
            if (this.CommandParameters.Count < ExpectedNumberOfArguments)
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: {ExpectedNumberOfArguments}, Received: {this.CommandParameters.Count}");
            }

            int journeyId = ParseIntParameter(CommandParameters[0], "journeyId");
            double costs = ParseDoubleParameter(CommandParameters[1], "administrativeCosts");

            var journey = Repository.FindJourneyById(journeyId);
            var ticket = Repository.CreateTicket(journey, costs);
            return $"Ticket with ID {ticket.Id} was created.";
        }
    }
}
