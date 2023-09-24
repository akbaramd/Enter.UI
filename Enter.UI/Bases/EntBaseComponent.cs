using Enter.UI.Core;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enter.UI.Bases
{
    public class EntBaseComponent : ComponentBase
    {


        [Parameter]
        [Category("Common")]
        public string? Class { get; set; }

        [Parameter]
        [Category("Common")]
        public string? Style { get; set; }


        [Parameter(CaptureUnmatchedValues = true)]
        [Category("Common")]
        public Dictionary<string, object?> UserAttributes { get; set; } = new Dictionary<string, object?>();

        protected bool IsJSRuntimeAvailable { get; set; }

        public string FieldId => (UserAttributes?.ContainsKey("id") == true ? UserAttributes["id"]?.ToString() ?? $"ent-input-{Guid.NewGuid()}" : $"ent-input-{Guid.NewGuid()}");

    }
}
