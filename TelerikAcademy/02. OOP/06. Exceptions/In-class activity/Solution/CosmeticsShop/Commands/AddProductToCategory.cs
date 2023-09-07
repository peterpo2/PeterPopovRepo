using CosmeticsShop.Core;
using CosmeticsShop.Exceptions;
using CosmeticsShop.Models;

using System.Collections.Generic;

namespace CosmeticsShop.Commands
{
    public class AddProductToCategory : ICommand
    {
        private readonly CosmeticsRepository cosmeticsRepository;

        public AddProductToCategory(CosmeticsRepository productRepository)
        {
            this.cosmeticsRepository = productRepository;
        }

        public string Execute(List<string> parameters)
        {
            if (parameters.Count < 2)
            {
                throw new InvalidUserInputException("AddProductToCategory command expects 2 parameters.");
            }

            string categoryName = parameters[0];
            string productName = parameters[1];

            Category category = this.cosmeticsRepository.FindCategoryByName(categoryName);
            Product product = this.cosmeticsRepository.FindProductByName(productName);

            category.AddProduct(product);

            return $"Product {productName} added to category {categoryName}!";
        }
    }
}
