using System.Collections.Generic;

using AspNetCoreDemo.Models;
using AspNetCoreDemo.Repositories;

namespace AspNetCoreDemo.Services
{
	public class UsersService : IReadOnlyService<User>
	{
		private readonly IReadOnlyRepository<User> repository;

		public UsersService(IReadOnlyRepository<User> repository)
		{
			this.repository = repository;
		}

		public List<User> GetAll()
		{
			return this.repository.GetAll();
		}
	}
}
