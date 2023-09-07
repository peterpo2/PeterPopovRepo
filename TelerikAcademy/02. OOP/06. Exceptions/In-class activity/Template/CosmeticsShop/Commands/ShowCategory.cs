using CosmeticsShop.Core;
using CosmeticsShop.Models;

using System.Collections.Generic;

namespace CosmeticsShop.Commands
{
    public class ShowCategory : ICommand
    {
        private readonly CosmeticsRepository cosmeticsRepository;

        public ShowCategory(CosmeticsRepository productRepository)
        {
            this.cosmeticsRepository = productRepository;
        }

        public string Execute(List<string> parameters)
        {
            //TODO: Validate parameters count
            string categoryName = parameters[0];

            Category category = this.cosmeticsRepository.FindCategoryByName(categoryName);

            return category.Print();
        }
    }
}
