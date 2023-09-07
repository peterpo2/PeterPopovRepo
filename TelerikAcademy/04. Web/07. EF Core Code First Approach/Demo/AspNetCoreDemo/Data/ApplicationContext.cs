﻿using System.Collections.Generic;

using AspNetCoreDemo.Models;

using Microsoft.EntityFrameworkCore;

namespace AspNetCoreDemo.Data
{
	public class ApplicationContext : DbContext
	{
		public ApplicationContext(DbContextOptions<ApplicationContext> options)
			: base(options)
		{
		}

		public DbSet<Beer> Beers { get; set; }
		public DbSet<Style> Styles { get; set; }
		public DbSet<User> Users { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// Seed the database with users
			List<User> users = new List<User>()
			{
				new User { Id = 1, Username = "admin", IsAdmin = true },
				new User { Id = 2, Username = "george", IsAdmin = false },
				new User { Id = 3, Username = "peter", IsAdmin = false }
			};
			modelBuilder.Entity<User>().HasData(users);

			// Seed the database with styles
			List<Style> styles = new List<Style>()
			{
				new Style { Id = 1, Name = "Special Ale" },
				new Style { Id = 2, Name = "English Porter" },
				new Style { Id = 3, Name = "Indian Pale Ale" }
			};
			modelBuilder.Entity<Style>().HasData(styles);

			// Seed the database with beers
			List<Beer> beers = new List<Beer>()
			{
				new Beer { Id = 1, Name = "Glarus English Ale", Abv = 4.6, CreatedById = 2 /*george*/, StyleId = 1 /* Special Ale */ },
				new Beer { Id = 2, Name = "Rhombus Porter", Abv = 5.0, CreatedById = 2 /*george*/, StyleId = 2 /* English Porter */ },
				new Beer { Id = 3, Name = "Opasen Char", Abv = 6.6, CreatedById = 3 /*peter*/, StyleId = 3 /* Indian Pale Ale */ }
			};
			modelBuilder.Entity<Beer>().HasData(beers);
		}
	}
}