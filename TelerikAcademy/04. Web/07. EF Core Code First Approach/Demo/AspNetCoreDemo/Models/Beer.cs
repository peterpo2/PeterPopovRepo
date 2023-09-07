using System.ComponentModel.DataAnnotations;

namespace AspNetCoreDemo.Models
{
	public class Beer
	{
		public int Id { get; set; }

		[Required]
		[StringLength(25)]
		public string Name { get; set; }

		public double Abv { get; set; }

		// Foreign key
		public int StyleId { get; set; }
		// Navigation property
		public Style Style { get; set; }

		// Foreign key
		public int CreatedById { get; set; }
		// Navigation property
		public User CreatedBy { get; set; }
	}
}
