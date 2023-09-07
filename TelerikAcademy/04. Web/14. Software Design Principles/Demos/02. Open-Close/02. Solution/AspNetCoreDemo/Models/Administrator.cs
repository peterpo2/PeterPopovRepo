namespace AspNetCoreDemo.Models
{
	public class Administrator : BaseUser
	{
		public Administrator()
		{
			this.Role = Roles.Administrator;
		}

		public string Email { get; set; }

		public override string GetDisplayInfo()
		{
			return $"🐱‍👤 {this.Username}, e-mail: {this.Email}";
		}
	}
}
