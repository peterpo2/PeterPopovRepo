using Cosmetics.Core.Contracts;
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
            throw new NotImplementedException("Not implemented yet.");
        }

    }
}
