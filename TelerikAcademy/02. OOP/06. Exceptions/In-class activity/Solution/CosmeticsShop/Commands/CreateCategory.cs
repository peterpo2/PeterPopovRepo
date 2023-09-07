using CosmeticsShop.Core;
using CosmeticsShop.Exceptions;

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
            if (parameters.Count < 1)
            {
                throw new InvalidUserInputException("CreateCategory command expects 1 parameters.");
            }

            string categoryName = parameters[0];

            if (this.cosmeticsRepository.CategoryExist(categoryName))
            {
                throw new DuplicateEntityException($"Category {categoryName} already exist.");
            }
            this.cosmeticsRepository.CreateCategory(categoryName);

            return $"Category with name {categoryName} was created!";
        }
    }
}
