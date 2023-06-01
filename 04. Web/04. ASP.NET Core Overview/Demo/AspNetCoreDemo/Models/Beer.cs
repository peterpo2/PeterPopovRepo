using System.ComponentModel.DataAnnotations;

namespace AspNetCoreDemo.Models
{
	public class Beer
	{
		public int Id { get; set; }

		[MinLength(2, ErrorMessage = "The {0} must be at least {1} characters long.")]
		[MaxLength(20, ErrorMessage = "The {0} must be no more than {1} characters long.")]
		public string Name { get; set; }

		[Range(0.1, 35, ErrorMessage = "The {0} must be between {1}% and {2}%.")]
		public double Abv { get; set; }
	}
}
