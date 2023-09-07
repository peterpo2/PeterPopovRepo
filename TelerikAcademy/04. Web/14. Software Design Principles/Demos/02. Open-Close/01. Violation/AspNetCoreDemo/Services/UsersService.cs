using System.Linq;

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

		public User GetById(int id)
		{
			return this.repository.GetById(id);
		}

		public string GetDisplayInfo(User user)
		{
			if (user.Role == Roles.Admin)
			{
				return $"🐱‍👤 {user.Username}, Email: {user.Email}";
			}
			else if (user.Role == Roles.Customer)
			{
				string favourites = string.Join(", ", user.FavouriteBeers.Select(beer => $"{beer.Name} ({beer.Abv}%)"));
				return $"🐱‍🚀 {user.Username}'s favourite beers are {favourites}";
			}
			else
			{
				return $"🐱‍💻 {user.Username}";
			}
		}
	}
}
