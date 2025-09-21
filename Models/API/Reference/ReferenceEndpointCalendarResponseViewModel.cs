namespace CarCareTracker.Models.API.Reference;

public class ReferenceEndpointCalendarResponseViewModel : ReferenceEndpointResponseInterface
{
    public string MimeType { get => "text/calendar"; }
    public string Content { get; set; }
}
