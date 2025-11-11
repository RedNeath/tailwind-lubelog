namespace CarCareTracker.Models
{
    public class CalendarViewModel
    {
        public YearAndMonthViewModel PreviousYearAndMonth { get; set; }
        public YearAndMonthViewModel YearAndMonth { get; set; }
        public YearAndMonthViewModel NextYearAndMonth { get; set; }
        public List<DayViewModel> CalendarDays { get; set; }
    }
}

