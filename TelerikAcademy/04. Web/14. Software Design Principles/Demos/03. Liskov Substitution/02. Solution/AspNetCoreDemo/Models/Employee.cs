namespace AspNetCoreDemo.Models
{
	public class Employee : User, IEmployee
	{
		public double Salary
		{
			get;
			set;
		}
		
		public override string ToString()
		{
			string displayInfo = $"user: {this.Username}\n" +
								$"role: Employee\n" +
								$"salary: {this.Salary}";

			return displayInfo;
		}
	}
}
