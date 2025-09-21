namespace CarCareTracker.Models.API.Reference;

public class ReferenceEndpointFormDataBodyViewModel : ReferenceEndpointBodyInterface
{
    public string MimeType { get => "application/x-www-form-urlencoded"; }

    public List<ReferenceEndpointFormDataPropertyViewModel> Content { get; set; }
    
    public string GenerateSampleJavaScriptBody()
    {
        return ""; //TODO
    }
}
