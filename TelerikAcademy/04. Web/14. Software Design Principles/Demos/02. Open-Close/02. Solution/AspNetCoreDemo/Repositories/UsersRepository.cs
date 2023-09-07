using System.Collections.Generic;
using System.Linq;

using AspNetCoreDemo.Exceptions;
using AspNetCoreDemo.Models;

namespace AspNetCoreDemo.Repositories
{
	public class UsersRepository : IUsersRepository
	{
		private readonly List<BaseUser> users;

		public UsersRepository(IBeersRepository beersRepo)
		{
			this.users = new List<BaseUser>()
			{
				new Administrator
				{
					Id = 1,
					Username = "Administratarator",
					Email = "admin@daj-bozhe.com"
				},
				new Customer
				{
					Id = 2,
					Username = "pesho",
					// Only customers have a list of favourite beers
					FavouriteBeers = new List<Beer>(beersRepo.GetAll())
				},
				new Employee
				{
					Id = 3,
					Username = "gosho",
				}
			};
		}

		public BaseUser GetById(int id)
		{
			var user = this.users.Where(u => u.Id == id).FirstOrDefault();
			return user ?? throw new EntityNotFoundException();
		}
	}
}
