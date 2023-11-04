using Enter.UI.Core;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enter.UI.Abstractions.Core.Bases;


namespace Enter.UI.Components
{
    public partial class EntToolbar : EntComponentBase
    {
        protected string RootCss => CssClassBuilder.AddClass("ent-toolbar")
            .Build();

        [Parameter]
        public RenderFragment ChildContent { get; set; }

    }
}
