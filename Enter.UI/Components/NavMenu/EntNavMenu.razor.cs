using Enter.UI.Core;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enter.UI.Core.Bases;

namespace Enter.UI.Components
{
    public partial class EntNavMenu : EntBaseComponent
    {
        protected string RootCss => CssClassBuilder.AddClass("ent-nav-menu")
            .Build();

        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
