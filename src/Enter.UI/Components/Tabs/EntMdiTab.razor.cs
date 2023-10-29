using Enter.UI.Abstractions.Components.Tabs;
using Enter.UI.Abstractions.Services;
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
    public partial class EntMdiTab : EntTabBase , IAsyncDisposable
    {
         private EntMdiService _entMdiService  = default!;
         private List<EntMdiTabInstance> _items  = new();
         private EntTab _tab  = default!;
         private string? _activeTabId  = null;
         
         private string RootCss => CssClassBuilder
            .AddClass("ent-mdi-tab")
            .Build();

        [Inject] 
        public IEntMdiService EntMdiService { get; set; } = default!;
         
        [Parameter] 
        public RenderFragment? ChildContent { get; set; }

        public string Message { get; set; } = "";
        
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
            if (_items.Any(x => x.Id == panel.Id))
            {
                _tab.ActivateTab(panel.Id);
                return;
            }
            _items.Add(panel);
            StateHasChanged();
        }
        
        private void OnServiceTabActivated(string id)
        {
            _tab.ActivateTab(id);
        }

        private void OnServiceTabRemoved(string id)
        {
            _items.RemoveAll(x => x.Id == id);
            _tab.RemoveTab(id);
            StateHasChanged();
        }

        private void OnTabActivatedCallback(string? id)
        { 
            var activeTab = _items.FirstOrDefault(x => x.Id == id);

            if (activeTab != null && activeTab.OnActivated != null)
            {
                activeTab.OnActivated.Invoke();
            }
            StateHasChanged();
        }

        private void OnTabAddedCallback(EntTabPanel panel)
        {
            _tab.ActivateTab(panel.Id);
            StateHasChanged();
        }

        private void OnTabClosedCallback(string id)
        {
            _items.RemoveAll(x => x.Id == id);
            _tab.RemoveTab(id);
            StateHasChanged();
        }
        
        private void OnAllTabClosedCallback()
        {
            var items = _items.ToList();
            foreach (var item in items)
            {
                _items.RemoveAll(x => x.Id == item.Id);
                _tab.RemoveTab(item.Id);
            }
            StateHasChanged();
        }

        public ValueTask DisposeAsync()
        {
            _entMdiService.OnTabAdded -= OnServiceNewTabAdded;
            _entMdiService.OnTabActivated -= OnServiceTabActivated;
            _entMdiService.OnTabClosed -= OnServiceTabRemoved;
            return ValueTask.CompletedTask;
        }
    }

}