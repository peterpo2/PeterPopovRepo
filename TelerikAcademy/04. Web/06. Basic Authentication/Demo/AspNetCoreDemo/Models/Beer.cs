namespace AspNetCoreDemo.Models
{
	public class Beer
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public double Abv { get; set; }
		public Style Style { get; set; }
		public User CreatedBy { get; set; }
	}
}
