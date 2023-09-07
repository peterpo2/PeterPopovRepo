namespace AspNetCoreDemo.Models
{
	public abstract class User : IUser
	{
		public int Id { get; set; }
		public string Username { get; set; }
	}
}
