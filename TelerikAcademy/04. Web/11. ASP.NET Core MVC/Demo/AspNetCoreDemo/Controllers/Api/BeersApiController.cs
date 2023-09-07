using System.Collections.Generic;
using System.Linq;
using AspNetCoreDemo.Exceptions;
using AspNetCoreDemo.Helpers;
using AspNetCoreDemo.Models;
using AspNetCoreDemo.Models.DTO;
using AspNetCoreDemo.Services.Contracts;
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
		public IActionResult GetAll([FromQuery] BeerQueryParameters filterParameters)
		{
			List<BeerResponseDto> result = this.beersService.FilterBy(filterParameters)
															.Select(b => modelMapper.Map(b))
															.ToList();

			return this.StatusCode(StatusCodes.Status200OK, result);
		}

		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			try
			{
				Beer beer = this.beersService.GetById(id);
				BeerResponseDto beerResponseDto = modelMapper.Map(beer);

				return this.StatusCode(StatusCodes.Status200OK, beerResponseDto);
			}
			catch (EntityNotFoundException e)
			{
				return this.StatusCode(StatusCodes.Status404NotFound, e.Message);
			}
		}

		[HttpPost("")]
		public IActionResult Create([FromHeader] string username, [FromBody] BeerDto dto)
		{
			try
			{
				User user = this.authManager.TryGetUser(username);
				Beer beer = this.modelMapper.Map(dto);
				Beer createdBeer = this.beersService.Create(beer, user);

				return this.StatusCode(StatusCodes.Status201Created, createdBeer);
			}
			catch (UnauthorizedOperationException e)
			{
				return this.StatusCode(StatusCodes.Status401Unauthorized, e.Message);
			}
			catch (DuplicateEntityException e)
			{
				return this.StatusCode(StatusCodes.Status409Conflict, e.Message);
			}
		}

		[HttpPut("{id}")]
		public IActionResult Update(int id, [FromHeader] string username, [FromBody] BeerDto dto)
		{
			try
			{
				User user = this.authManager.TryGetUser(username);
				Beer beer = this.modelMapper.Map(dto);

				Beer updatedBeer = this.beersService.Update(id, beer, user);
				BeerResponseDto beerResponseDto = this.modelMapper.Map(updatedBeer);

				return this.StatusCode(StatusCodes.Status200OK, beerResponseDto);
			}
			catch (UnauthorizedOperationException e)
			{
				return this.StatusCode(StatusCodes.Status401Unauthorized, e.Message);
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
		public IActionResult Delete(int id, [FromHeader] string username)
		{
			try
			{
				User user = this.authManager.TryGetUser(username);
				Beer deletedBeer = this.beersService.Delete(id, user);
				BeerResponseDto beerResponseDto = this.modelMapper.Map(deletedBeer);

				return this.StatusCode(StatusCodes.Status200OK, beerResponseDto);
			}
			catch (UnauthorizedOperationException e)
			{
				return this.StatusCode(StatusCodes.Status401Unauthorized, e.Message);
			}
			catch (EntityNotFoundException e)
			{
				return this.StatusCode(StatusCodes.Status404NotFound, e.Message);
			}
		}
	}
}
