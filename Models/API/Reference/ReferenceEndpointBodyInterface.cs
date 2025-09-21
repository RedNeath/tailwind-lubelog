namespace CarCareTracker.Models.API.Reference;

public interface ReferenceEndpointBodyInterface
{
    public string MimeType { get; } // JSON, FORM-DATA ...

    public string GenerateSampleJavaScriptBody();
}
