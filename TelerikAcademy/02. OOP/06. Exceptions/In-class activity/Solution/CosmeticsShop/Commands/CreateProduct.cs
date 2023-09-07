using CosmeticsShop.Core;
using CosmeticsShop.Exceptions;
using CosmeticsShop.Models;

using System;
using System.Collections.Generic;
using System.Globalization;

namespace CosmeticsShop.Commands
{
    public class CreateProduct : ICommand
    {
        private readonly CosmeticsRepository cosmeticsRepository;

        public CreateProduct(CosmeticsRepository productRepository)
        {
            this.cosmeticsRepository = productRepository;
        }

        public string Execute(List<string> parameters)
        {
            if (parameters.Count < 4)
            {
                throw new InvalidUserInputException("CreateProduct command expects 4 parameters.");
            }

            string name = parameters[0];
            string brand = parameters[1];

            if (!double.TryParse(parameters[2], NumberStyles.Float, CultureInfo.InvariantCulture, out double price))
            {
                throw new InvalidUserInputException("Third parameter should be price (real number).");
            }

            if (!Enum.TryParse(parameters[3], true, out GenderType gender))
            {
                throw new InvalidUserInputException("Forth parameter should be one of Men, Women or Unisex.");
            }

            if (this.cosmeticsRepository.ProductExist(name))
            {
                throw new DuplicateEntityException($"Product {name} already exist.");
            }
            this.cosmeticsRepository.CreateProduct(name, brand, price, gender);

            return $"Product with name {name} was created!";
        }
    }
}
