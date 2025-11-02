namespace CarCareTracker.Models.API.Reference;

public class ReferenceEndpointRouteParameterViewModel
{
    public string Name { get; set; }
    public string Type { get; set; }

    public string Description { get; set; }
    public bool IsRequired { get; set; }
    public string Example { get; set; }
}
