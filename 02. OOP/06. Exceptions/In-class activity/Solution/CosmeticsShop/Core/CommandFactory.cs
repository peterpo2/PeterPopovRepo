using CosmeticsShop.Commands;

using System;

namespace CosmeticsShop.Core
{
    public class CommandFactory
    {
        public ICommand CreateCommand(string commandTypeValue, CosmeticsRepository productRepository)
        {
            if (!Enum.TryParse(commandTypeValue, true, out CommandType commandType))
            {
                // This exception means that the user has entered not existing command.
                throw new Exceptions.InvalidUserInputException($"Command {commandTypeValue} is not supported.");
            }

            switch (commandType)
            {
                case CommandType.CreateCategory:
                    return new CreateCategory(productRepository);
                case CommandType.CreateProduct:
                    return new CreateProduct(productRepository);
                case CommandType.AddProductToCategory:
                    return new AddProductToCategory(productRepository);
                case CommandType.ShowCategory:
                    return new ShowCategory(productRepository);
                default:
                    // This exception means that the CommandType enum and command classes are inconsistent.
                    throw new InvalidOperationException($"Command {commandTypeValue} is not supported.");
            }
        }
    }
}
