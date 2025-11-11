using CarCareTracker.Helper;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace CarCareTracker.TagHelper;

[HtmlTargetElement("markdown")]
public class MarkdownTagHelper : Microsoft.AspNetCore.Razor.TagHelpers.TagHelper
{
    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "svg";
        output.TagMode = TagMode.StartTagAndEndTag;
        output.Attributes.Add("xmlns", "http://www.w3.org/2000/svg");
        output.Attributes.Add("fill", "currentColor");
        output.Attributes.Add("viewBox", "0 0 16 16");
        output.Content.AppendHtml(await File.ReadAllTextAsync($@"wwwroot/{StaticHelper.MarkdownLogoPath}.txt"));
    }
}
