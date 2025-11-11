using System.Security.Claims;
using CarCareTracker.External.Interfaces;
using CarCareTracker.Helper;
using CarCareTracker.Logic;
using CarCareTracker.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarCareTracker.Controllers
{
    [Authorize]
    public class CalendarController : Controller
    {
        private readonly ILogger<CalendarController> _logger;
        private readonly IVehicleDataAccess _dataAccess;
        private readonly IUserLogic _userLogic;
        private readonly IVehicleLogic _vehicleLogic;
        private readonly IReminderHelper _reminderHelper;
        private readonly ITranslationHelper _translationHelper;
        
        public CalendarController(
            ILogger<CalendarController> logger,
            IVehicleDataAccess dataAccess,
            IUserLogic userLogic,
            IVehicleLogic vehicleLogic,
            IReminderHelper reminderHelper,
            ITranslationHelper translationHelper)
        {
            _logger = logger;
            _dataAccess = dataAccess;
            _userLogic = userLogic;
            _vehicleLogic = vehicleLogic;
            _reminderHelper = reminderHelper;
            _translationHelper = translationHelper;
        }
        
        private int GetUserID()
        {
            return int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        }
        
        public IActionResult Index()
        {
            var calendarDates = GetCalendarDates(DateTime.Now.Year, DateTime.Now.Month);
            var calendar = GenerateModelFromDates(calendarDates, DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.ToString("yyyy-MM-dd"));

            return View(calendar);
        }
        
        public IActionResult GetCalendarPartialView(int year, int month, string selectedDate)
        {
            var calendarDates = GetCalendarDates(year, month);
            return PartialView("_Calendar", GenerateModelFromDates(calendarDates, year, month, selectedDate));
        }

        public IActionResult GetReminderRecordsPartialView(string selectedDate)
        {
            var vehiclesStored = _dataAccess.GetVehicles();
            if (!User.IsInRole(nameof(UserData.IsRootUser)))
            {
                vehiclesStored = _userLogic.FilterUserVehicles(vehiclesStored, GetUserID());
            }
            var reminders = _vehicleLogic.GetReminders(vehiclesStored, true);
            
            return PartialView("_ReminderRecords", new DayViewModel
            {
                Date = DateTime.ParseExact(selectedDate, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                Reminders = reminders.Where(rmd => rmd.Date.ToString("yyyy-MM-dd") == selectedDate).ToList(),
                IsSelected = true,
            });
        }

        
        protected List<DateTime> GetCalendarDates(int year, int month)
        {
            var firstDayOfMonth = new DateTime(year, month, 1);
            int offset = (int)firstDayOfMonth.DayOfWeek == 0 ? -6 : 1 - (int)firstDayOfMonth.DayOfWeek;
            var firstDayOfCalendar = firstDayOfMonth.AddDays(offset);
            
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            int daysToAddToReachSunday = (7 - (int)lastDayOfMonth.DayOfWeek) % 7;
            var lastDayOfCalendar = lastDayOfMonth.AddDays(daysToAddToReachSunday);

            return Enumerable.Range(0, (int)(lastDayOfCalendar - firstDayOfCalendar).TotalDays + 1)
                .Select(offset => firstDayOfCalendar.AddDays(offset))
                .ToList();
        }

        private CalendarViewModel GenerateModelFromDates(List<DateTime> dates, int year, int month, string selectedDate)
        {
            var currentDate = new DateTime(year, month, 1);
            var vehiclesStored = _dataAccess.GetVehicles();
            if (!User.IsInRole(nameof(UserData.IsRootUser)))
            {
                vehiclesStored = _userLogic.FilterUserVehicles(vehiclesStored, GetUserID());
            }
            var reminders = _vehicleLogic.GetReminders(vehiclesStored, true);
            
            return new CalendarViewModel
            {
                PreviousYearAndMonth = new YearAndMonthViewModel
                {
                    Year = currentDate.AddMonths(-1).Year,
                    Month = currentDate.AddMonths(-1).Month
                },
                YearAndMonth = new YearAndMonthViewModel
                {
                    Year = currentDate.Year,
                    Month = currentDate.Month,
                },
                NextYearAndMonth = new YearAndMonthViewModel
                {
                    Year = currentDate.AddMonths(1).Year,
                    Month = currentDate.AddMonths(1).Month
                },

                CalendarDays = dates.ConvertAll(dte => new DayViewModel
                {
                    Date = dte,
                    Reminders = reminders.Where(rmd => rmd.Date.DayOfYear == dte.DayOfYear && rmd.Date.Year == dte.Year).ToList(),
                    IsSelected = dte.Date.ToString("yyyy-MM-dd") == selectedDate,
                })
            };
        }
    }
}
