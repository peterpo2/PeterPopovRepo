using AspNetCoreDemo.Exceptions;
using AspNetCoreDemo.Mappers;
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
		private readonly ModelMapper mapper;

		public BeersController(IBeersService beersService, ModelMapper mapper)
		{
			this.beersService = beersService;
			this.mapper = mapper;
		}

		[HttpPost("")]
		public IActionResult Create([FromBody] BeerDto dto)
		{
			try
			{
				var beer = this.mapper.Map(dto);
				var createdBeer = this.beersService.Create(beer);
				return this.StatusCode(StatusCodes.Status201Created, createdBeer);
			}
			catch (DuplicateEntityException e)
			{
				return this.StatusCode(StatusCodes.Status409Conflict, e.Message);
			}
		}
	}
}
