namespace CarCareTracker.Models
{
    public class DayViewModel
    {
        public DateTime Date { get; set; }
        public List<DetailedReminderRecordViewModel> Reminders { get; set; }
        public bool IsSelected { get; set; }
    }
}
