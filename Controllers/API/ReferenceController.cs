using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarCareTracker.Controllers.API
{
    [Authorize]
    public class ReferenceController : Controller
    {
        [Route("/API/Reference/General")]
        public IActionResult General()
        {
            return View("/Views/API/Reference/General/Index.cshtml");
        }
    }
}