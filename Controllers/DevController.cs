using Microsoft.AspNetCore.Mvc;

namespace CarCareTracker.Controllers
{
    public class DevController : Controller
    {
        public IActionResult Index()
        {
            return View("Dev");
        }
    }
}