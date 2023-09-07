using System.Collections.Generic;
using System.Linq;

using AspNetCoreDemo.Exceptions;
using AspNetCoreDemo.Models;

namespace AspNetCoreDemo.Repositories
{
	public class BeersRepository : IBeersRepository
	{
		private readonly IStylesRepository stylesRepository;
		private readonly List<Beer> beers;

		public BeersRepository(IStylesRepository stylesRepository)
		{
			this.stylesRepository = stylesRepository;
			
			this.beers = new List<Beer>();
			this.beers.Add(new Beer
			{
				Id = 1,
				Name = "Glarus English Ale",
				Abv = 4.6,
				Style = this.stylesRepository.GetById(id: 1)
			});
			this.beers.Add(new Beer
			{
				Id = 2,
				Name = "Rhombus Porter",
				Abv = 5.0,
				Style = this.stylesRepository.GetById(id: 2)
			});
			this.beers.Add(new Beer
			{
				Id = 3,
				Name = "Opasen Char",
				Abv = 6.6,
				Style = this.stylesRepository.GetById(id: 3)
			});
		}

		public Beer GetByName(string name)
		{
			var beer = this.beers.Where(b => b.Name == name).FirstOrDefault();
			return beer ?? throw new EntityNotFoundException();
		}

		public Beer Create(Beer beer)
		{
			beer.Id = this.beers.Count + 1;
			this.beers.Add(beer);
			return beer;
		}
	}
}
