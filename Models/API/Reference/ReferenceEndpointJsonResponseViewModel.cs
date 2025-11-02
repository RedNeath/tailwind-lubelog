namespace CarCareTracker.Models.API.Reference;

public class ReferenceEndpointJsonResponseViewModel : ReferenceEndpointResponseInterface
{
    public string MimeType { get => "application/json"; }
    public string Content { get; set; }
}
