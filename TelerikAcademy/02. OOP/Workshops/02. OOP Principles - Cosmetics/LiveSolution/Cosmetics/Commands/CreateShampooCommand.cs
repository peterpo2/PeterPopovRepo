using Cosmetics.Core.Contracts;
using Cosmetics.Helpers;
using Cosmetics.Models.Enums;
using System;
using System.Collections.Generic;

namespace Cosmetics.Commands
{
    public class CreateShampooCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 6;

        public CreateShampooCommand(IList<string> parameters, IRepository repository)
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
            int millilitres = ParseIntParameter(CommandParameters[4], "millilitres");
            UsageType usageType = ParseUsageType(CommandParameters[5]);

            return CreateShampoo(name,brand,price,gender,millilitres,usageType);

        }

        private string CreateShampoo(string name, string brand, decimal price, GenderType genderType, int millilitres, UsageType usageType)
        {
            if (this.Repository.ProductExists(name))
            {
                throw new ArgumentException(string.Format($"Product with name {name} already exists!"));
            }

            this.Repository.CreateShampoo(name,brand,price,genderType,millilitres,usageType);

            return $"Product with name {name} was created!";
        }

    }
}
