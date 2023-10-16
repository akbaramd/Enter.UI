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
using Enter.UI.JsService.Contracts;

namespace Enter.UI.Components
{
    public partial class EntLayout : EntBaseComponent
    {
        [Inject] public IEntLayoutJsService LayoutJsService { get; set; }

        private bool _sidebarIsOpen = true;
        private DotNetObjectReference<EntLayout>? _ref  = null;  
        [Parameter] public int MobileBreakSize { get; set; } = 1028;

        protected string RootCss => CssClassBuilder.AddClass("ent-layout")
            .Build();


        protected string SidebarCss => CssClassBuilder
            .Clear()
            .AddClass(SidebarClass)
            .AddClass("ent-layout-sidebar")
            .Build();

        protected string AppBarCss => CssClassBuilder
            .Clear()
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

        [Parameter] public EventCallback<bool> OnSidebarIsShowChanged { get; set; }
        

        protected override void OnInitialized()
        {
            if (Content == null)
            {
                throw new InvalidOperationException("you must be define <Content></Content> in EntLayout");
            }
            _ref = DotNetObjectReference.Create(this);
            base.OnInitialized();
        }

        

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await LayoutJsService.InitializeAsync(this,_sidebarIsOpen,MobileBreakSize);
            }

            await base.OnAfterRenderAsync(firstRender);
        }
        
        [JSInvokable]
        public async Task CloseSidebarAsync()
        {
            _sidebarIsOpen = false;
            await LayoutJsService.ToggleAsync(_sidebarIsOpen);
            await OnSidebarIsShowChanged.InvokeAsync(_sidebarIsOpen);
        }
        
        [JSInvokable]
        public async Task OpenSidebarAsync()
        {
            _sidebarIsOpen = true;
            await LayoutJsService.ToggleAsync(_sidebarIsOpen);
            await OnSidebarIsShowChanged.InvokeAsync(_sidebarIsOpen);
        }
        
        [JSInvokable]
        public async Task ToggleSidebarAsync()
        {
            _sidebarIsOpen = !_sidebarIsOpen;
            await LayoutJsService.ToggleAsync(_sidebarIsOpen);
            await OnSidebarIsShowChanged.InvokeAsync(_sidebarIsOpen);
        }
        
    }
}