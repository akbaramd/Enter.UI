using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enter.UI.Core.Bases
{
    public abstract class EntBaseInput<T> : InputBase<T>
    {

        protected CssClassBuilder CssClassBuilder =>
           new CssClassBuilder().AddClass(AdditionalAttributes?.TryGetValue("class", out var @class) ?? false ? @class?.ToString() ?? string.Empty : string.Empty);


        public string Id => (AdditionalAttributes?.ContainsKey("id") == true ? AdditionalAttributes["id"]?.ToString() ?? $"ent-{Guid.NewGuid()}" : $"ent-{Guid.NewGuid()}");
    }
}
