using System.Collections.Generic;
using System.Linq;

using AspNetCoreDemo.Exceptions;
using AspNetCoreDemo.Models;

namespace AspNetCoreDemo.Repositories
{
	public class UsersRepository : IUsersRepository
	{
		private readonly List<User> users;

		public UsersRepository(IBeersRepository beersRepo)
		{
			this.users = new List<User>()
			{
				new User
				{
					Id = 1,
					Username = "administratarator",
					Role = Roles.Admin,
					Email = "admin@beeroverflow.com"
				},
				new User
				{
					Id = 2,
					Username = "pesho",
					Role = Roles.Customer,
					// Only customers have a list of favourite beers
					FavouriteBeers = new List<Beer>(beersRepo.GetAll())
				},
				new User
				{
					Id = 3,
					Username = "gosho",
					Role = Roles.Employee,
				}
			};
		}

		public User GetById(int id)
		{
			var user = this.users.Where(u => u.Id == id).FirstOrDefault();
			return user ?? throw new EntityNotFoundException();
		}
	}
}
