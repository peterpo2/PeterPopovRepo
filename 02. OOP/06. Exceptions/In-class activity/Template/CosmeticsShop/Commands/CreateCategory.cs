using CosmeticsShop.Core;

using System.Collections.Generic;

namespace CosmeticsShop.Commands
{
    public class CreateCategory : ICommand
    {
        private readonly CosmeticsRepository cosmeticsRepository;

        public CreateCategory(CosmeticsRepository productRepository)
        {
            this.cosmeticsRepository = productRepository;
        }

        public string Execute(List<string> parameters)
        {
            // TODO: Validate parameters count
            string categoryName = parameters[0];

            // TODO: Ensure category name is unique
            this.cosmeticsRepository.CreateCategory(categoryName);

            return $"Category with name {categoryName} was created!";
        }
    }
}
