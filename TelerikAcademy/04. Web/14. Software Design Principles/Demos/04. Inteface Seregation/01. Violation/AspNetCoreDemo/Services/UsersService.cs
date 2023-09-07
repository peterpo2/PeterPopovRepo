using System.Collections.Generic;

using AspNetCoreDemo.Models;
using AspNetCoreDemo.Repositories;

namespace AspNetCoreDemo.Services
{
	public class UsersService : IService<User>
	{
		private readonly IRepository<User> repository;

		public UsersService(IRepository<User> repository)
		{
			this.repository = repository;
		}

		public void Create(User user)
		{
			this.repository.Create(user);
		}

		public List<User> GetAll()
		{
			return this.repository.GetAll();
		}
	}
}
