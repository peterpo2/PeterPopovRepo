using Agency.Commands.Abstracts;
using Agency.Core.Contracts;
using Agency.Models.Contracts;
using System;
using System.Text;

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
            if (this.Repository.Vehicles.Count > 0)
            {
                var sb = new StringBuilder();

                foreach (var vehicle in this.Repository.Vehicles)
                {
                    sb.AppendLine(vehicle.ToString());
                    sb.AppendLine("####################");
                }

                return sb.ToString().Trim();
            }
            else
            {
                return "There are no registered vehicles.";
            }
        }
    }
}
