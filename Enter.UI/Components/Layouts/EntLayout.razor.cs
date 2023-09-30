using Enter.UI.Core;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enter.UI.Core.Bases;
using Enter.UI.Services.Contracts;
using Microsoft.JSInterop;

namespace Enter.UI.Components
{
    public partial class EntLayout : EntBaseComponent
    {
        [Inject]
        public IEntJsService JsService { get; set; }
        protected string RootCss => CssClassBuilder.AddClass("ent-layout")
            .Build();

        private int _screenWidth = 0;
        
        protected string SidebarCss => CssClassBuilder
            .Clear()
            .AddClass(SidebarClass)
            .AddClass("ent-layout-sidebar")
            .AddClass("ent-layout-sidebar-mobile",_screenWidth < 1028)
            .Build();

        protected string AppBarCss => CssClassBuilder
            .Clear()
            .AddClass(AppbarClass)
            .AddClass("ent-layout-appbar")
            .Build();

        protected string ContentCss => CssClassBuilder
            .Clear()
            .AddClass(ContentClass)
            .AddClass("ent-layout-content")
            .Build();

        [Parameter] public RenderFragment? AppBar { get; set; }
        [Parameter] public RenderFragment? Content { get; set; }
        [Parameter] public RenderFragment? Sidebar { get; set; }

        [Parameter] public string SidebarClass { get; set; }
        [Parameter] public string ContentClass { get; set; }

        [Parameter] public bool SidebarIsShow { get; set; } = true;

        [Parameter] public string AppbarClass { get; set; }
        [Parameter] public EventCallback<bool> OnSidebarIsShowChanged { get; set; }


        protected override void OnInitialized()
        {
            if (Content == null)
            {
                throw new InvalidOperationException("you must be define <Content></Content> in EntLayout");
            }

            base.OnInitialized();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                var element = await JsService.GetElementByQuerySelectorAsync("body");
                _screenWidth = element.Width;
                if (element.Width < 1028)
                {
                    SidebarIsShow = false;
                    StateHasChanged();

                    await OnSidebarIsShowChanged.InvokeAsync(SidebarIsShow);
                }
            }
        }
       
    }
}