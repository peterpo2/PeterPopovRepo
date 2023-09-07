using System.Collections.Generic;

using AspNetCoreDemo.Exceptions;
using AspNetCoreDemo.Models;
using AspNetCoreDemo.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreDemo.Controllers.Web
{
    public class BeersController : Controller
    {
        private readonly IBeersService beersService;

        public BeersController(IBeersService beersService)
        {
            this.beersService = beersService;
        }

		[HttpGet]        
        public IActionResult Index()
        {
			List<Beer> beers = this.beersService.GetAll();

            return this.View(beers);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            try
            {
				Beer beer = this.beersService.GetById(id);

                return this.View(beer);
            }
            catch (EntityNotFoundException e)
            {
                this.Response.StatusCode = StatusCodes.Status404NotFound;
                this.ViewData["ErrorMessage"] = e.Message;

                return this.View("Error");
            }
        }
    }
}
