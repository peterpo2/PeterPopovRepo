using System;
using System.Collections.Generic;

namespace AspNetCoreDemo.Models
{
	public class Administrator : IUser
	{
		public int Id { get; set; }
		public string Username { get; set; }
		public string Email { get; set; }
		public List<Beer> FavouriteBeers
		{
			get => throw new NotSupportedException("Administrators don't have a favourite beers list!");
		}
		public double Salary
		{
			get => throw new NotSupportedException("Administrators don't have a salary!");
			set => throw new NotSupportedException("Administrators don't have a salary!");
		}
		public override string ToString()
		{
			string displayInfo = $"user: {this.Username}\n" +
								$"role: Administrator\n" +
								$"e-mail: {this.Email}";

			return displayInfo;
		}
	}
}
