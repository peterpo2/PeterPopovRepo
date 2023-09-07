using CosmeticsShop.Core;
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
            // TODO: Validate parameters count
            string name = parameters[0];
            string brand = parameters[1];

            // TODO: Validate price format
            double price = double.Parse(parameters[2], CultureInfo.InvariantCulture);

            // TODO: Validate gender format
            GenderType gender = Enum.Parse<GenderType>(parameters[3], true);

            // TODO: Ensure category name is unique
            this.cosmeticsRepository.CreateProduct(name, brand, price, gender);

            return $"Product with name {name} was created!";
        }
    }
}
