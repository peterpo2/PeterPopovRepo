using AspNetCoreDemo.Exceptions;
using AspNetCoreDemo.Models;

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
				Abv = 5.0,
			},
			new Beer
			{
				Id = 3,
				Name = "Opasen Char",
				Abv = 6.6,
			}
		};

		public Beer GetById(int id)
		{
			var beer = this.beers.Where(b => b.Id == id).FirstOrDefault();

			return beer ?? throw new EntityNotFoundException();
		}
	}
}
