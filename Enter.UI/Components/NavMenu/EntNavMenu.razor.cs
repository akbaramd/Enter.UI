using Enter.UI.Bases;
using Enter.UI.Core;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enter.UI.Components.NavMenu
{
    public partial class EntNavMenu : EntBaseComponent
    {
        protected string cssClass => new CssClassBuilder("ent-nav-menu")
            .AddClass(Class)
            .Build();

        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
