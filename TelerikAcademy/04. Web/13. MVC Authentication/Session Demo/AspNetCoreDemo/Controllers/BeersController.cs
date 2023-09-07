using AspNetCoreDemo.Exceptions;
using AspNetCoreDemo.Helpers;
using AspNetCoreDemo.Models.ViewModels;
using AspNetCoreDemo.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace AspNetCoreDemo.Controllers.Web
{
    public class BeersController : Controller
	{
		private readonly IBeersService beersService;
        private readonly IStylesService stylesService;
        private readonly AuthManager authManager;
        private readonly ModelMapper modelMapper;

        public BeersController(IBeersService beersService, IStylesService stylesService, AuthManager authManager, ModelMapper modelMapper)
        {
            this.beersService = beersService;
            this.stylesService = stylesService;
            this.authManager = authManager;
            this.modelMapper = modelMapper;
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
            if (!this.HttpContext.Session.Keys.Contains("LoggedUser"))
            {
                return RedirectToAction("Login", "Auth");
            }

           /* if (this.HttpContext.Session.GetString("LoggedUser") == null)
            {
                RedirectToAction("Login", "Auth");
            }*/

            var beerViewModel = new BeerViewModel();
            this.InitializeDropDownLists(beerViewModel);

            return this.View(beerViewModel);
        }

        [HttpPost]
        public IActionResult Create(BeerViewModel beerViewModel)
        {
            if (!this.ModelState.IsValid)
            {
                this.InitializeDropDownLists(beerViewModel);
                return this.View(beerViewModel);
            }

            try
            {
                var user = this.authManager.TryGetUser("admin");
                var beer = this.modelMapper.Map(beerViewModel);
                var createdBeer = this.beersService.Create(beer, user);

                return this.RedirectToAction("Details", "Beers", new { id = createdBeer.Id });
            }
            catch (DuplicateEntityException ex)
            {
                this.ModelState.AddModelError("Name", ex.Message);
                this.InitializeDropDownLists(beerViewModel);
                return this.View(beerViewModel);
            }
        }

        [HttpGet]
        public IActionResult Edit([FromRoute] int id)
        {
            try
            {
                var beer = this.beersService.GetById(id);
                var beerViewModel = new BeerViewModel()
                {
                    Name = beer.Name,
                    Abv = beer.Abv,
                    StyleId = beer.StyleId,
                };
                this.InitializeDropDownLists(beerViewModel);

                return this.View(beerViewModel);
            }
            catch (EntityNotFoundException ex)
            {
                this.Response.StatusCode = StatusCodes.Status404NotFound;
                this.ViewData["ErrorMessage"] = ex.Message;

                return this.View("Error");
            }
        }

        [HttpPost]
        public IActionResult Edit([FromRoute] int id, BeerViewModel beerViewModel)
        {
            if (!this.ModelState.IsValid)
            {
                this.InitializeDropDownLists(beerViewModel);
                return this.View(beerViewModel);
            }

            var user = this.authManager.TryGetUser("admin");
            var beer = this.modelMapper.Map(beerViewModel);
            var updatedBeer = this.beersService.Update(id, beer, user);

            return this.RedirectToAction("Details", "Beers", new { id = updatedBeer.Id });
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
				_ = this.beersService.Delete(id, user);

				return this.RedirectToAction("Index", "Beers");
			}
			catch (EntityNotFoundException ex)
			{
				this.Response.StatusCode = StatusCodes.Status404NotFound;
				this.ViewData["ErrorMessage"] = ex.Message;

				return this.View("Error");
			}
		}

        private void InitializeDropDownLists(BeerViewModel viewModel)
        {
            viewModel.Styles = new SelectList(stylesService.GetAll(), "Id", "Name");
        }

    }
}
