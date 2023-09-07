
using AspNetCoreDemo.Models;
using AspNetCoreDemo.Repositories;

namespace AspNetCoreDemo.Services
{
	public class UsersService : IUsersService
	{
		private readonly IUsersRepository repository;

		public UsersService(IUsersRepository usersRepo)
		{
			this.repository = usersRepo;
		}

		public T GetById<T>(int id) where T : IUser
		{
			return this.repository.GetById<T>(id);
		}
	}
}
