using Cosmetics.Core;
using Cosmetics.Core.Contracts;
using Cosmetics.Models;
using Cosmetics.Models.Contracts;
using Cosmetics.Models.Enums;

namespace Cosmetics
{
    public class Startup
    {
        static void Main()
        {
            IRepository repository = new Repository();
            ICommandFactory commandFactory = new CommandFactory(repository);
            IEngine cosmeticsEngine = new Engine(commandFactory);
            cosmeticsEngine.Start();

        }
    }
}
