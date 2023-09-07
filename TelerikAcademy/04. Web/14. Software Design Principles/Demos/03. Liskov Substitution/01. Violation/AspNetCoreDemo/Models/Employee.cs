using System;
using System.Collections.Generic;

namespace AspNetCoreDemo.Models
{
	public class Employee : IUser
	{
		public int Id
		{
			get;
			set;
		}
		public string Username
		{
			get;
			set;
		}
		public string Email
		{
			get => throw new NotSupportedException("Employees don't have an e-mail!");
			set => throw new NotSupportedException("Employees don't have an e-mail!");
		}
		public List<Beer> FavouriteBeers
		{
			get => throw new NotSupportedException("Employees don't have a favourite beers list!");
		}
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
