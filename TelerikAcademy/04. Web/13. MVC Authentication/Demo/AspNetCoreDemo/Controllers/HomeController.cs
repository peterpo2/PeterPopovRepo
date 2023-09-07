using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreDemo.Controllers.Web
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult About()
        {
            return this.View();
        }
    }
}
