using Gaming_Forum.Exeptions;
using Gaming_Forum.Models;
using Gaming_Forum.Services;
using Gaming_Forum.Services.Contracts;

namespace Gaming_Forum.Helpers
{
    public class AuthManager
    {
        private readonly IUserService usersService;

        public AuthManager(IUserService usersService)
        {
            this.usersService = usersService;
        }

        public User TryGetUser(string username)
        {
            try
            {
                return usersService.GetUserByUsername(username);
            }
            catch (EntityNotFoundException)
            {
                throw new UnauthorizedOperationException("Invalid username");
            }
        }
    }
}
