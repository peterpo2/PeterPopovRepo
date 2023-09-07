using AspNetCoreDemo.Exceptions;
using AspNetCoreDemo.Models;
using AspNetCoreDemo.Services;
using System;
using System.Net;
using System.Text;

namespace AspNetCoreDemo.Helpers
{
	public class AuthManager
	{
		private readonly IUsersService usersService;

		public AuthManager(IUsersService usersService)
		{
			this.usersService = usersService;
		}

		public User TryGetUser(string credentials)
		{
            string[] credentialsArray = credentials.Split(':');
            string username = credentialsArray[0];
            string password = credentialsArray[1];

			string encodedPassword = Convert.ToBase64String(Encoding.UTF8.GetBytes(password));

            try
			{
				var user = this.usersService.GetByUsername(username);
				if (user.Password == encodedPassword) 
				{
					return user;
				}
				throw new UnauthenticatedOperationException("Invalid credentials");
			}
			catch (EntityNotFoundException)
			{
				throw new UnauthorizedOperationException("Invalid username!");
			}
		}

	}
}
