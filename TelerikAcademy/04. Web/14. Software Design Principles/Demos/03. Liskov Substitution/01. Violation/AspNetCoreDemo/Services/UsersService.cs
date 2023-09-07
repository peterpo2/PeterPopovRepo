
using AspNetCoreDemo.Models;
using AspNetCoreDemo.Repositories;

namespace AspNetCoreDemo.Services
{
	public class UsersService : IUsersService
	{
		private readonly IUsersRepository usersRepo;

		public UsersService(IUsersRepository usersRepo)
		{
			this.usersRepo = usersRepo;
		}

		public IUser GetById(int id)
		{
			return this.usersRepo.GetById(id);
		}
	}
}
