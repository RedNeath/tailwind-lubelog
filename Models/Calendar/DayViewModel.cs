namespace CarCareTracker.Models
{
    public class DayViewModel
    {
        public DateTime Date { get; set; }
        public List<ReminderRecordViewModel> Reminders { get; set; }
        public bool IsSelected { get; set; }
    }
}
