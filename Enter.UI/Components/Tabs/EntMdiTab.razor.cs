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
        
        private EntMdiService _entMdiService = default!;
        public List<EntMdiTabItem> Items { get; set; } = new List<EntMdiTabItem>();
        [Inject] public IEntMdiService EntMdiService { get; set; } = default!;
        public EntTab Tab { get; set; }
        protected override async Task OnInitializedAsync()
        {
            if (EntMdiService == null)
                throw new InvalidOperationException("AddEnterUI is not added to your program.cs");

            _entMdiService = (EntMdiService)EntMdiService;

            _entMdiService.OnTabAdded += OnServiceNewTabAdded;
            _entMdiService.OnTabActivated += OnServiceTabActivated;
            _entMdiService.OnTabRemoved += OnServiceTabRemoved;

            await base.OnInitializedAsync();

        }

        private void OnServiceNewTabAdded(EntMdiTabItem panel)
        {
            Items = _entMdiService.TabPanels.ToList();
            StateHasChanged();
        }
        private void OnServiceTabActivated(EntMdiTabItem? panel)
        {
            if (panel != null)
            {
                Items = _entMdiService.TabPanels.ToList();
                Tab.ActiveTab(panel.Id);
            }
            StateHasChanged();
        }

        private void OnServiceTabRemoved()
        {
            Items = _entMdiService.TabPanels.ToList();
            StateHasChanged();
        }

        private void OnTabActivatedCallback(string? id)
        {
            EntMdiService.SetActiveTab(id,false);
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
            EntMdiService.RemoveTab(id);
            OnTabClosed.InvokeAsync(id).GetAwaiter().GetResult();
        }
        
        private void OnAllTabClosedCallback()
        {
            foreach (var item in Items)
            {
                Tab.RemoveTab(item.Id);
                EntMdiService.RemoveTab(item.Id);
                OnTabClosed.InvokeAsync(item.Id).GetAwaiter().GetResult();
            }
        }

    }

}