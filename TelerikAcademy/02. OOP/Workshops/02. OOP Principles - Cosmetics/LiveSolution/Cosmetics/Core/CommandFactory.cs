using Cosmetics.Commands;
using Cosmetics.Commands.Contracts;
using Cosmetics.Commands.Enums;
using Cosmetics.Core.Contracts;
using System;
using System.Collections.Generic;

namespace Cosmetics.Core
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

            CommandType commandType = this.ParseCommandType(arguments[0]);
            List<string> commandParameters = this.ExtractCommandParameters(arguments);

            switch (commandType)
            {
                case CommandType.CreateCategory:
                    return new CreateCategoryCommand(commandParameters, repository);
                case CommandType.CreateShampoo:
                    return new CreateShampooCommand(commandParameters, repository);
                case CommandType.CreateToothpaste:
                    return new CreateToothpasteCommand(commandParameters, repository);
                case CommandType.CreateCream:
                    return new CreateCreamCommand(commandParameters, repository);
                case CommandType.AddToCategory:
                    return new AddToCategoryCommand(commandParameters, repository);
                case CommandType.RemoveFromCategory:
                    return new RemoveFromCategoryCommand(commandParameters, repository);
                case CommandType.AddToShoppingCart:
                    return new AddToShoppingCartCommand(commandParameters, repository);
                case CommandType.RemoveFromShoppingCart:
                    return new RemoveFromShoppingCartCommand(commandParameters, repository);
                case CommandType.ShowCategory:
                    return new ShowCategoryCommand(commandParameters, repository);
                case CommandType.TotalPrice:
                    return new TotalPriceCommand(repository);
                default:
                    throw new ArgumentException($"Command with name: {commandType} doesn't exist!");
            }
        }

        // Attempts to parse CommandType from a given string value.
        // If successful, returns the command enum value
        private CommandType ParseCommandType(string value)
        {
            Enum.TryParse(value, true, out CommandType result);
            return result;
        }

        // Receives a full line and extracts the parameters that are needed for the command to execute.
        // For example, if the input line is "FilterBy Assignee John",
        // the method will return a list of ["Assignee", "John"].
        private List<string> ExtractCommandParameters(string[] arguments)
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
