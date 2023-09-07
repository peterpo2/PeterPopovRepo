using Agency.Commands;
using Agency.Commands.Contracts;
using Agency.Commands.Enums;
using Agency.Core.Contracts;

using System;
using System.Collections.Generic;

namespace Agency.Core
{
    public class CommandFactory : ICommandFactory
    {
        private readonly IRepository repository;

        public CommandFactory(IRepository repository)
        {
            this.repository = repository;
        }

        public ICommand Create(string commandLine)
        {
            // RemoveEmptyEntries makes sure no empty strings are added to the result of the split operation.
            string[] arguments = commandLine.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            CommandType commandType = ParseCommandType(arguments[0]);
            List<string> commandParameters = ExtractCommandParameters(arguments);

            switch (commandType)
            {
                case CommandType.CreateAirplane:
                    return new CreateAirplaneCommand(commandParameters, repository);
                case CommandType.CreateBus:
                    return new CreateBusCommand(commandParameters, repository);
                case CommandType.CreateTrain:
                    return new CreateTrainCommand(commandParameters, repository);
                case CommandType.CreateTicket:
                    return new CreateTicketCommand(commandParameters, repository);
                case CommandType.CreateJourney:
                    return new CreateJourneyCommand(commandParameters, repository);
                case CommandType.ListJourneys:
                    return new ListJourneysCommand(repository);
                case CommandType.ListTickets:
                    return new ListTicketsCommand(repository);
                case CommandType.ListVehicles:
                    return new ListVehiclesCommand(repository);
                default:
                    throw new InvalidOperationException($"Command with name: {commandType} doesn't exist!");
            }
        }

        // Attempts to parse CommandType from a given string value.
        // If successful, returns the command enum value, otherwise returns null
        private CommandType ParseCommandType(string value)
        {
            Enum.TryParse(value, true, out CommandType result);
            return result;
        }

        // Receives a full line and extracts the parameters that are needed for the command to execute.
        // For example, if the input line is "FilterBy Assignee John",
        // the method will return a list of ["Assignee", "John"].
        private List<String> ExtractCommandParameters(string[] arguments)
        {
            List<string> commandParameters = new List<string>();

            for (int i = 1; i < arguments.Length; i++)
            {
                commandParameters.Add(arguments[i]);
            }

            return commandParameters;
        }
    }
}
