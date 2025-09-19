using CarCareTracker.Models.Reference;
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
            return View("/Views/API/Reference/Base.cshtml", new BaseReferenceViewModel()
            {
                Name = "General",
                PartialViewName = "/Views/API/Reference/General/_Index.cshtml"
            });
        }
        
        [Route("/API/Reference/General/CleanUp")]
        public IActionResult GeneralCleanUp()
        {
            return View("/Views/API/Reference/Base.cshtml", new BaseReferenceViewModel()
            {
                Name = "Clean up",
                PartialViewName = "/Views/API/Reference/General/_CleanUp.cshtml"
            });
        }
    }
}