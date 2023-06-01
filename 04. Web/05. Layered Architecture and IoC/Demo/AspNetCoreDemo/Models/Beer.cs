using System.ComponentModel.DataAnnotations;

namespace AspNetCoreDemo.Models
{
	public class Beer
	{
		public int Id { get; set; }

		[StringLength(25, MinimumLength = 1, ErrorMessage = "The {0} must be between {1} and {2} characters long.")]
		public string Name { get; set; }

		[Range(0.1, 35, ErrorMessage = "The {0} must be between {1}% and {2}%.")]
		public double Abv { get; set; }
	}
}
