using System.Collections.Generic;
using System.Linq;

using AspNetCoreDemo.Data;
using AspNetCoreDemo.Exceptions;
using AspNetCoreDemo.Models;
using AspNetCoreDemo.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

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
			return this.GetUsers().ToList();
		}

		public User GetById(int id)
		{
			User user = this.GetUsers().Where(u => u.Id == id).FirstOrDefault();

			return user ?? throw new EntityNotFoundException($"User with id={id} doesn't exist.");
		}

		public User GetByUsername(string username)
		{
			User user = this.GetUsers().Where(u => u.Username == username).FirstOrDefault();

			return user ?? throw new EntityNotFoundException($"User with username={username} doesn't exist.");
		}

		public bool UserExists(string username)
		{
			return this.context.Users.Any(u => u.Username == username);
		}

		public User Create(User user)
		{
			var createdUser = context.Users.Add(user);
			context.SaveChanges();
			return createdUser.Entity;
		}

		private IQueryable<User> GetUsers()
		{
			return this.context.Users
					.Include(user => user.Ratings)
						.ThenInclude(rating => rating.Beer)
							.ThenInclude(beer => beer.Style);
		}
	}
}
