using Cosmetics.Core.Contracts;
using Cosmetics.Helpers;
using Cosmetics.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            ValidationHelper.ValidateArgumentsCount(CommandParameters, ExpectedNumberOfArguments);

            string name = CommandParameters[0];
            string brand = CommandParameters[1];
            decimal price = ParseDecimalParameter(CommandParameters[2], "price");
            GenderType gender = ParseGenderType(CommandParameters[3]);
            ScentType scent = ParseScentType(CommandParameters[4]);

            return CreateCream(name, brand, price, gender, scent);
        }

        private string CreateCream(string name, string brand, decimal price, GenderType genderType, ScentType scentType)
        {
            if (this.Repository.ProductExists(name))
            {
                throw new ArgumentException(string.Format($"Product with name {name} already exists!"));
            }

            this.Repository.CreateCream(name, brand, price, genderType, scentType);

            return $"Product with name {name} was created!";
        }
    }
}
