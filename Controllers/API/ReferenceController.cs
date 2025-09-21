using CarCareTracker.Models.API.Reference;
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
                PartialViewName = "/Views/API/Reference/General/_CleanUp.cshtml",
                Endpoint = new ReferenceEndpointViewModel()
                {
                    Method = HttpMethod.Get,
                    Route = "/api/cleanup",
                    RouteParameters = [
                        new ReferenceEndpointRouteParameterViewModel()
                        {
                            Name = "deepClean",
                            Type = "bool",
                            Description = "Perform deep clean",
                            IsRequired = false,
                            Example = "false"
                        }
                    ],
                    Body = null,
                    Response = new ReferenceEndpointJsonResponseViewModel()
                    {
                        Content = """
                        {
                            "temp_files_deleted": "0",
                            "unlinked_thumbnails_deleted": "0", // nullable (absent)
                            "unlinked_documents_deleted": "0"   // nullable (absent)
                        }
                        """
                    }
                }
            });
        }
    }
}
