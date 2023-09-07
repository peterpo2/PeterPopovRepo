using System.Collections.Generic;

namespace AspNetCoreDemo.Models
{
	public class Customer : User, ICustomer
	{
		private readonly List<Beer> favouriteBeers = new List<Beer>();

		public List<Beer> FavouriteBeers
		{
			get => new List<Beer>(this.favouriteBeers);
		}
		public void AddToFavourites(Beer beer)
		{
			this.favouriteBeers.Add(beer);
		}
		
		public override string ToString()
		{
			string displayInfo = $"user: {this.Username}\n" +
								$"role: Customer\n" +
								$"favourite beers: {string.Join(", ", this.favouriteBeers)}";

			return displayInfo;
		}
	}
}
