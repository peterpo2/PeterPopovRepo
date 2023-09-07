using Microsoft.AspNetCore.Mvc;
using WebApp6._0.Models;

namespace WebApp6._0.Controllers
{
    [ApiController]
    [Route("api/beers")]
    public class BeersApiController : ControllerBase
    {
        private static List<Beer> beers = new List<Beer>()
        {
            new Beer
            {
                Id = 1,
                Name = "Pirinsko",
                Abv = 4.0
            },
            new Beer
            {
                Id = 2,
                Name = "Shumensko",
                Abv = 4.5
            }
        };

        [HttpGet("")]
        public IActionResult GetBeers()
        {
            return Ok(beers);
        }

        [HttpGet("{id}")]
        public IActionResult GetBeerById(int id)
        {
            var beer = beers.FirstOrDefault(beer => beer.Id == id);

            if (beer == null)
            {
                return NotFound($"Beer with id={id} does not exist");
                //return StatusCode(StatusCodes.Status404NotFound, $"Beer with id={id} does not exist");
            }

            //this.HttpContext.Response.StatusCode = StatusCodes.Status200OK;

            return Ok(beer);
        }

        [HttpPost("")]
        public IActionResult CreateBeer([FromBody] Beer beer)
        {
            try
            {
                beer.Id = beers.Count + 1;
                beers.Add(beer);

            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }

            return StatusCode(StatusCodes.Status201Created, beer);

        }

        [HttpGet("showMessage")]
        public string ShowMessage()
        {
            return "Hello there!";
        }

        [HttpGet("print")]
        public string PrintMessage()
        {
            return "Hello again!";
        }
    }
}
