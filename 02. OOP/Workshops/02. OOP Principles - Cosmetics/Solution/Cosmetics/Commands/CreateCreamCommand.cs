using Cosmetics.Core.Contracts;
using Cosmetics.Helpers;
using Cosmetics.Models.Enums;
using System;
using System.Collections.Generic;

namespace Cosmetics.Commands
{
    public class CreateCreamCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 5;

        public CreateCreamCommand(IList<string> parameters, IRepository repository)
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
            ScentType scentType = ParseScentType(this.CommandParameters[4].ToUpper());

            return CreateCream(name, brand, price, genderType, scentType);
        }

        protected ScentType ParseScentType(string value)
        {
            if (Enum.TryParse(value, true, out ScentType result))
            {
                return result;
            }
            throw new ArgumentException($"None of the enums in ScentType match the value {value}.");
        }

        private string CreateCream(string name,
                                   string brand,
                                   decimal price,
                                   GenderType genderType,
                                   ScentType scentType)
        {
            if (this.Repository.ProductExists(name))
            {
                throw new ArgumentException($"Cream with name {name} already exists!");
            }

            Repository.CreateCream(name, brand, price, genderType, scentType);

            return string.Format($"Cream with name {name} was created!");
        }
    }
}
