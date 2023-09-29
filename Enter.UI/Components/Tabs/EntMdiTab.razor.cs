using global::System;
using global::System.Collections.Generic;
using global::System.Linq;
using global::System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Enter.UI.Services.Contracts;
using Enter.UI.Models;
using Enter.UI.Services;
using Enter.UI.Core;

namespace Enter.UI.Components
{
    public partial class EntMdiTab : EntTabBase
    {
        protected string RootCss => CssClassBuilder
            .AddClass("ent-mdi-tab")
            .Build();

        [Parameter]
        public RenderFragment? ChildContent { get; set; }
        
        private MdiService _mdiService = default!;
        public List<EntMdiTabItem> Items { get; set; } = new List<EntMdiTabItem>();
        [Inject] public IMdiService MdiService { get; set; } = default!;
        public EntTab Tab { get; set; }
        protected override async Task OnInitializedAsync()
        {
            if (MdiService == null)
                throw new InvalidOperationException("AddEnterUI is not added to your program.cs");

            _mdiService = (MdiService)MdiService;

            _mdiService.OnTabAdded += OnServiceNewTabAdded;
            _mdiService.OnTabActivated += OnServiceTabActivated;
            _mdiService.OnTabRemoved += OnServiceTabRemoved;

            await base.OnInitializedAsync();

        }

        private void OnServiceNewTabAdded(EntMdiTabItem panel)
        {
            Items = _mdiService.TabPanels.ToList();
            StateHasChanged();
        }
        private void OnServiceTabActivated(EntMdiTabItem? panel)
        {
            if (panel != null)
            {
                Items = _mdiService.TabPanels.ToList();
                Tab.ActiveTab(panel.Id);
            }
            StateHasChanged();
        }

        private void OnServiceTabRemoved()
        {
            Items = _mdiService.TabPanels.ToList();
            StateHasChanged();
        }

        private void OnTabActivatedCallback(string? id)
        {
            MdiService.SetActiveTab(id,false);
            OnTabActived.InvokeAsync(id).GetAwaiter().GetResult();
        }

        private void OnTabAddedCallback(EntTabPanel panel)
        {
            Tab.ActiveTab(panel.Id);
            OnTabAdded.InvokeAsync(panel).GetAwaiter().GetResult();
        }

        private void OnTabClosedCallback(string id)
        {
            Tab.RemoveTab(id);
            MdiService.RemoveTab(id);
            OnTabClosed.InvokeAsync(id).GetAwaiter().GetResult();
        }

    }

}