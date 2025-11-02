namespace CarCareTracker.Models.API.Reference;

public class ReferenceEndpointFormDataPropertyViewModel
{
    public string Name { get; set; }
    public string Type { get; set; }

    public string Description { get; set; }
    public bool IsRequired { get; set; }
    public string Example { get; set; }
    public bool DisplayExample  { get; set; }
}
