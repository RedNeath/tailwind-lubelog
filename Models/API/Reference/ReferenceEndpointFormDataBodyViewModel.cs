namespace CarCareTracker.Models.API.Reference;

public class ReferenceEndpointFormDataBodyViewModel : ReferenceEndpointBodyInterface
{
    public string MimeType { get => "application/x-www-form-urlencoded"; }

    public List<ReferenceEndpointFormDataPropertyViewModel> Content { get; set; }
    
    public string GenerateSampleJavaScriptBody()
    {
        string sampleJavaScriptBody = "let body = new FormData();";
        foreach (var item in Content)
        {
            string value = item.Type == "string" ? $"\"{item.Example}\"" : item.Example;
            sampleJavaScriptBody += $"\nbody.append(\"{item.Name}\", {value});";
        }

        sampleJavaScriptBody += "\n";
        return sampleJavaScriptBody;
    }
}
