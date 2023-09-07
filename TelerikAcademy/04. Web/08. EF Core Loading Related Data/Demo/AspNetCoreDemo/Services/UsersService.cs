using System.Collections.Generic;

using AspNetCoreDemo.Models;
using AspNetCoreDemo.Repositories;

namespace AspNetCoreDemo.Services
{
	public class UsersService : IUsersService
	{
		private readonly IUsersRepository repository;

		public UsersService(IUsersRepository repository)
		{
			this.repository = repository;
		}

		public List<User> GetAll()
		{
			return repository.GetAll();
		}

		public User GetById(int id)
		{
			return repository.GetById(id);
		}

		public User GetByUsername(string username)
		{
			return repository.GetByUsername(username);
		}
	}
}
