using System;
using System.Collections.Generic;

namespace AspNetCoreDemo.Models
{
	public class Customer : IUser
	{
		private readonly List<Beer> favouriteBeers = new List<Beer>();

		public int Id
		{
			get;
			set;
		}
		public string Username
		{
			get;
			set;
		}
		public string Email
		{
			get => throw new NotSupportedException("Customer role doesn't have an e-mail.");
			set => throw new NotSupportedException("Customer role doesn't have an e-mail.");
		}
		public List<Beer> FavouriteBeers
		{
			get => new List<Beer>(this.favouriteBeers);
		}
		public double Salary
		{
			get => throw new NotSupportedException("Customer role doesn't have a salary.");
			set => throw new NotSupportedException("Customer role doesn't have a salary.");
		}

		public void AddFavouriteBeer(Beer beer)
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
