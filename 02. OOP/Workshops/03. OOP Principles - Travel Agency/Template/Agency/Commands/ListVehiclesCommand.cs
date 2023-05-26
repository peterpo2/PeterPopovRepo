using Agency.Commands.Abstracts;
using Agency.Core.Contracts;
using System;

namespace Agency.Commands
{
    public class ListVehiclesCommand : BaseCommand
    {
        public ListVehiclesCommand(IRepository repository)
            : base(repository)
        {
        }
        
        public override string Execute()
        {
            // TODO Implement command.
            throw new NotImplementedException();
        }
    }
}
