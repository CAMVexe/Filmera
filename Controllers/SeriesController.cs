using Microsoft.AspNetCore.Mvc;

namespace Filmera.Controllers
{
    public class SeriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
