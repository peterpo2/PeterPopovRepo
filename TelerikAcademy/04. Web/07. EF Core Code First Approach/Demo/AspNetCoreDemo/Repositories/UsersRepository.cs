using System.Collections.Generic;
using System.Linq;

using AspNetCoreDemo.Data;
using AspNetCoreDemo.Exceptions;
using AspNetCoreDemo.Models;

namespace AspNetCoreDemo.Repositories
{
	public class UsersRepository : IUsersRepository
	{
		private readonly ApplicationContext context;

		public UsersRepository(ApplicationContext context)
		{
			this.context = context;
		}

		public List<User> GetAll()
		{
			return context.Users.ToList();
		}

		public User GetById(int id)
		{
			User user = context.Users.Where(u => u.Id == id).FirstOrDefault();

			return user ?? throw new EntityNotFoundException($"User with id={id} doesn't exist.");
		}

		public User GetByUsername(string username)
		{
			User user = context.Users.Where(u => u.Username == username).FirstOrDefault();

			return user ?? throw new EntityNotFoundException($"User with username={username} doesn't exist.");
		}
	}
}
