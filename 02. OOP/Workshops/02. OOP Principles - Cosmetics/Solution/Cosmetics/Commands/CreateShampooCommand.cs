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
            ValidationHelper.ValidateArgumentsCount(this.CommandParameters, ExpectedNumberOfArguments);

            string name = this.CommandParameters[0];
            string brand = this.CommandParameters[1];
            decimal price = ParseDecimalParameter(this.CommandParameters[2], "price");
            GenderType genderType = ParseGenderType(this.CommandParameters[3].ToUpper());
            int millilitres = ParseIntParameter(this.CommandParameters[4], "millilitres");
            UsageType usageType = ParseUsageType(this.CommandParameters[5].ToUpper());

            return CreateShampoo(name, brand, price, genderType, millilitres, usageType);
        }
        protected UsageType ParseUsageType(string value)
        {
            if (Enum.TryParse(value, true, out UsageType result))
            {
                return result;
            }
            throw new ArgumentException($"None of the enums in UsageType match the value {value}.");
        }

        private string CreateShampoo(string name,
                                     string brand,
                                     decimal price, 
                                     GenderType genderType,
                                     int millilitres,
                                     UsageType usageType)
        {
            if (this.Repository.ProductExists(name))
            {
                throw new ArgumentException($"Shampoo with name {name} already exists!");
            }

            this.Repository.CreateShampoo(name, brand, price, genderType, millilitres, usageType);

            return $"Shampoo with name {name} was created!";
        }
    }
}
