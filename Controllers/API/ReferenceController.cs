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
        
        [Route("/API/Reference/General/WhoAmI")]
        public IActionResult GeneralWhoAmI()
        {
            return View("/Views/API/Reference/Base.cshtml", new BaseReferenceViewModel()
            {
                Name = "Who am I?",
                PartialViewName = "/Views/API/Reference/General/_WhoAmI.cshtml",
                Endpoint = new ReferenceEndpointViewModel()
                {
                    Method = HttpMethod.Get,
                    Route = "/api/whoami",
                    RouteParameters = [],
                    Body = null,
                    Response = new ReferenceEndpointJsonResponseViewModel()
                    {
                        Content = """
                        {
                            "username": "john_doe",
                            "emailAddress": "j.doe@example.org",
                            "isAdmin": "False",
                            "isRoot": "False"
                        }
                        """
                    }
                }
            });
        }
        
        [Route("/API/Reference/General/Version")]
        public IActionResult GeneralVersion()
        {
            return View("/Views/API/Reference/Base.cshtml", new BaseReferenceViewModel()
            {
                Name = "Version",
                PartialViewName = "/Views/API/Reference/General/_Version.cshtml",
                Endpoint = new ReferenceEndpointViewModel()
                {
                    Method = HttpMethod.Get,
                    Route = "/api/version",
                    RouteParameters = [
                        new ReferenceEndpointRouteParameterViewModel()
                        {
                            Name = "CheckForUpdate",
                            Type = "bool",
                            Description = "Checks for update",
                            IsRequired = false,
                            Example = "false"
                        }
                    ],
                    Body = null,
                    Response = new ReferenceEndpointJsonResponseViewModel()
                    {
                        Content = """
                        {
                            "currentVersion": "1.5.0",
                            "latestVersion": "1.5.0"
                        }
                        """
                    }
                }
            });
        }
        
        [Route("/API/Reference/General/MakeBackup")]
        public IActionResult GeneralMakeBackup()
        {
            return View("/Views/API/Reference/Base.cshtml", new BaseReferenceViewModel()
            {
                Name = "Make backup",
                PartialViewName = "/Views/API/Reference/General/_MakeBackup.cshtml",
                Endpoint = new ReferenceEndpointViewModel()
                {
                    Method = HttpMethod.Get,
                    Route = "/api/makebackup",
                    RouteParameters = [],
                    Body = null,
                    Response = new ReferenceEndpointJsonResponseViewModel()
                    {
                        Content = """
                        "/temp/db_backup_2025-09-21-11-15-58.zip"
                        """
                    }
                }
            });
        }
        
        [Route("/API/Reference/Calendar/ICSCalendar")]
        public IActionResult CalendarICSCalendar()
        {
            return View("/Views/API/Reference/Base.cshtml", new BaseReferenceViewModel()
            {
                Name = "ICS Calendar",
                PartialViewName = "/Views/API/Reference/Calendar/_ICSCalendar.cshtml",
                Endpoint = new ReferenceEndpointViewModel()
                {
                    Method = HttpMethod.Get,
                    Route = "/api/calendar",
                    RouteParameters = [],
                    Body = null,
                    Response = new ReferenceEndpointCalendarResponseViewModel()
                    {
                        Content = """
                        BEGIN:VCALENDAR
                        VERSION:2.0
                        PRODID:lubelogger.com
                        CALSCALE:GREGORIAN
                        METHOD:PUBLISH
                        BEGIN:VEVENT
                        DTSTAMP:20250921T112800
                        UID:36f7c703-d346-335f-6290-cfe5248293e8
                        DTSTART:20191208T000000
                        DTEND:20191208T235900
                        SUMMARY:2010 Renault Wind #BA-586-VR - Renault servicing
                        DESCRIPTION:2010 Renault Wind #BA-586-VR - Renault servicing
                        PRIORITY:1
                        END:VEVENT
                        BEGIN:VEVENT
                        DTSTAMP:20250921T112800
                        UID:13cb738f-780b-8371-1553-7cee43639a77
                        DTSTART:20190414T000000
                        DTEND:20190414T235900
                        SUMMARY:2010 Renault Wind #BA-586-VR - Air filter
                        DESCRIPTION:2010 Renault Wind #BA-586-VR - Air filter
                        PRIORITY:1
                        END:VEVENT
                        BEGIN:VEVENT
                        DTSTAMP:20250921T112800
                        UID:91c8553a-0290-7786-0fdc-18f1128cd191
                        DTSTART:20250820T000000
                        DTEND:20250820T235900
                        SUMMARY:2010 Renault Wind #BA-586-VR - Brake fluid
                        DESCRIPTION:2010 Renault Wind #BA-586-VR - Brake fluid
                        PRIORITY:1
                        END:VEVENT
                        BEGIN:VEVENT
                        DTSTAMP:20250921T112800
                        UID:a8144320-ed2d-f5e2-2d95-21653a4a7f8a
                        DTSTART:20231208T000000
                        DTEND:20231208T235900
                        SUMMARY:2010 Renault Wind #BA-586-VR - Accessory belt
                        DESCRIPTION:2010 Renault Wind #BA-586-VR - Accessory belt
                        PRIORITY:1
                        END:VEVENT
                        BEGIN:VEVENT
                        DTSTAMP:20250921T112800
                        UID:1e7b82fa-5d5f-e3a4-c6a1-f96c300caae6
                        DTSTART:20250820T000000
                        DTEND:20250820T235900
                        SUMMARY:2010 Renault Wind #BA-586-VR - Engine coolant
                        DESCRIPTION:2010 Renault Wind #BA-586-VR - Engine coolant
                        PRIORITY:1
                        END:VEVENT
                        BEGIN:VEVENT
                        DTSTAMP:20250921T112800
                        UID:e6a07b59-a366-a116-85d6-ce525dfd2613
                        DTSTART:20251016T000000
                        DTEND:20251016T235900
                        SUMMARY:2010 Renault Wind #BA-586-VR - Cabin filter
                        DESCRIPTION:2010 Renault Wind #BA-586-VR - Cabin filter
                        PRIORITY:2
                        END:VEVENT
                        BEGIN:VEVENT
                        DTSTAMP:20250921T112800
                        UID:20970377-ccc2-9336-4cce-a15c9cc2434c
                        DTSTART:20251016T000000
                        DTEND:20251016T235900
                        SUMMARY:2010 Renault Wind #BA-586-VR - Oil filter
                        DESCRIPTION:2010 Renault Wind #BA-586-VR - Oil filter
                        PRIORITY:2
                        END:VEVENT
                        BEGIN:VEVENT
                        DTSTAMP:20250921T112800
                        UID:fef219c9-1a61-6514-4e82-e9a49a2d8ad2
                        DTSTART:20251016T000000
                        DTEND:20251016T235900
                        SUMMARY:2010 Renault Wind #BA-586-VR - Oil change
                        DESCRIPTION:2010 Renault Wind #BA-586-VR - Oil change
                        PRIORITY:2
                        END:VEVENT
                        BEGIN:VEVENT
                        DTSTAMP:20250921T112800
                        UID:a31936b1-bd96-1ce0-8e47-c1392c34a714
                        DTSTART:20270829T000000
                        DTEND:20270829T235900
                        SUMMARY:2010 Renault Wind #BA-586-VR - Sparking plugs
                        DESCRIPTION:2010 Renault Wind #BA-586-VR - Sparking plugs
                        PRIORITY:3
                        END:VEVENT
                        BEGIN:VEVENT
                        DTSTAMP:20250921T112800
                        UID:52fe488e-8891-b121-edd1-fd5a33fbc929
                        DTSTART:20300429T000000
                        DTEND:20300429T235900
                        SUMMARY:2010 Renault Wind #BA-586-VR - Cam belt
                        DESCRIPTION:2010 Renault Wind #BA-586-VR - Cam belt
                        PRIORITY:3
                        END:VEVENT
                        END:VCALENDAR
                        """
                    }
                }
            });
        }
        
        [Route("/API/Reference/Documents/Upload")]
        public IActionResult DocumentsUpload()
        {
            return View("/Views/API/Reference/Base.cshtml", new BaseReferenceViewModel()
            {
                Name = "Upload documents",
                PartialViewName = "/Views/API/Reference/Documents/_Upload.cshtml",
                Endpoint = new ReferenceEndpointViewModel()
                {
                    Method = HttpMethod.Post,
                    Route = "/api/documents/upload",
                    RouteParameters = [],
                    Body = new ReferenceEndpointFormDataBodyViewModel()
                    {
                        Content = [
                            new ReferenceEndpointFormDataPropertyViewModel()
                            {
                                Name = "documents",
                                Description = "Files to upload",
                                Example = "new File([\"%PDF-1.4\\n%\\\\F6\\\\E4\\\\FC\\\\DF\\\\n1 0 obj\\n<< ... \"], \"servicing_bill.pdf\", { type: \"application/pdf\" })",
                                IsRequired = true,
                                Type = "File[]",
                                DisplayExample = false
                            }
                        ]
                    },
                    Response = new ReferenceEndpointJsonResponseViewModel()
                    {
                        Content = """
                        [
                            {
                                name: "servicing_bill.pdf",
                                location: "/documents/bc28e7d5-a533-4108-b184-3cdc77f23c12.pdf",
                                isPending: false
                            }
                        ]
                        """
                    }
                }
            });
        }
        
        
        [Route("/API/Reference/Vehicles")]
        public IActionResult Vehicles()
        {
            return View("/Views/API/Reference/Base.cshtml", new BaseReferenceViewModel()
            {
                Name = "Vehicles",
                PartialViewName = "/Views/API/Reference/Vehicles/_Index.cshtml"
            });
        }
        
        [Route("/API/Reference/Vehicles/Gas")]
        public IActionResult VehiclesGas()
        {
            return View("/Views/API/Reference/Base.cshtml", new BaseReferenceViewModel()
            {
                Name = "Gas",
                PartialViewName = "/Views/API/Reference/Vehicles/Gas/_Index.cshtml"
            });
        }
    }
}
