using Microsoft.AspNetCore.Mvc;

namespace sbojWebApp.Controllers
{
    public class CityController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
