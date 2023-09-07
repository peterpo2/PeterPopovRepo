using AspNetCoreDemo.Exceptions;
using AspNetCoreDemo.Models;
using AspNetCoreDemo.Services;

using Microsoft.AspNetCore.Http;

namespace AspNetCoreDemo.Helpers
{
	public class AuthManager
	{
		private const string CURRENT_USER = "CURRENT_USER";
		private readonly IUsersService usersService;
		private readonly IHttpContextAccessor contextAccessor;

		public AuthManager(IUsersService usersService, IHttpContextAccessor contextAccessor)
		{
			this.usersService = usersService;
			this.contextAccessor = contextAccessor;
		}

		public User TryGetUser(string username)
		{
			try
			{
				return this.usersService.GetByUsername(username);
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
				User user = this.usersService.GetByUsername(username);

				// check for password mismatch
				if (user.Password != password)
				{
					throw new UnauthorizedOperationException("Invalid username or password");
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
					User user = this.usersService.GetByUsername(username);
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
