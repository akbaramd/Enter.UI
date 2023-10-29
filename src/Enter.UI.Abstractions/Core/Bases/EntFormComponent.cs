using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace Enter.UI.Abstractions.Core.Bases;

public class EntFormComponent : EditForm
{
      
    [Parameter(CaptureUnmatchedValues =true)]
    public Dictionary<string, object?> Attributes { get; set; } = new Dictionary<string, object?>();

    protected CssClassBuilder CssClassBuilder =>
        new CssClassBuilder().AddClass(Attributes.TryGetValue("class", out var @class) ? @class.ToString() : string.Empty);
    
    public string Id => (Attributes?.ContainsKey("id") == true ? Attributes["id"]?.ToString() ?? $"ent-form-{Guid.NewGuid()}" : $"ent-form-{Guid.NewGuid()}");
    
}