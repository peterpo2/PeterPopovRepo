﻿using AspNetCoreDemo.Models;

using System.Collections.Generic;

namespace AspNetCoreDemo.Repositories
{
	public class BeersRepository : IRepository<Beer>
	{
		private readonly List<Beer> beers = new List<Beer>()
		{
			new Beer
			{
				Id = 1,
				Name = "Glarus English Ale",
				Abv = 4.6
			},
			new Beer
			{
				Id = 2,
				Name = "Rhombus Porter",
				Abv = 5.0,
			},
			new Beer
			{
				Id = 3,
				Name = "Opasen Char",
				Abv = 6.6,
			}
		};

		public void Create(Beer beer)
		{
			this.beers.Add(beer);
			beer.Id = this.beers.Count;
		}

		public List<Beer> GetAll()
		{
			return this.beers;
		}
	}
}
