using Enter.UI.Abstractions.Core.Bases;
using global::System;
using global::System.Collections.Generic;
using global::System.Linq;
using global::System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Enter.UI.Core;


namespace Enter.UI.Components
{
    public partial class EntTabPanel : EntBaseComponent
    {

        protected string RootCss => CssClassBuilder
            .AddClass("ent-tab-panel")
           .AddClass($"active", Parent.IsActive(Id))
           .Build();


        public Guid Key { get; set; } = Guid.NewGuid();
        
        [Parameter]
        public string Id { get; set; }

        [CascadingParameter]
        public EntTab? Parent { get; set; }

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
                if (string.IsNullOrWhiteSpace(Id))
                {
                    Id = Guid.NewGuid().ToString();
                }

                await Parent.AddNewTab(this);
            }
        }
    }
}