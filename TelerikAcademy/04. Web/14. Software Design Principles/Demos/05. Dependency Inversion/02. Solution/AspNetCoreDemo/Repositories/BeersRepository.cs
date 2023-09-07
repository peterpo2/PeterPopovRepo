using AspNetCoreDemo.Exceptions;
using AspNetCoreDemo.Models;

using System;
using System.Collections.Generic;
using System.Linq;

namespace AspNetCoreDemo.Repositories
{
	public class BeersRepository : IBeersRepository
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
				Abv = 5.0
			},
			new Beer
			{
				Id = 3,
				Name = "Opasen Char",
				Abv = 6.6
			}
		};

		public BeersRepository()
		{

		}

		public List<Beer> GetAll()
		{
			return beers;
		}

		public Beer GetById(int id)
		{
			var beer = beers.Where(b => b.Id == id).FirstOrDefault();
			return beer ?? throw new EntityNotFoundException();
		}

		public Beer GetByName(string name)
		{
			var beer = beers.Where(b => b.Name == name).FirstOrDefault();
			
			return beer ?? throw new EntityNotFoundException();
		}

		public Beer Create(Beer beer)
		{
			beers.Add(beer);
			beer.Id = beers.Count;
			
			return beer;
		}

		public Beer Update(int id, Beer beer)
		{
			var beerToUpdate = this.GetById(id);
			beerToUpdate.Name = beer.Name;
			beerToUpdate.Abv = beer.Abv;
			
			return beerToUpdate;
		}

		public bool Delete(int id)
		{
			Beer beer = this.GetById(id);

			return beers.Remove(beer);
		}
	}
}
