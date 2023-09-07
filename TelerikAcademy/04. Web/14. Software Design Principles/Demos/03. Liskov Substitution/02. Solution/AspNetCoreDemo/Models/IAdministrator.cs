namespace AspNetCoreDemo.Models
{
	public interface IAdministrator : IUser
	{
		string Email { get; set; }
	}
}
