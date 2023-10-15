using System.ComponentModel;
using Enter.UI.Core.Extensions;
using Microsoft.AspNetCore.Components;

namespace Enter.UI.Core.Bases
{
    public class EntBaseComponent : ComponentBase
    {
        //todo : Remove Style and Create Style Builder

        private string? _id = null;

        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object?> AdditionalAttributes { get; set; } = new Dictionary<string, object?>();

        protected CssClassBuilder CssClassBuilder =>
            new CssClassBuilder().AddClass(AdditionalAttributes.TryGetValue("class", out var @class) ? @class.ToString() : string.Empty);

        protected StyleBuilder StyleBuilder =>
            new StyleBuilder().AddStyle(AdditionalAttributes.TryGetValue("style", out var @style) ? @style.ToString() : string.Empty);
        public string Id => (AdditionalAttributes?.ContainsKey("id") == true ? AdditionalAttributes["id"]?.ToString() ?? GetId() : GetId());



        private string GetId()
        {
            _id ??= $"ent-{Guid.NewGuid()}";

            return _id;
        }

    }
}
