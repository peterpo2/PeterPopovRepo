using System.Collections.Generic;

using AspNetCoreDemo.Exceptions;
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

		public BeersApiController(IBeersService beersService)
		{
			this.beersService = beersService;
		}

		[HttpGet("")]
		public IActionResult GetBeers()
		{
			List<Beer> result = this.beersService.GetAll();
			
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
		public IActionResult CreateBeer([FromBody] Beer beer)
		{
			try
			{
				Beer createdBeer = this.beersService.Create(beer);

				return this.StatusCode(StatusCodes.Status201Created, beer);
			}
			catch (DuplicateEntityException e)
			{
				return this.StatusCode(StatusCodes.Status409Conflict, e.Message);
			}
		}

		[HttpPut("{id}")]
		public IActionResult UpdateBeer(int id, [FromBody] Beer beer)
		{
			if (id != beer.Id)
			{
				return this.StatusCode(StatusCodes.Status409Conflict, "Id mismatch");
			}

			try
			{
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
				this.beersService.Delete(id);

				return this.StatusCode(StatusCodes.Status200OK);
			}
			catch (EntityNotFoundException e)
			{
				return this.StatusCode(StatusCodes.Status404NotFound, e.Message);
			}
		}
	}
}
