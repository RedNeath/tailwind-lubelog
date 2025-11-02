namespace CarCareTracker.Models.API.Reference;

public class ReferenceEndpointFormDataResponseViewModel : ReferenceEndpointResponseInterface
{
    public string MimeType { get => "application/x-www-form-urlencoded"; }
    public List<ReferenceEndpointFormDataPropertyViewModel> Content { get; set; }
}
