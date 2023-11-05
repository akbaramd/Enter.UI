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
    public partial class EntTabPanel : EntComponentBase
    {

        protected string RootCss => CssClassBuilder
            .AddClass("ent-tab-panel")
           .AddClass($"active", Parent.IsActiveTab(Id))
           .Build();


        
        [Parameter]
        public string Id { get; set; }

        public override void Dispose()
        {
            
        }

        [CascadingParameter]
        public EntTab? Parent { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public object Icon { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            if (Parent != null)
            {
                if (string.IsNullOrWhiteSpace(Id))
                {
                    Id = Guid.NewGuid().ToString();
                }
                await Parent.AddTabAsync(this);
            }
        }
    }
}