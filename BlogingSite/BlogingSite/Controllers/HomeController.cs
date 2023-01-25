using Microsoft.AspNetCore.Mvc;

namespace BlogingSite.Controllers
{
    public class HomeController : Controller
    {


        public IActionResult Index()
        {
            return View();
        }
    }
}
