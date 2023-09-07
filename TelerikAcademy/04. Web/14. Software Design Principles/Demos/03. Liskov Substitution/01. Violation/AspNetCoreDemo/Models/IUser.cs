using System.Collections.Generic;

namespace AspNetCoreDemo.Models
{
	public interface IUser
	{
		public int Id { get; set; }
		public string Username { get; set; }
		public string Email { get; set; }
		public double Salary { get; set; }
		public List<Beer> FavouriteBeers { get; }
	}
}
