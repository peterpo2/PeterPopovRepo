using Cosmetics.Core.Contracts;
using Cosmetics.Helpers;
using Cosmetics.Models.Enums;
using System;
using System.Collections.Generic;

namespace Cosmetics.Commands
{
    public class CreateToothpasteCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 5;

        public CreateToothpasteCommand(IList<string> parameters, IRepository repository)
            : base(parameters, repository)
        {
        }

        public override string Execute()
        {
            ValidationHelper.ValidateArgumentsCount(CommandParameters, ExpectedNumberOfArguments);

            string name = CommandParameters[0];
            string brand = CommandParameters[1];
            decimal price = ParseDecimalParameter(CommandParameters[2], "price");
            GenderType gender = ParseGenderType(CommandParameters[3]);
            string ingredients = CommandParameters[4];

            return CreateToothpaste(name, brand, price, gender,ingredients);
        }

        private string CreateToothpaste(string name, string brand, decimal price, GenderType genderType, string ingredients)
        {
            if (this.Repository.ProductExists(name))
            {
                throw new ArgumentException(string.Format($"Product with name {name} already exists!"));
            }

            this.Repository.CreateToothpaste(name, brand, price, genderType, ingredients);

            return $"Product with name {name} was created!";
        }

    }
}
