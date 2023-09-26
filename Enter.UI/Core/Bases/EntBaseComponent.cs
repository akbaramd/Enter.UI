using System.ComponentModel;
using Enter.UI.Core.Extensions;
using Microsoft.AspNetCore.Components;

namespace Enter.UI.Core.Bases
{
    public class EntBaseComponent : ComponentBase
    {
        //todo : Remove Style and Create Style Builder
        protected string Style { get; set; } = default!;
        
        [Parameter(CaptureUnmatchedValues =true)]
        public Dictionary<string, object?> Attributes { get; set; } = new Dictionary<string, object?>();

        protected CssClassBuilder CssClassBuilder =>
            new CssClassBuilder().AddClass(Attributes.TryGetValue("class", out var @class) ? @class.ToString() : "");
        public string Id => (Attributes?.ContainsKey("id") == true ? Attributes["id"]?.ToString() ?? $"ent-{Guid.NewGuid()}" : $"ent-{Guid.NewGuid()}");

    }
}
