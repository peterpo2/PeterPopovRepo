using Agency.Commands.Abstracts;
using Agency.Core.Contracts;
using Agency.Exceptions;
using System;
using System.Collections.Generic;

namespace Agency.Commands
{
    public class CreateAirplaneCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 3;

        public CreateAirplaneCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {
            // TODO Implement command.
            throw new NotImplementedException();
        }
    }
}
