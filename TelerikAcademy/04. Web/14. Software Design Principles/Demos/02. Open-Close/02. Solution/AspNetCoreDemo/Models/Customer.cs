using System.Collections.Generic;
using System.Linq;

namespace AspNetCoreDemo.Models
{
	public class Customer : BaseUser
	{
		public Customer()
		{
			this.Role = Roles.Customer;
		}
		
		public List<Beer> FavouriteBeers { get; set; }

		public override string GetDisplayInfo()
		{
			string favourites = string.Join(", ", this.FavouriteBeers.Select(beer => $"{beer.Name} ({beer.Abv}%)"));
			return $"🐱‍🚀 {this.Username}'s favourite beers are {favourites}";
		}
	}
}
