using AspNetCoreDemo.Exceptions;
using AspNetCoreDemo.Helpers;
using AspNetCoreDemo.Models;
using AspNetCoreDemo.Services;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreDemo.Controllers.Web
{
	public class BeersController : Controller
	{
		private readonly IBeersService beersService;
		private readonly AuthManager authManager;

		public BeersController(IBeersService beersService, AuthManager authManager)
		{
			this.beersService = beersService;
			this.authManager = authManager;
		}

		[HttpGet]
		public IActionResult Index()
		{
			var beers = this.beersService.GetAll();

			return this.View(beers);
		}

		[HttpGet]
		public IActionResult Details([FromRoute] int id)
		{
			try
			{
				var beer = this.beersService.GetById(id);

				return this.View(beer);
			}
			catch (EntityNotFoundException ex)
			{
				this.Response.StatusCode = StatusCodes.Status404NotFound;
				this.ViewData["ErrorMessage"] = ex.Message;

				return this.View("Error");
			}
		}

		[HttpGet]
		public IActionResult Create()
		{
			if (this.authManager.CurrentUser == null)
			{
				return this.RedirectToAction("Login", "Users");
			}

			var beer = new Beer();

			return this.View(beer);
		}

		[HttpPost]
		public IActionResult Create(Beer beer)
		{
			if (!this.ModelState.IsValid)
			{
				return this.View(beer);
			}

			if (this.authManager.CurrentUser == null)
			{
				return this.RedirectToAction("Login", "Users");
			}

			var user = this.authManager.CurrentUser;
			var createdBeer = this.beersService.Create(beer, user);

			return this.RedirectToAction("Details", "Beers", new { id = createdBeer.Id });
		}

		[HttpGet]
		public IActionResult Edit([FromRoute] int id)
		{
			if (this.authManager.CurrentUser == null)
			{
				return this.RedirectToAction(actionName: "Login", controllerName: "Users");
			}

			try
			{
				var beer = this.beersService.GetById(id);

				if(beer.CreatedById != this.authManager.CurrentUser.Id && !this.authManager.CurrentUser.IsAdmin)
				{
					this.Response.StatusCode = StatusCodes.Status403Forbidden;
					this.ViewData["ErrorMessage"] = $"You cannot edit beer with id={beer.Id} since your are not the author.";

					return this.View("Error");
				}

				return this.View(beer);
			}
			catch (EntityNotFoundException ex)
			{
				this.Response.StatusCode = StatusCodes.Status404NotFound;
				this.ViewData["ErrorMessage"] = ex.Message;

				return this.View("Error");
			}
		}

		[HttpPost]
		public IActionResult Edit([FromRoute] int id, Beer beer)
		{
			if (!this.ModelState.IsValid)
			{
				return this.View(beer);
			}

			try
			{
				var user = this.authManager.CurrentUser;
				var updatedBeer = this.beersService.Update(id, beer, user);

				return this.RedirectToAction("Index", "Beers");
			}
			catch (EntityNotFoundException ex)
			{
				this.Response.StatusCode = StatusCodes.Status404NotFound;
				this.ViewData["ErrorMessage"] = ex.Message;

				return this.View("Error");
			}
			catch (UnauthorizedOperationException ex)
			{
				this.Response.StatusCode = StatusCodes.Status403Forbidden;
				this.ViewData["ErrorMessage"] = ex.Message;

				return this.View("Error");
			}
		}

		[HttpGet]
		public IActionResult Delete([FromRoute] int id)
		{
			try
			{
				var beer = this.beersService.GetById(id);

				return this.View(beer);
			}
			catch (EntityNotFoundException ex)
			{
				this.Response.StatusCode = StatusCodes.Status404NotFound;
				this.ViewData["ErrorMessage"] = ex.Message;

				return this.View("Error");
			}
		}

		[HttpPost, ActionName("Delete")]
		public IActionResult DeleteConfirmed([FromRoute] int id)
		{
			try
			{
				// Warning: We bypass authentication and authorization just for this demo
				var user = this.authManager.TryGetUser("admin");
				this.beersService.Delete(id, user);

				return this.RedirectToAction("Index", "Beers");
			}
			catch (EntityNotFoundException ex)
			{
				this.Response.StatusCode = StatusCodes.Status404NotFound;
				this.ViewData["ErrorMessage"] = ex.Message;

				return this.View("Error");
			}
		}
	}
}
