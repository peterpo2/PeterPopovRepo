using System.Collections.Generic;
using System.Linq;

using AspNetCoreDemo.Exceptions;
using AspNetCoreDemo.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreDemo.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class BeersController : ControllerBase
	{
		[HttpPost("")]
		public IActionResult Create([FromBody] BeerDto dto)
		{
			try
			{
				Beer newBeer = new Beer();
				newBeer.Abv = dto.Abv;
				newBeer.Name = dto.Name;
				newBeer.Style = styles.Where(style => style.Id == dto.StyleId).FirstOrDefault() ?? throw new EntityNotFoundException();
				
				bool duplicateExists = true;

				try
				{
					_ = beers.Where(b => b.Name == newBeer.Name).FirstOrDefault() ?? throw new EntityNotFoundException();
				}
				catch (EntityNotFoundException)
				{
					duplicateExists = false;
				}

				if (duplicateExists)
				{
					throw new DuplicateEntityException();
				}

				beers.Add(newBeer);
				newBeer.Id = beers.Count;

				return this.StatusCode(StatusCodes.Status201Created, newBeer);
			}
			catch (DuplicateEntityException e)
			{
				return this.StatusCode(StatusCodes.Status409Conflict, e.Message);
			}
			catch (EntityNotFoundException e)
			{
				return this.StatusCode(StatusCodes.Status404NotFound, e.Message);
			}
		}

		private static readonly List<Style> styles = new List<Style>()
		{
			new Style
			{
				Id = 1,
				Name = "Special Ale"
			},
			new Style
			{
				Id = 2,
				Name = "English Porter"
			},
			new Style
			{
				Id = 3,
				Name = "Indian Pale Ale"
			}
		};
		private static readonly List<Beer> beers = new List<Beer>()
		{
			new Beer
			{
				Id = 1,
				Name = "Glarus English Ale",
				Abv = 4.6,
				Style = styles[0]
			},
			new Beer
			{
				Id = 2,
				Name = "Rhombus Porter",
				Abv = 5.0,
				Style = styles[1]
			},
			new Beer
			{
				Id = 3,
				Name = "Opasen Char",
				Abv = 6.6,
				Style = styles[2]
			}
		};
	}
}
