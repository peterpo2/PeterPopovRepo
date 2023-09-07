using System.Collections.Generic;

namespace AspNetCoreDemo.Models
{
	public class Beer
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public double Abv { get; set; }

		public int StyleId { get; set; }
		public Style Style { get; set; }

		public int CreatedById { get; set; }
		public User CreatedBy { get; set; }

		public List<Rating> Ratings { get; set; }
	}
}
