using System.Collections.Generic;

namespace AspNetCoreDemo.Models
{
	public class User
	{
		public int Id { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public Roles Role { get; set; }
		public List<Beer> FavouriteBeers { get; set; }
	}
}
