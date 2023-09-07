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
            ValidationHelper.ValidateArgumentsCount(this.CommandParameters, ExpectedNumberOfArguments);

            string name = this.CommandParameters[0];
            string brand = this.CommandParameters[1];
            decimal price = ParseDecimalParameter(this.CommandParameters[2], "price");
            GenderType genderType = ParseGenderType(this.CommandParameters[3].ToUpper());
            string ingredients = this.CommandParameters[4];

            return CreateToothpaste(name, brand, price, genderType, ingredients);
        }

        private string CreateToothpaste(string name,
                                        string brand,
                                        decimal price,
                                        GenderType genderType,
                                        string ingredients)
        {
            if (this.Repository.ProductExists(name))
            {
                throw new ArgumentException($"Toothpaste with name {name} already exists!");
            }

            Repository.CreateToothpaste(name, brand, price, genderType, ingredients);

            return string.Format($"Toothpaste with name {name} was created!");
        }
    }
}
