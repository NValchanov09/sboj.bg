using Microsoft.AspNetCore.Mvc;

namespace sbojWebApp.Controllers
{
    public class CompanyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
