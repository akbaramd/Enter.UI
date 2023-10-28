using global::System;
using global::System.Collections.Generic;
using global::System.Linq;
using global::System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Enter.UI.Services.Contracts;
using Enter.UI.Core;

namespace Enter.UI.Components
{
    public partial class EntMdiTab : EntTabBase , IAsyncDisposable
    {
         public List<EntMdiTabInstance> TabPanels { get; set; } = new List<EntMdiTabInstance>();
        protected string RootCss => CssClassBuilder
            .AddClass("ent-mdi-tab")
            .Build();

        [Parameter]
        public RenderFragment? ChildContent { get; set; }
        
        private EntMdiService _entMdiService = default!;
        public List<EntMdiTabInstance> Items { get; set; } = new List<EntMdiTabInstance>();
        [Inject] public IEntMdiService EntMdiService { get; set; } = default!;
        
        public EntTab Tab { get; set; }


        private string? ActiveTabId { get; set; } = null;
        protected override async Task OnInitializedAsync()
        {
            _entMdiService = (EntMdiService)EntMdiService ?? throw new InvalidOperationException("AddEnterUI is not added to your program.cs");

            _entMdiService.OnTabAdded += OnServiceNewTabAdded;
            _entMdiService.OnTabActivated += OnServiceTabActivated;
            _entMdiService.OnTabClosed += OnServiceTabRemoved;

            await base.OnInitializedAsync();

        }

        private void OnServiceNewTabAdded(EntMdiTabInstance panel)
        {

            if (Items.Any(x => x.Id == panel.Id))
            {
                Tab.ActiveTab(panel.Id);
                return;
            }
            Items.Add(panel);
            StateHasChanged();
        }
        
        private void OnServiceTabActivated(string id)
        {
            Tab.ActiveTab(id);
        }

        private void OnServiceTabRemoved(string id)
        {
            Items.RemoveAll(x => x.Id == id);
            Tab.RemoveTab(id);
            StateHasChanged();
        }

        private void OnTabActivatedCallback(string? id)
        { 
            var activeTab = Items.FirstOrDefault(x => x.Id == id);

            if (activeTab != null && activeTab.OnActivated != null)
            {
                activeTab.OnActivated.Invoke();
            }
            StateHasChanged();
        }

        private void OnTabAddedCallback(EntTabPanel panel)
        {
            Tab.ActiveTab(panel.Id);
            StateHasChanged();
        }

        private void OnTabClosedCallback(string id)
        {
            Items.RemoveAll(x => x.Id == id);
            Tab.RemoveTab(id);
            StateHasChanged();
        }
        
        private void OnAllTabClosedCallback()
        {
            var items = Items.ToList();
            foreach (var item in items)
            {
                Items.RemoveAll(x => x.Id == item.Id);
                Tab.RemoveTab(item.Id);
            }
            StateHasChanged();
        }

        public async ValueTask DisposeAsync()
        {
            _entMdiService.OnTabAdded -= OnServiceNewTabAdded;
            _entMdiService.OnTabActivated -= OnServiceTabActivated;
            _entMdiService.OnTabClosed -= OnServiceTabRemoved;
        }
    }

}