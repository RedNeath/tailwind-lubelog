namespace CarCareTracker.Models.API.Reference;

public class BaseReferenceViewModel
{
    public string Name { get; set; }
    public string PartialViewName { get; set; }

    public ReferenceEndpointViewModel? Endpoint { get; set; } // Not present in categories (=> null)
}
