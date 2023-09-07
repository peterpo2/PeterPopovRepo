using AspNetCoreDemo.Exceptions;
using AspNetCoreDemo.Models;
using AspNetCoreDemo.Services;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreDemo.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class BeersController : ControllerBase
	{
		private readonly IBeersService beersService;

		public BeersController(IBeersService beersService)
		{
			this.beersService = beersService;
		}

		[HttpGet("")]
		public IActionResult Get()
		{
			var beers = this.beersService.GetAll();

			return this.StatusCode(StatusCodes.Status200OK, beers);
		}

		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			try
			{
				var beer = this.beersService.GetById(id);

				return this.StatusCode(StatusCodes.Status200OK, beer);
			}
			catch (EntityNotFoundException e)
			{
				return this.StatusCode(StatusCodes.Status404NotFound, e.Message);
			}
		}

		[HttpPost("")]
		public IActionResult Create([FromBody] Beer beer)
		{
			try
			{
				var createdBeer = this.beersService.Create(beer);
				return this.StatusCode(StatusCodes.Status201Created, beer);
			}
			catch (DuplicateEntityException e)
			{
				return this.StatusCode(StatusCodes.Status409Conflict, e.Message);
			}
		}

		[HttpPut("{id}")]
		public IActionResult Update(int id, [FromBody] Beer beer)
		{
			if(id != beer.Id)
			{
				return this.StatusCode(StatusCodes.Status409Conflict, "Id mismatch");
			}
			try
			{
				var updatedBeer = this.beersService.Update(id, beer);
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
		public IActionResult Delete(int id)
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
