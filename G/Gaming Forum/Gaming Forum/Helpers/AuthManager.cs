using Gaming_Forum.Exeptions;
using Gaming_Forum.Models;
using Gaming_Forum.Services.Contracts;

namespace Gaming_Forum.Helpers
{
    public class AuthManager
    {
        private const string CURRENT_USER = "CURRENT_USER";
        private readonly IUserService usersService;
        private readonly IHttpContextAccessor contextAccessor;

        public AuthManager(IUserService usersService, IHttpContextAccessor contextAccessor)
        {
            this.usersService = usersService;
            this.contextAccessor = contextAccessor;
        }

        public User TryGetUser(string username)
        {
            try
            {
                return this.usersService.GetUserByUsername(username);
            }
            catch (EntityNotFoundException)
            {
                throw new UnauthorizedOperationException("Invalid username!");
            }
        }

        public User TryGetUser(string username, string password)
        {
            try
            {
                User user = this.usersService.GetUserByUsername(username);

                // check for password mismatch
                if (user.Password != password)
                {
                    throw new UnauthorizedOperationException("Invalid username or password");
                }
                if (user.IsBlocked)
                {
                    throw new UnauthorizedOperationException("This user is blocked");
                }

                return user;
            }
            catch (EntityNotFoundException)
            {
                throw new UnauthorizedOperationException("Invalid username or password");
            }
        }

        public void Login(string username, string password)
        {
            this.CurrentUser = this.TryGetUser(username, password);

            if (this.CurrentUser == null)
            {
                int? loginAttempts = this.contextAccessor.HttpContext.Session.GetInt32("LOGIN_ATTEMPTS");

                if (loginAttempts.HasValue && loginAttempts == 5)
                {
                    // redirect
                    this.contextAccessor.HttpContext.Response.Redirect("/Home/Index");
                }
                else
                {
                    this.contextAccessor.HttpContext.Session.SetInt32("LOGIN_ATTEMPTS", (int)loginAttempts + 1);
                }

            }
        }

        public void Logout()
        {
            this.CurrentUser = null;
        }

        public User CurrentUser
        {
            get
            {
                try
                {
                    string username = this.contextAccessor.HttpContext.Session.GetString(CURRENT_USER);
                    User user = this.usersService.GetUserByUsername(username);
                    return user;
                }
                catch (EntityNotFoundException)
                {
                    return null;
                }
            }
            set
            {
                // User
                User user = value;
                if (user != null)
                {
                    // add username to session
                    this.contextAccessor.HttpContext.Session.SetString(CURRENT_USER, user.Username);
                }
                else
                {
                    this.contextAccessor.HttpContext.Session.Remove(CURRENT_USER);
                }
            }
        }
    }
}
