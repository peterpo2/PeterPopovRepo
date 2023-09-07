namespace AspNetCoreDemo.Models
{
	public abstract class BaseUser
	{
		public int Id { get; set; }
		public string Username { get; set; }
		public Roles Role { get; protected set; }
		public abstract string GetDisplayInfo();
	}
}
