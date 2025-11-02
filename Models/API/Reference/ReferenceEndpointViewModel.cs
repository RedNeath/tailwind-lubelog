namespace CarCareTracker.Models.API.Reference;

public class ReferenceEndpointViewModel
{
    public HttpMethod Method { get; set; }
    public string Route { get; set; }

    public List<ReferenceEndpointRouteParameterViewModel> RouteParameters { get; set; }
    public ReferenceEndpointBodyInterface? Body { get; set; }
    public ReferenceEndpointResponseInterface? Response { get; set; }

    public string GenerateSampleJavaScriptRequest(string baseUrl)
    {
        string request = "";

        if (Body != null)
        {
            request += Body.GenerateSampleJavaScriptBody() + "\n";
        }

        request += "let response = await fetch(\"" + baseUrl + Route;

        if (RouteParameters.Count > 0)
        {
            request += "?" + RouteParameters[0].Name + "=" + RouteParameters[0].Example;
            
            for (int i = 1; i < RouteParameters.Count; i++)
            {
                request += "&" + RouteParameters[i].Name + "=" + RouteParameters[i].Example;
            }
        }

        if (Body != null)
        {
            request += $"\", {{ body, method: \"{Method}\" }});";
        }
        else
        {
            request += $"\", {{ method: \"{Method}\" }});";
        }
            
        return request;
    }
}
