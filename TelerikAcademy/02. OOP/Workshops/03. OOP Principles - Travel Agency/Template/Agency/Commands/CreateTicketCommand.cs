using Agency.Commands.Abstracts;
using Agency.Core.Contracts;
using System;
using System.Collections.Generic;

namespace Agency.Commands
{
    public class CreateTicketCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 2;

        public CreateTicketCommand(IList<string> commandParameters, IRepository repository)
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
