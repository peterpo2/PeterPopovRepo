namespace AspNetCoreDemo.Models
{
	public class Administrator : User, IAdministrator
	{
		public string Email { get; set; }

		public override string ToString()
		{
			string displayInfo = $"user: {this.Username}\n" +
								$"role: Administrator\n" +
								$"e-mail: {this.Email}";

			return displayInfo;
		}
	}
}
