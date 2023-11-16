using Microsoft.AspNetCore.Mvc;

namespace APTEKA_Software.Controllers
{
    public class HomeController:Controller
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
