namespace AspNetCoreDemo.Models
{
	public class Employee : BaseUser
	{
		public Employee()
		{
			this.Role = Roles.Employee;
		}

		public override string GetDisplayInfo()
		{
			return $"🐱‍💻 {this.Username}";
		}
	}
}
