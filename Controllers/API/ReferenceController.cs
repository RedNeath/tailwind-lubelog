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
        
        [Route("/API/Reference/Vehicles/Gas/AddRecord")]
        public IActionResult VehiclesGasAddRecord()
        {
            return View("/Views/API/Reference/Base.cshtml", new BaseReferenceViewModel()
            {
                Name = "Add gas record",
                PartialViewName = "/Views/API/Reference/Vehicles/Gas/_AddRecord.cshtml",
                Endpoint = new ReferenceEndpointViewModel()
                {
                    Method = HttpMethod.Post,
                    Route = "/api/vehicle/gasrecords/add",
                    RouteParameters = [
                        new ReferenceEndpointRouteParameterViewModel()
                        {
                            Name = "vehicleId",
                            Type = "int",
                            Description = "Id of vehicle",
                            IsRequired = true,
                            Example = "1"
                        }
                    ],
                    Body = new ReferenceEndpointFormDataBodyViewModel()
                    {
                        Content = [
                            new ReferenceEndpointFormDataPropertyViewModel()
                            {
                                Name = "date",
                                Description = "Date to be entered",
                                Example = "\"2025-09-27\"",
                                IsRequired = true,
                                Type = "string",
                                DisplayExample = true
                            },
                            new ReferenceEndpointFormDataPropertyViewModel()
                            {
                                Name = "odometer",
                                Description = "Odometer reading",
                                Example = "132447",
                                IsRequired = true,
                                Type = "int",
                                DisplayExample = true
                            },
                            new ReferenceEndpointFormDataPropertyViewModel()
                            {
                                Name = "fuelConsumed",
                                Description = "Fuel consumed ⚠️: Locale sensitive",
                                Example = "36.48",
                                IsRequired = true,
                                Type = "float",
                                DisplayExample = true
                            },
                            new ReferenceEndpointFormDataPropertyViewModel()
                            {
                                Name = "cost",
                                Description = "Cost ⚠️: Locale sensitive",
                                Example = "58.67",
                                IsRequired = true,
                                Type = "float",
                                DisplayExample = true
                            },
                            new ReferenceEndpointFormDataPropertyViewModel()
                            {
                                Name = "isFillToFull",
                                Description = "Filled to full",
                                Example = "true",
                                IsRequired = true,
                                Type = "bool",
                                DisplayExample = true
                            },
                            new ReferenceEndpointFormDataPropertyViewModel()
                            {
                                Name = "missedFuelUp",
                                Description = "Missed fuel up",
                                Example = "false",
                                IsRequired = true,
                                Type = "bool",
                                DisplayExample = true
                            },
                            new ReferenceEndpointFormDataPropertyViewModel()
                            {
                                Name = "notes",
                                Description = "Notes",
                                Example = "\"Refilled the tank at the E.Leclerc Paridis fuel station\"",
                                IsRequired = false,
                                Type = "string",
                                DisplayExample = true
                            },
                            new ReferenceEndpointFormDataPropertyViewModel()
                            {
                                Name = "tags",
                                Description = "Tags separated by spaces",
                                Example = "\"sp95-e10 e.leclerc paridis\"",
                                IsRequired = false,
                                Type = "string",
                                DisplayExample = true
                            },
                            new ReferenceEndpointFormDataPropertyViewModel()
                            {
                                Name = "extrafields",
                                Description = "See format for extra fields",
                                Example = "",
                                IsRequired = false,
                                Type = "string",
                                DisplayExample = false
                            },
                            new ReferenceEndpointFormDataPropertyViewModel()
                            {
                                Name = "files",
                                Description = "Json response from the Upload document route",
                                Example = """
                                "[
                                    {
                                        name: \"fuel_refill_bill.pdf\",
                                        location: \"/documents/bc28e7d5-a533-4108-b184-3cdc77f23c12.pdf\",
                                        isPending: false
                                    }
                                ]"
                                """,
                                IsRequired = false,
                                Type = "string",
                                DisplayExample = true
                            },
                        ]
                    },
                    Response = new ReferenceEndpointJsonResponseViewModel()
                    {
                        Content = """
                        {
                            "success": true,
                            "message": "Gas Record Added"
                        }
                        """
                    }
                }
            });
        }
        
        [Route("/API/Reference/Vehicles/Gas/RecordsList")]
        public IActionResult VehiclesGasRecordsList()
        {
            return View("/Views/API/Reference/Base.cshtml", new BaseReferenceViewModel()
            {
                Name = "Records list",
                PartialViewName = "/Views/API/Reference/Vehicles/Gas/_RecordsList.cshtml",
                Endpoint = new ReferenceEndpointViewModel()
                {
                    Method = HttpMethod.Get,
                    Route = "/api/vehicle/gasrecords",
                    RouteParameters = [
                        new ReferenceEndpointRouteParameterViewModel()
                        {
                            Name = "vehicleId",
                            Type = "int",
                            Description = "Id of vehicle",
                            IsRequired = true,
                            Example = "1"
                        },
                        new ReferenceEndpointRouteParameterViewModel()
                        {
                            Name = "useMPG",
                            Type = "bool",
                            Description = "Use imperial units and calculation",
                            IsRequired = true,
                            Example = "false"
                        },
                        new ReferenceEndpointRouteParameterViewModel()
                        {
                            Name = "useUKMPG",
                            Type = "bool",
                            Description = "Use UK imperial calculation",
                            IsRequired = true,
                            Example = "false"
                        }
                    ],
                    Body = null,
                    Response = new ReferenceEndpointJsonResponseViewModel()
                    {
                        Content = """
                        [
                            {
                                "id": "1",
                                "date": "2025-09-27",
                                "odometer": "128992",
                                "fuelConsumed": "36.48",
                                "cost": "58.67",
                                "fuelEconomy": "3.6774193548387096774193548387",
                                "isFillToFull": "True",
                                "missedFuelUp": "False",
                                "notes": "Refilled the tank at the E.Leclerc Paridis fuel station",
                                "tags": "sp95-e10 e.leclerc paridis",
                                "extraFields": [],
                                "files": []
                            }
                        ]
                        """
                    }
                }
            });
        }
        
        [Route("/API/Reference/Vehicles/Gas/DeleteRecord")]
        public IActionResult VehiclesGasDeleteRecord()
        {
            return View("/Views/API/Reference/Base.cshtml", new BaseReferenceViewModel()
            {
                Name = "Delete record",
                PartialViewName = "/Views/API/Reference/Vehicles/Gas/_DeleteRecord.cshtml",
                Endpoint = new ReferenceEndpointViewModel()
                {
                    Method = HttpMethod.Delete,
                    Route = "/api/vehicle/gasrecords/delete",
                    RouteParameters = [
                        new ReferenceEndpointRouteParameterViewModel()
                        {
                            Name = "Id",
                            Type = "int",
                            Description = "Id of gas record",
                            IsRequired = true,
                            Example = "1"
                        }
                    ],
                    Body = null,
                    Response = new ReferenceEndpointJsonResponseViewModel()
                    {
                        Content = """
                        {
                            "success": true,
                            "message": "Gas Record Deleted"
                        }
                        """
                    }
                }
            });
        }
        
        [Route("/API/Reference/Vehicles/Gas/UpdateRecord")]
        public IActionResult VehiclesGasUpdateRecord()
        {
            return View("/Views/API/Reference/Base.cshtml", new BaseReferenceViewModel()
            {
                Name = "Update gas record",
                PartialViewName = "/Views/API/Reference/Vehicles/Gas/_UpdateRecord.cshtml",
                Endpoint = new ReferenceEndpointViewModel()
                {
                    Method = HttpMethod.Put,
                    Route = "/api/vehicle/gasrecords/update",
                    RouteParameters = [],
                    Body = new ReferenceEndpointFormDataBodyViewModel()
                    {
                        Content = [
                            new ReferenceEndpointFormDataPropertyViewModel()
                            {
                                Name = "Id",
                                Description = "Id of gas record",
                                Example = "1",
                                IsRequired = true,
                                Type = "int",
                                DisplayExample = true
                            },
                            new ReferenceEndpointFormDataPropertyViewModel()
                            {
                                Name = "date",
                                Description = "Date to be entered",
                                Example = "\"2025-09-27\"",
                                IsRequired = true,
                                Type = "string",
                                DisplayExample = true
                            },
                            new ReferenceEndpointFormDataPropertyViewModel()
                            {
                                Name = "odometer",
                                Description = "Odometer reading",
                                Example = "132447",
                                IsRequired = true,
                                Type = "int",
                                DisplayExample = true
                            },
                            new ReferenceEndpointFormDataPropertyViewModel()
                            {
                                Name = "fuelConsumed",
                                Description = "Fuel consumed ⚠️: Locale sensitive",
                                Example = "36.48",
                                IsRequired = true,
                                Type = "float",
                                DisplayExample = true
                            },
                            new ReferenceEndpointFormDataPropertyViewModel()
                            {
                                Name = "cost",
                                Description = "Cost ⚠️: Locale sensitive",
                                Example = "58.67",
                                IsRequired = true,
                                Type = "float",
                                DisplayExample = true
                            },
                            new ReferenceEndpointFormDataPropertyViewModel()
                            {
                                Name = "isFillToFull",
                                Description = "Filled to full",
                                Example = "true",
                                IsRequired = true,
                                Type = "bool",
                                DisplayExample = true
                            },
                            new ReferenceEndpointFormDataPropertyViewModel()
                            {
                                Name = "missedFuelUp",
                                Description = "Missed fuel up",
                                Example = "false",
                                IsRequired = true,
                                Type = "bool",
                                DisplayExample = true
                            },
                            new ReferenceEndpointFormDataPropertyViewModel()
                            {
                                Name = "notes",
                                Description = "Notes",
                                Example = "\"Refilled the tank at the E.Leclerc Paridis fuel station\"",
                                IsRequired = false,
                                Type = "string",
                                DisplayExample = true
                            },
                            new ReferenceEndpointFormDataPropertyViewModel()
                            {
                                Name = "tags",
                                Description = "Tags separated by spaces",
                                Example = "\"sp95-e10 e.leclerc paridis\"",
                                IsRequired = false,
                                Type = "string",
                                DisplayExample = true
                            },
                            new ReferenceEndpointFormDataPropertyViewModel()
                            {
                                Name = "extrafields",
                                Description = "See format for extra fields",
                                Example = "",
                                IsRequired = false,
                                Type = "string",
                                DisplayExample = false
                            },
                            new ReferenceEndpointFormDataPropertyViewModel()
                            {
                                Name = "files",
                                Description = "Json response from the Upload document route",
                                Example = """
                                "[
                                    {
                                        name: \"fuel_refill_bill.pdf\",
                                        location: \"/documents/bc28e7d5-a533-4108-b184-3cdc77f23c12.pdf\",
                                        isPending: false
                                    }
                                ]"
                                """,
                                IsRequired = false,
                                Type = "string",
                                DisplayExample = true
                            },
                        ]
                    },
                    Response = new ReferenceEndpointJsonResponseViewModel()
                    {
                        Content = """
                        {
                            "success": true,
                            "message": "Gas Record Updated"
                        }
                        """
                    }
                }
            });
        }
        
        [Route("/API/Reference/Vehicles/List")]
        public IActionResult VehiclesList()
        {
            return View("/Views/API/Reference/Base.cshtml", new BaseReferenceViewModel()
            {
                Name = "List vehicles",
                PartialViewName = "/Views/API/Reference/Vehicles/_List.cshtml",
                Endpoint = new ReferenceEndpointViewModel()
                {
                    Method = HttpMethod.Get,
                    Route = "/api/vehicles",
                    RouteParameters = [],
                    Body = null,
                    Response = new ReferenceEndpointJsonResponseViewModel()
                    {
                        Content = """
                        [
                            {
                                "id": 1,
                                "imageLocation": "/images/12f226dc-d93d-44d1-acfd-85d1eee2bba0.jpg",
                                "mapLocation": "",
                                "year": 2010,
                                "make": "Renault",
                                "model": "Wind",
                                "licensePlate": "WI-072-ND",
                                "purchaseDate": "2025-06-08",
                                "soldDate": null,
                                "purchasePrice": 7500,
                                "soldPrice": 0,
                                "isElectric": false,
                                "isDiesel": false,
                                "useHours": false,
                                "odometerOptional": false,
                                "extraFields": [],
                                "tags": [],
                                "hasOdometerAdjustment": false,
                                "odometerMultiplier": "1",
                                "odometerDifference": "0",
                                "dashboardMetrics": [0, 2, 1],
                                "vehicleIdentifier": "LicensePlate"
                            }
                        ]
                        """
                    }
                }
            });
        }
        
        [Route("/API/Reference/Vehicles/Info")]
        public IActionResult VehiclesInfo()
        {
            return View("/Views/API/Reference/Base.cshtml", new BaseReferenceViewModel()
            {
                Name = "Vehicle(s) info",
                PartialViewName = "/Views/API/Reference/Vehicles/_Info.cshtml",
                Endpoint = new ReferenceEndpointViewModel()
                {
                    Method = HttpMethod.Get,
                    Route = "/api/vehicle/info",
                    RouteParameters = [
                        new ReferenceEndpointRouteParameterViewModel()
                        {
                            Name = "VehicleId",
                            Description = "Id of vehicle",
                            IsRequired = false,
                            Type = "int",
                            Example = "1"
                        }
                    ],
                    Body = null,
                    Response = new ReferenceEndpointJsonResponseViewModel()
                    {
                        Content = """
                        [
                            {
                                "vehicleData": {
                                    "id": 1,
                                    "imageLocation": "/images/12f226dc-d93d-44d1-acfd-85d1eee2bba0.jpg",
                                    "mapLocation": "",
                                    "year": 2010,
                                    "make": "Renault",
                                    "model": "Wind",
                                    "licensePlate": "WI-072-ND",
                                    "purchaseDate": "2025-06-08",
                                    "soldDate": null,
                                    "purchasePrice": 7500,
                                    "soldPrice": 0,
                                    "isElectric": false,
                                    "isDiesel": false,
                                    "useHours": false,
                                    "odometerOptional": false,
                                    "extraFields": [],
                                    "tags": [],
                                    "hasOdometerAdjustment": false,
                                    "odometerMultiplier": "1",
                                    "odometerDifference": "0",
                                    "dashboardMetrics": [0, 2, 1],
                                    "vehicleIdentifier": "LicensePlate"
                                },
                                "veryUrgentReminderCount": 0,
                                "urgentReminderCount": 0,
                                "notUrgentReminderCount": 15,
                                "pastDueReminderCount": 1,
                                "nextReminder": {
                                    "id": "14",
                                    "description": "Lavage",
                                    "urgency": "NotUrgent",
                                    "metric": "Date",
                                    "userMetric": "Date",
                                    "notes": null,
                                    "dueDate": "2025-12-16",
                                    "dueOdometer": "0",
                                    "dueDays": "78",
                                    "dueDistance": "0",
                                    "tags": "faisable"
                                },
                                "serviceRecordCount": 9,
                                "serviceRecordCost": 3155.36,
                                "repairRecordCount": 4,
                                "repairRecordCost": 1132.62,
                                "upgradeRecordCount": 0,
                                "upgradeRecordCost": 0,
                                "taxRecordCount": 0,
                                "taxRecordCost": 0,
                                "gasRecordCount": 4,
                                "gasRecordCost": 15065.96,
                                "lastReportedOdometer": 128524,
                                "planRecordBackLogCount": 0,
                                "planRecordInProgressCount": 0,
                                "planRecordTestingCount": 0,
                                "planRecordDoneCount": 0
                            }
                        ]
                        """
                    }
                }
            });
        }
        
        [Route("/API/Reference/Vehicles/Odometer")]
        public IActionResult VehiclesOdometer()
        {
            return View("/Views/API/Reference/Base.cshtml", new BaseReferenceViewModel()
            {
                Name = "Odometer",
                PartialViewName = "/Views/API/Reference/Vehicles/Odometer/_Index.cshtml"
            });
        }
        
        [Route("/API/Reference/Vehicles/Odometer/AddRecord")]
        public IActionResult VehiclesOdometerAddRecord()
        {
            return View("/Views/API/Reference/Base.cshtml", new BaseReferenceViewModel()
            {
                Name = "Add odometer record",
                PartialViewName = "/Views/API/Reference/Vehicles/Odometer/_AddRecord.cshtml",
                Endpoint = new ReferenceEndpointViewModel()
                {
                    Method = HttpMethod.Post,
                    Route = "/api/vehicle/odometerrecords/add",
                    RouteParameters = [
                        new ReferenceEndpointRouteParameterViewModel()
                        {
                            Name = "vehicleId",
                            Type = "int",
                            Description = "Id of vehicle",
                            IsRequired = true,
                            Example = "1"
                        }
                    ],
                    Body = new ReferenceEndpointFormDataBodyViewModel()
                    {
                        Content = [
                            new ReferenceEndpointFormDataPropertyViewModel()
                            {
                                Name = "date",
                                Description = "Date to be entered",
                                Example = "\"2025-09-28\"",
                                IsRequired = true,
                                Type = "string",
                                DisplayExample = true
                            },
                            new ReferenceEndpointFormDataPropertyViewModel()
                            {
                                Name = "initialOdometer",
                                Description = "Initial odometer reading",
                                Example = "128534",
                                IsRequired = false,
                                Type = "int",
                                DisplayExample = true
                            },
                            new ReferenceEndpointFormDataPropertyViewModel()
                            {
                                Name = "odometer",
                                Description = "Odometer reading",
                                Example = "128992",
                                IsRequired = true,
                                Type = "int",
                                DisplayExample = true
                            },
                            new ReferenceEndpointFormDataPropertyViewModel()
                            {
                                Name = "notes",
                                Description = "Notes",
                                Example = "\"Vehicle won't move before some time\"",
                                IsRequired = false,
                                Type = "string",
                                DisplayExample = true
                            },
                            new ReferenceEndpointFormDataPropertyViewModel()
                            {
                                Name = "tags",
                                Description = "Tags separated by spaces",
                                Example = "\"immobilisation\"",
                                IsRequired = false,
                                Type = "string",
                                DisplayExample = true
                            },
                            new ReferenceEndpointFormDataPropertyViewModel()
                            {
                                Name = "extrafields",
                                Description = "See format for extra fields",
                                Example = "",
                                IsRequired = false,
                                Type = "string",
                                DisplayExample = false
                            },
                            new ReferenceEndpointFormDataPropertyViewModel()
                            {
                                Name = "files",
                                Description = "Json response from the Upload document route",
                                Example = """
                                "[
                                    {
                                        name: \"odometer.jpg\",
                                        location: \"/documents/bc28e7d5-a533-4108-b184-3cdc77f23c12.jpg\",
                                        isPending: false
                                    }
                                ]"
                                """,
                                IsRequired = false,
                                Type = "string",
                                DisplayExample = true
                            },
                        ]
                    },
                    Response = new ReferenceEndpointJsonResponseViewModel()
                    {
                        Content = """
                        {
                            "success": true,
                            "message": "Odometer Record Added"
                        }
                        """
                    }
                }
            });
        }
        
        [Route("/API/Reference/Vehicles/Odometer/DeleteRecord")]
        public IActionResult VehiclesOdometerDeleteRecord()
        {
            return View("/Views/API/Reference/Base.cshtml", new BaseReferenceViewModel()
            {
                Name = "Delete odometer record",
                PartialViewName = "/Views/API/Reference/Vehicles/Odometer/_DeleteRecord.cshtml",
                Endpoint = new ReferenceEndpointViewModel()
                {
                    Method = HttpMethod.Delete,
                    Route = "/api/vehicle/odometerrecords/delete",
                    RouteParameters = [
                        new ReferenceEndpointRouteParameterViewModel()
                        {
                            Name = "Id",
                            Type = "int",
                            Description = "Id of odometer record",
                            IsRequired = true,
                            Example = "1"
                        }
                    ],
                    Body = null,
                    Response = new ReferenceEndpointJsonResponseViewModel()
                    {
                        Content = """
                                  {
                                      "success": true,
                                      "message": "Odometer Record Deleted"
                                  }
                                  """
                    }
                }
            });
        }
        
        [Route("/API/Reference/Vehicles/Odometer/AdjustedOdometer")]
        public IActionResult VehiclesOdometerAdjustedOdometer()
        {
            return View("/Views/API/Reference/Base.cshtml", new BaseReferenceViewModel()
            {
                Name = "Adjusted odometer",
                PartialViewName = "/Views/API/Reference/Vehicles/Odometer/_AdjustedOdometer.cshtml",
                Endpoint = new ReferenceEndpointViewModel()
                {
                    Method = HttpMethod.Get,
                    Route = "/api/vehicle/adjustedodometer",
                    RouteParameters = [
                        new ReferenceEndpointRouteParameterViewModel()
                        {
                            Name = "vehicleId",
                            Type = "int",
                            Description = "Id of vehicle",
                            IsRequired = true,
                            Example = "1"
                        },
                        new ReferenceEndpointRouteParameterViewModel()
                        {
                            Name = "odometer",
                            Type = "int",
                            Description = "Unadjusted odometer reading",
                            IsRequired = true,
                            Example = "128000"
                        }
                    ],
                    Body = null,
                    Response = new ReferenceEndpointJsonResponseViewModel()
                    {
                        Content = """
                                  128000
                                  """
                    }
                }
            });
        }
        
        [Route("/API/Reference/Vehicles/Odometer/LatestRecord")]
        public IActionResult VehiclesOdometerLatestRecord()
        {
            return View("/Views/API/Reference/Base.cshtml", new BaseReferenceViewModel()
            {
                Name = "Latest odometer record",
                PartialViewName = "/Views/API/Reference/Vehicles/Odometer/_LatestRecord.cshtml",
                Endpoint = new ReferenceEndpointViewModel()
                {
                    Method = HttpMethod.Get,
                    Route = "/api/vehicle/odometerrecords/latest",
                    RouteParameters = [
                        new ReferenceEndpointRouteParameterViewModel()
                        {
                            Name = "vehicleId",
                            Type = "int",
                            Description = "Id of vehicle",
                            IsRequired = true,
                            Example = "1"
                        },
                    ],
                    Body = null,
                    Response = new ReferenceEndpointJsonResponseViewModel()
                    {
                        Content = """
                                  128000
                                  """
                    }
                }
            });
        }
        
        [Route("/API/Reference/Vehicles/Odometer/RecordsList")]
        public IActionResult VehiclesOdometerRecordsList()
        {
            return View("/Views/API/Reference/Base.cshtml", new BaseReferenceViewModel()
            {
                Name = "Odometer records list",
                PartialViewName = "/Views/API/Reference/Vehicles/Odometer/_RecordsList.cshtml",
                Endpoint = new ReferenceEndpointViewModel()
                {
                    Method = HttpMethod.Get,
                    Route = "/api/vehicle/odometerrecords",
                    RouteParameters = [
                        new ReferenceEndpointRouteParameterViewModel()
                        {
                            Name = "vehicleId",
                            Type = "int",
                            Description = "Id of vehicle",
                            IsRequired = true,
                            Example = "1"
                        },
                    ],
                    Body = null,
                    Response = new ReferenceEndpointJsonResponseViewModel()
                    {
                        Content = """
                                  [
                                      {
                                          "id": "1",
                                          "date": "05/10/2025",
                                          "initialOdometer": "128700",
                                          "odometer": "128700",
                                          "notes": null,
                                          "tags": "",
                                          "extraFields": [],
                                          "files":[]
                                      }
                                  ]
                                  """
                    }
                }
            });
        }
        
        [Route("/API/Reference/Vehicles/Odometer/UpdateRecord")]
        public IActionResult VehiclesOdometerUpdateRecord()
        {
            return View("/Views/API/Reference/Base.cshtml", new BaseReferenceViewModel()
            {
                Name = "Update odometer record",
                PartialViewName = "/Views/API/Reference/Vehicles/Odometer/_UpdateRecord.cshtml",
                Endpoint = new ReferenceEndpointViewModel()
                {
                    Method = HttpMethod.Put,
                    Route = "/api/vehicle/odometerrecords/update",
                    RouteParameters = [],
                    Body = new ReferenceEndpointFormDataBodyViewModel()
                    {
                        Content = [
                            new ReferenceEndpointFormDataPropertyViewModel()
                            {
                                Name = "Id",
                                Description = "Id of odometer record",
                                Example = "1",
                                IsRequired = true,
                                Type = "int",
                                DisplayExample = true
                            },
                            new ReferenceEndpointFormDataPropertyViewModel()
                            {
                                Name = "date",
                                Description = "Date to be entered",
                                Example = "\"2025-09-28\"",
                                IsRequired = true,
                                Type = "string",
                                DisplayExample = true
                            },
                            new ReferenceEndpointFormDataPropertyViewModel()
                            {
                                Name = "initialOdometer",
                                Description = "Initial odometer reading",
                                Example = "128534",
                                IsRequired = true,
                                Type = "int",
                                DisplayExample = true
                            },
                            new ReferenceEndpointFormDataPropertyViewModel()
                            {
                                Name = "odometer",
                                Description = "Odometer reading",
                                Example = "128992",
                                IsRequired = true,
                                Type = "int",
                                DisplayExample = true
                            },
                            new ReferenceEndpointFormDataPropertyViewModel()
                            {
                                Name = "notes",
                                Description = "Notes",
                                Example = "\"Vehicle won't move before some time\"",
                                IsRequired = false,
                                Type = "string",
                                DisplayExample = true
                            },
                            new ReferenceEndpointFormDataPropertyViewModel()
                            {
                                Name = "tags",
                                Description = "Tags separated by spaces",
                                Example = "\"immobilisation\"",
                                IsRequired = false,
                                Type = "string",
                                DisplayExample = true
                            },
                            new ReferenceEndpointFormDataPropertyViewModel()
                            {
                                Name = "extrafields",
                                Description = "See format for extra fields",
                                Example = "",
                                IsRequired = false,
                                Type = "string",
                                DisplayExample = false
                            },
                            new ReferenceEndpointFormDataPropertyViewModel()
                            {
                                Name = "files",
                                Description = "Json response from the Upload document route",
                                Example = """
                                "[
                                    {
                                        name: \"odometer.jpg\",
                                        location: \"/documents/bc28e7d5-a533-4108-b184-3cdc77f23c12.jpg\",
                                        isPending: false
                                    }
                                ]"
                                """,
                                IsRequired = false,
                                Type = "string",
                                DisplayExample = true
                            },
                        ]
                    },
                    Response = new ReferenceEndpointJsonResponseViewModel()
                    {
                        Content = """
                        {
                            "success": true,
                            "message": "Odometer Record Updated"
                        }
                        """
                    }
                }
            });
        }
        
        [Route("/API/Reference/Vehicles/Plans")]
        public IActionResult VehiclesPlans()
        {
            return View("/Views/API/Reference/Base.cshtml", new BaseReferenceViewModel()
            {
                Name = "Plans",
                PartialViewName = "/Views/API/Reference/Vehicles/Plans/_Index.cshtml"
            });
        }
        
        [Route("/API/Reference/Vehicles/Plans/AddRecord")]
        public IActionResult VehiclesPlansAddRecord()
        {
            return View("/Views/API/Reference/Base.cshtml", new BaseReferenceViewModel()
            {
                Name = "Add plan record",
                PartialViewName = "/Views/API/Reference/Vehicles/Plans/_AddRecord.cshtml",
                Endpoint = new ReferenceEndpointViewModel()
                {
                    Method = HttpMethod.Post,
                    Route = "/api/vehicle/planrecords/add",
                    RouteParameters = [
                        new ReferenceEndpointRouteParameterViewModel()
                        {
                            Name = "vehicleId",
                            Type = "int",
                            Description = "Id of vehicle",
                            IsRequired = true,
                            Example = "1"
                        }
                    ],
                    Body = new ReferenceEndpointFormDataBodyViewModel()
                    {
                        Content = [
                            new ReferenceEndpointFormDataPropertyViewModel()
                            {
                                Name = "description",
                                Description = "Description",
                                Example = "\"Install the new exhaust line\"",
                                IsRequired = true,
                                Type = "string",
                                DisplayExample = true
                            },
                            new ReferenceEndpointFormDataPropertyViewModel()
                            {
                                Name = "cost",
                                Description = "Cost ⚠️: Locale sensitive",
                                Example = "822.99",
                                IsRequired = true,
                                Type = "float",
                                DisplayExample = true
                            },
                            new ReferenceEndpointFormDataPropertyViewModel()
                            {
                                Name = "type",
                                Description = "One of: `ServiceRecord`, `RepairRecord` or `UpgradeRecord`.",
                                Example = "\"UpgradeRecord\"",
                                IsRequired = true,
                                Type = "string",
                                DisplayExample = true
                            },
                            new ReferenceEndpointFormDataPropertyViewModel()
                            {
                                Name = "priority",
                                Description = "One of: `Low`, `Normal` or `Critical`.",
                                Example = "\"Normal\"",
                                IsRequired = true,
                                Type = "string",
                                DisplayExample = true
                            },
                            new ReferenceEndpointFormDataPropertyViewModel()
                            {
                                Name = "progress",
                                Description = "One of: `Backlog`, `InProgress` or `Testing`",
                                Example = "\"Backlog\"",
                                IsRequired = true,
                                Type = "string",
                                DisplayExample = true
                            },
                            new ReferenceEndpointFormDataPropertyViewModel()
                            {
                                Name = "notes",
                                Description = "Notes",
                                Example = "\"Remember checking that sound doesn't level exceed the 84 db legal limit.\"",
                                IsRequired = false,
                                Type = "string",
                                DisplayExample = true
                            },
                            new ReferenceEndpointFormDataPropertyViewModel()
                            {
                                Name = "extrafields",
                                Description = "See format for extra fields",
                                Example = "",
                                IsRequired = false,
                                Type = "string",
                                DisplayExample = false
                            },
                            new ReferenceEndpointFormDataPropertyViewModel()
                            {
                                Name = "files",
                                Description = "Json response from the Upload document route",
                                Example = """
                                "[
                                    {
                                        name: \"plan.jpg\",
                                        location: \"/documents/bc28e7d5-a533-4108-b184-3cdc77f23c12.jpg\",
                                        isPending: false
                                    }
                                ]"
                                """,
                                IsRequired = false,
                                Type = "string",
                                DisplayExample = true
                            },
                        ]
                    },
                    Response = new ReferenceEndpointJsonResponseViewModel()
                    {
                        Content = """
                        {
                            "success": true,
                            "message": "Plan Record Added"
                        }
                        """
                    }
                }
            });
        }
        
        [Route("/API/Reference/Vehicles/Plans/DeleteRecord")]
        public IActionResult VehiclesPlansDeleteRecord()
        {
            return View("/Views/API/Reference/Base.cshtml", new BaseReferenceViewModel()
            {
                Name = "Delete plan record",
                PartialViewName = "/Views/API/Reference/Vehicles/Plans/_DeleteRecord.cshtml",
                Endpoint = new ReferenceEndpointViewModel()
                {
                    Method = HttpMethod.Delete,
                    Route = "/api/vehicle/planrecords/delete",
                    RouteParameters = [
                        new ReferenceEndpointRouteParameterViewModel()
                        {
                            Name = "Id",
                            Type = "int",
                            Description = "Id of plan record",
                            IsRequired = true,
                            Example = "1"
                        }
                    ],
                    Body = null,
                    Response = new ReferenceEndpointJsonResponseViewModel()
                    {
                        Content = """
                                  {
                                      "success": true,
                                      "message": "Plan Record Deleted"
                                  }
                                  """
                    }
                }
            });
        }
        
        [Route("/API/Reference/Vehicles/Plans/RecordsList")]
        public IActionResult VehiclesPlansRecordsList()
        {
            return View("/Views/API/Reference/Base.cshtml", new BaseReferenceViewModel()
            {
                Name = "Plan records list",
                PartialViewName = "/Views/API/Reference/Vehicles/Plans/_RecordsList.cshtml",
                Endpoint = new ReferenceEndpointViewModel()
                {
                    Method = HttpMethod.Get,
                    Route = "/api/vehicle/planrecords",
                    RouteParameters = [
                        new ReferenceEndpointRouteParameterViewModel()
                        {
                            Name = "vehicleId",
                            Type = "int",
                            Description = "Id of vehicle",
                            IsRequired = true,
                            Example = "1"
                        },
                    ],
                    Body = null,
                    Response = new ReferenceEndpointJsonResponseViewModel()
                    {
                        Content = """
                                  [
                                      {
                                          "id": "1",
                                          "dateCreated": "2025-10-08",
                                          "dateModified": "2025-10-08",
                                          "description": "Install the new exhaust line",
                                          "notes": "Remember checking that sound doesn't level exceed the 84 db legal limit.",
                                          "type": "UpgradeRecord",
                                          "priority": "Normal",
                                          "progress": "Backlog",
                                          "cost": "822.99",
                                          "extraFields": [],
                                          "files":[]
                                      }
                                  ]
                                  """
                    }
                }
            });
        }
        
        [Route("/API/Reference/Vehicles/Plans/UpdateRecord")]
        public IActionResult VehiclesPlansUpdateRecord()
        {
            return View("/Views/API/Reference/Base.cshtml", new BaseReferenceViewModel()
            {
                Name = "Update plan record",
                PartialViewName = "/Views/API/Reference/Vehicles/Plans/_UpdateRecord.cshtml",
                Endpoint = new ReferenceEndpointViewModel()
                {
                    Method = HttpMethod.Put,
                    Route = "/api/vehicle/planrecords/update",
                    RouteParameters = [],
                    Body = new ReferenceEndpointFormDataBodyViewModel()
                    {
                        Content = [
                            new ReferenceEndpointFormDataPropertyViewModel()
                            {
                                Name = "Id",
                                Description = "Id of plan record",
                                Example = "1",
                                IsRequired = true,
                                Type = "int",
                                DisplayExample = true
                            },
                            new ReferenceEndpointFormDataPropertyViewModel()
                            {
                                Name = "description",
                                Description = "Description",
                                Example = "\"Install the new exhaust line\"",
                                IsRequired = true,
                                Type = "string",
                                DisplayExample = true
                            },
                            new ReferenceEndpointFormDataPropertyViewModel()
                            {
                                Name = "cost",
                                Description = "Cost ⚠️: Locale sensitive",
                                Example = "822.99",
                                IsRequired = true,
                                Type = "float",
                                DisplayExample = true
                            },
                            new ReferenceEndpointFormDataPropertyViewModel()
                            {
                                Name = "type",
                                Description = "One of: `ServiceRecord`, `RepairRecord` or `UpgradeRecord`.",
                                Example = "\"UpgradeRecord\"",
                                IsRequired = true,
                                Type = "string",
                                DisplayExample = true
                            },
                            new ReferenceEndpointFormDataPropertyViewModel()
                            {
                                Name = "priority",
                                Description = "One of: `Low`, `Normal` or `Critical`.",
                                Example = "\"Normal\"",
                                IsRequired = true,
                                Type = "string",
                                DisplayExample = true
                            },
                            new ReferenceEndpointFormDataPropertyViewModel()
                            {
                                Name = "progress",
                                Description = "One of: `Backlog`, `InProgress` or `Testing`",
                                Example = "\"Backlog\"",
                                IsRequired = true,
                                Type = "string",
                                DisplayExample = true
                            },
                            new ReferenceEndpointFormDataPropertyViewModel()
                            {
                                Name = "notes",
                                Description = "Notes",
                                Example = "\"Remember checking that sound doesn't level exceed the 84 db legal limit.\"",
                                IsRequired = false,
                                Type = "string",
                                DisplayExample = true
                            },
                            new ReferenceEndpointFormDataPropertyViewModel()
                            {
                                Name = "extrafields",
                                Description = "See format for extra fields",
                                Example = "",
                                IsRequired = false,
                                Type = "string",
                                DisplayExample = false
                            },
                            new ReferenceEndpointFormDataPropertyViewModel()
                            {
                                Name = "files",
                                Description = "Json response from the Upload document route",
                                Example = """
                                "[
                                    {
                                        name: \"plan.jpg\",
                                        location: \"/documents/bc28e7d5-a533-4108-b184-3cdc77f23c12.jpg\",
                                        isPending: false
                                    }
                                ]"
                                """,
                                IsRequired = false,
                                Type = "string",
                                DisplayExample = true
                            },
                        ]
                    },
                    Response = new ReferenceEndpointJsonResponseViewModel()
                    {
                        Content = """
                        {
                            "success": true,
                            "message": "Plan Record Updated"
                        }
        
        [Route("/API/Reference/Vehicles/Reminders")]
        public IActionResult VehiclesReminders()
        {
            return View("/Views/API/Reference/Base.cshtml", new BaseReferenceViewModel()
            {
                Name = "Reminders",
                PartialViewName = "/Views/API/Reference/Vehicles/Reminders/_Index.cshtml"
            });
        }
                        """
                    }
                }
            });
        }
    }
}
