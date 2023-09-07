using System.Collections.Generic;

namespace AspNetCoreDemo.Models
{
	public interface ICustomer : IUser
	{
		List<Beer> FavouriteBeers { get; }
		void AddToFavourites(Beer beer);
	}
}
