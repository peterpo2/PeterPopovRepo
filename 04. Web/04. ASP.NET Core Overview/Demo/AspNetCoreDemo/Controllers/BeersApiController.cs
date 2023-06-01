using AspNetCoreDemo.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AspNetCoreDemo.Controllers
{
	[ApiController]
	[Route("api/beers")]
	public class BeersApiController : ControllerBase
	{
		// This list must be static so it can persist between requests,
		// because a new instance of the BeersApiController is created for each new request.
		private static readonly List<Beer> beers = new List<Beer>()
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
		};

		// This method handles GET requests sent to http://localhost:5000/api/beers
		[HttpGet("")]
		public IActionResult GetBeers()
		{
			return this.StatusCode(StatusCodes.Status200OK, beers);
		}

		// This method handles GET requests sent to http://localhost:5000/api/beers/:id 
		// 
		// Examples:
		// Send GET request to http://localhost:5000/api/beers/1
		// Send GET request to http://localhost:5000/api/beers/2
		[HttpGet("{id}")]
		public IActionResult GetBeerById(int id)
		{
			var beer = beers.FirstOrDefault(b => b.Id == id);

			if (beer == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound, $"Beer with id {id} doesn't exist.");
			}

			return this.StatusCode(StatusCodes.Status200OK, beer);
		}

		// This method handles POST requests sent to http://localhost:5000/api/beers
		// The parameter beer is an instance of class Beer and is created from the body of the request
		// 
		// Example:
		// Send POST request to http://localhost:5000/api/beers with body { "name": "Pirinsko",	"abv": 5.0 }
		[HttpPost("")]
		public IActionResult CreateBeer([FromBody] Beer beer)
		{
			// Update the id of the new beer before adding it to the list
			beer.Id = beers.Count;
			beers.Add(beer);

			return this.StatusCode(StatusCodes.Status201Created, beer);
		}

		// This method handles PUT requests sent to http://localhost:5000/api/beers/:id
		// The parameter beer is an instance of class Beer and is created from the body of the request
		//
		// Example:
		// Send PUT request to http://localhost:5000/api/beers/1 with body { "name": "Glarus English Ale", "abv": 6.6 }
		[HttpPut("{id}")]
		public IActionResult UpdateBeer(int id, [FromBody] Beer beer)
		{
			var beerToUpdate = beers.FirstOrDefault(b => b.Id == id);

			if (beerToUpdate == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound, $"Beer with id {id} doesn't exist.");
			}

			// Overwrite the values of Name and Abv
			beerToUpdate.Name = beer.Name;
			beerToUpdate.Abv = beer.Abv;

			return this.StatusCode(StatusCodes.Status200OK, beerToUpdate);
		}

		// This method handles DELETE requests sent to http://localhost:5000/api/beers/:id 
		// 
		// Examples:
		// Send DELETE request to http://localhost:5000/api/beers/1
		// Send DELETE request to http://localhost:5000/api/beers/2
		[HttpDelete("{id}")]
		public IActionResult DeleteBeer(int id)
		{
			var beerToDelete = beers.FirstOrDefault(b => b.Id == id);

			if (beerToDelete == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound, $"Beer with id {id} doesn't exist.");
			}

			beers.Remove(beerToDelete);

			return this.StatusCode(StatusCodes.Status200OK, beerToDelete);
		}

        /*[HttpDelete("{name}")]
        public IActionResult DeleteBeerByName(string name)
        {
            var beerToDelete = beers.FirstOrDefault(b => b.Id == id);

            if (beerToDelete == null)
            {
                return this.StatusCode(StatusCodes.Status404NotFound, $"Beer with id {id} doesn't exist.");
            }

            beers.Remove(beerToDelete);

            return this.StatusCode(StatusCodes.Status200OK, beerToDelete);
        }*/
    }
}
