using CosmeticsShop.Commands;

using System;

namespace CosmeticsShop.Core
{
    public class CommandFactory
    {
        public ICommand CreateCommand(string commandTypeValue, CosmeticsRepository productRepository)
        {
            // TODO: Validate command format
            CommandType commandType = Enum.Parse<CommandType>(commandTypeValue, true);

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
                    // TODO: Can we improve this code?
                    return null;
            }
        }
    }
}
