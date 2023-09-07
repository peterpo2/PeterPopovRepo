using Microsoft.AspNetCore.Mvc;

namespace Gaming_Forum.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
