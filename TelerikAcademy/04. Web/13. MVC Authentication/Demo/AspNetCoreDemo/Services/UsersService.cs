using System.Collections.Generic;

using AspNetCoreDemo.Exceptions;
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
			return this.repository.GetAll();
		}

		public User GetById(int id)
		{
			return this.repository.GetById(id);
		}

		public User GetByUsername(string username)
		{
			return this.repository.GetByUsername(username);
		}

		public User Create(User user)
		{
			bool duplicateExists = true;

			try
			{
				_ = this.repository.GetByUsername(user.Username);
			}
			catch (EntityNotFoundException)
			{
				duplicateExists = false;
			}

			if (duplicateExists)
			{
				throw new DuplicateEntityException($"Username {user.Username} already exists.");
			}

			User createdUser = this.repository.Create(user);

			return createdUser;
		}

		public bool UsernameExists(string username)
		{
			bool usernameExists = true;

			try
			{
				_ = this.repository.GetByUsername(username);
			}
			catch (EntityNotFoundException)
			{
				usernameExists = false;
			}

			return usernameExists;
		}
	}
}
