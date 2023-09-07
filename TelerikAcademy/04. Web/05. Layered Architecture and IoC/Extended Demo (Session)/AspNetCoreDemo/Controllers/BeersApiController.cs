using System.Collections.Generic;

using AspNetCoreDemo.Exceptions;
using AspNetCoreDemo.Helpers;
using AspNetCoreDemo.Models;
using AspNetCoreDemo.Services;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreDemo.Controllers
{
	[ApiController]
	[Route("api/beers")]
	public class BeersApiController : ControllerBase
	{
		private readonly IBeersService beersService;
		private readonly BeerMapper beerMapper;

		public BeersApiController(IBeersService beersService, BeerMapper beerMapper)
		{
			this.beersService = beersService;
			this.beerMapper = beerMapper;
		}

		[HttpGet("")]
		public IActionResult GetBeers([FromQuery] BeerQueryParameters filterParameters)
		{
			List<Beer> result = this.beersService.FilterBy(filterParameters);

			return this.StatusCode(StatusCodes.Status200OK, result);
		}

		[HttpGet("{id}")]
		public IActionResult GetBeerById(int id)
		{
			try
			{
				Beer beer = this.beersService.GetById(id);
				
				return this.StatusCode(StatusCodes.Status200OK, beer);
			}
			catch (EntityNotFoundException e)
			{
				return this.StatusCode(StatusCodes.Status404NotFound, e.Message);
			}
		}

		[HttpPost("")]
		public IActionResult CreateBeer([FromBody] BeerDto beerDto)
		{
			try
			{
				Beer beer = this.beerMapper.Map(beerDto);
				Beer createdBeer = this.beersService.Create(beer);
				
				return this.StatusCode(StatusCodes.Status201Created, createdBeer);
			}
			catch (DuplicateEntityException e)
			{
				return this.StatusCode(StatusCodes.Status409Conflict, e.Message);
			}
		}

		[HttpPut("{id}")]
		public IActionResult UpdateBeer(int id, [FromBody] BeerDto beerDto)
		{
			try
			{
				Beer beer = this.beerMapper.Map(beerDto);
				Beer updatedBeer = this.beersService.Update(id, beer);
				
				return this.StatusCode(StatusCodes.Status200OK, updatedBeer);
			}
			catch (EntityNotFoundException e)
			{
				return this.StatusCode(StatusCodes.Status404NotFound, e.Message);
			}
			catch (DuplicateEntityException e)
			{
				return this.StatusCode(StatusCodes.Status409Conflict, e.Message);
			}
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteBeer(int id)
		{
			try
			{
				var deletedBeer = this.beersService.Delete(id);
				
				return this.StatusCode(StatusCodes.Status200OK, deletedBeer);
			}
			catch (EntityNotFoundException e)
			{
				return this.StatusCode(StatusCodes.Status404NotFound, e.Message);
			}
		}
	}
}
