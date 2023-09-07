using System.Collections.Generic;

using AspNetCoreDemo.Exceptions;
using AspNetCoreDemo.Models;
using AspNetCoreDemo.Services;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreDemo.Controllers
{
	[ApiController]
	[Route("api/styles")]
	public class StylesApiController : ControllerBase
	{
		private readonly IStylesService stylesService;

		public StylesApiController(IStylesService stylesService)
		{
			this.stylesService = stylesService;
		}

		[HttpGet("")]
		public IActionResult Get()
		{
			List<Style> styles = stylesService.GetAll();
			
			return StatusCode(StatusCodes.Status200OK, styles);
		}

		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			try
			{
				Style style = stylesService.GetById(id);
				
				return StatusCode(StatusCodes.Status200OK, style);
			}
			catch (EntityNotFoundException e)
			{
				return StatusCode(StatusCodes.Status404NotFound, e.Message);
			}
		}
	}
}