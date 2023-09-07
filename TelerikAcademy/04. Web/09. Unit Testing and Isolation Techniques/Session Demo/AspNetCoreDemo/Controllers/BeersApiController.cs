using System.Collections.Generic;
using System.Linq;
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
		private readonly ModelMapper modelMapper;
		private readonly AuthManager authManager;

		public BeersApiController(IBeersService beersService, ModelMapper modelMapper, AuthManager authManager)
		{
			this.beersService = beersService;
			this.modelMapper = modelMapper;
			this.authManager = authManager;
		}

		[HttpGet("")]
		public IActionResult GetBeers([FromQuery] BeerQueryParameters filterParameters)
		{
			//List<Beer> result = beersService.FilterBy(filterParameters);
			//List<Beer> result = beersService.GetAll();
			List<BeerResponseDto> result = beersService.GetAll()
														.Select(beer => new BeerResponseDto(beer))
														.ToList();

			return StatusCode(StatusCodes.Status200OK, result);
		}

		[HttpGet("{id}")]
		public IActionResult GetBeerById(int id)
		{
			try
			{
				Beer beer = beersService.GetById(id);

				return StatusCode(StatusCodes.Status200OK, beer);
			}
			catch (EntityNotFoundException e)
			{
				return StatusCode(StatusCodes.Status404NotFound, e.Message);
			}
		}

		[HttpPost("")]
		public IActionResult CreateBeer([FromHeader] string username, [FromBody] BeerDto dto)
		{
			try
			{
				User user = authManager.TryGetUser(username);
				Beer beer = modelMapper.Map(dto);
				Beer createdBeer = beersService.Create(beer, user);

				return StatusCode(StatusCodes.Status201Created, createdBeer);
			}
			catch (UnauthorizedOperationException e)
			{
				return StatusCode(StatusCodes.Status401Unauthorized, e.Message);
			}
			catch (DuplicateEntityException e)
			{
				return StatusCode(StatusCodes.Status409Conflict, e.Message);
			}
		}

		[HttpPut("{id}")]
		public IActionResult UpdateBeer(int id, [FromHeader] string username, [FromBody] BeerDto dto)
		{
			try
			{
				User user = authManager.TryGetUser(username);
				Beer beer = modelMapper.Map(dto);

				Beer updatedBeer = beersService.Update(id, beer, user);

				return StatusCode(StatusCodes.Status200OK, updatedBeer);
			}
			catch (UnauthorizedOperationException e)
			{
				return StatusCode(StatusCodes.Status401Unauthorized, e.Message);
			}
			catch (EntityNotFoundException e)
			{
				return StatusCode(StatusCodes.Status404NotFound, e.Message);
			}
			catch (DuplicateEntityException e)
			{
				return StatusCode(StatusCodes.Status409Conflict, e.Message);
			}
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteBeer(int id, [FromHeader] string username)
		{
			try
			{
				User user = authManager.TryGetUser(username);
				Beer removedBeer = beersService.Delete(id, user);

				return StatusCode(StatusCodes.Status200OK, removedBeer);
			}
			catch (UnauthorizedOperationException e)
			{
				return StatusCode(StatusCodes.Status401Unauthorized, e.Message);
			}
			catch (EntityNotFoundException e)
			{
				return StatusCode(StatusCodes.Status404NotFound, e.Message);
			}
		}
	}
}
