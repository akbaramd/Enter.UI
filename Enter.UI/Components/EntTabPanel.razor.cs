using global::System;
using global::System.Collections.Generic;
using global::System.Linq;
using global::System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web;
using Enter.UI.Components.Controllers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Enter.UI.Bases;
using Enter.UI.Core;

namespace Enter.UI.Components
{
    public partial class EntTabPanel : EntBaseComponent
    {

        protected string cssClass => new CssClassBuilder("ent-tab-panel")
           .AddClass($"active", Parent.IsActivePanel(TabId))
           .AddClass(Class)
           .Build();

        [Parameter]
        public Guid TabId { get; set; }

        [CascadingParameter]
        public EntTab Parent { get; set; }

       
       

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public string Icon { get; set; }

        protected override async Task OnInitializedAsync()
        {

            await base.OnInitializedAsync();
            if (Parent != null)
            {
                if (TabId == Guid.Empty)
                {
                    TabId = Guid.NewGuid();
                }

                await Parent.AddNewTab(this);
            }
        }
    }
}