
using Dealership.Core.Contracts;
using Dealership.Exceptions;
using Dealership.Models;
using System.Text;

namespace Dealership.Commands
{
    public class ShowUsersCommand : BaseCommand
    {

        public ShowUsersCommand(IRepository repository)
            : base(repository)
        {

        }

        protected override bool RequireLogin
        {
            get
            {
                return true;
            }
        }

        protected override string ExecuteCommand()
        {
            if (Repository.LoggedUser.Role != Role.Admin)
            {
                throw new AuthorizationException("You are not an admin!");
            }

            var sb = new StringBuilder();
            sb.AppendLine("--USERS--");
            var count = 1;

            foreach (var user in Repository.Users)
            {
                sb.AppendLine($"{count++}. {user.ToString()}");
            }

            return sb.ToString();
        }
    }
}
