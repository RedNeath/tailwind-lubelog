namespace CarCareTracker.Models
{
    public class DetailedReminderRecordViewModel : ReminderRecordViewModel
    {
        public Vehicle Vehicle { get; set; }
        public string SoleDescription { get; set; }
    }
}
