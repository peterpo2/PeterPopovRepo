namespace AspNetCoreDemo.Models
{
	public interface IEmployee : IUser
	{
		double Salary { get; set; }
	}
}
