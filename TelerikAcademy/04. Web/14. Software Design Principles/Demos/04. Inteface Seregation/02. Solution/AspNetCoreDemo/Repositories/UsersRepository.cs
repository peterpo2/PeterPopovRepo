using System;
using System.Collections.Generic;

using AspNetCoreDemo.Models;

namespace AspNetCoreDemo.Repositories
{
	public class UsersRepository : IReadOnlyRepository<User>
	{
		private readonly List<User> users = new List<User>()
		{
			new User
			{
				Id = 1,
				Username = "administratarator",
				Role = Roles.Admin,
			},
			new User
			{
				Id = 2,
				Username = "pesho",
				Role = Roles.Customer,
			},
			new User
			{
				Id = 3,
				Username = "gosho",
				Role = Roles.Employee,
			}
		};

		public List<User> GetAll()
		{
			return this.users;
		}
	}
}
