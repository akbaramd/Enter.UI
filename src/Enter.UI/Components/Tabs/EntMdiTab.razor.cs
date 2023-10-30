using Enter.UI.Abstractions.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Enter.UI.Core;
using Enter.UI.Abstractions.Components.Tabs;

namespace Enter.UI.Components
{
    public partial class EntMdiTab : EntTabBase, IAsyncDisposable
    {
        private EntMdiService _entMdiService = default!;
        private List<EntMdiTabInstance> _items = new();
        private EntTab _tab = default!;
        private string? _activeTabId = null;

        private string RootCss => CssClassBuilder
           .AddClass("ent-mdi-tab")
           .Build();

        [Inject]
        public IEntMdiService EntMdiService { get; set; } = default!;

        [Parameter]
        public RenderFragment? ChildContent { get; set; }


        protected override async Task OnInitializedAsync()
        {
            _entMdiService = (EntMdiService)EntMdiService ?? throw new InvalidOperationException("AddEnterUI is not added to your program.cs");

            // Initilize MdiTabService Event
            _entMdiService.OnTabAddedAsync += OnServiceNewTabAddedAsync;
            _entMdiService.OnTabActivatedAsync += OnServiceTabActivatedAsync;
            _entMdiService.OnTabClosedAsync += OnServiceTabRemovedAsync;

            await base.OnInitializedAsync();

        }

     
        private async Task OnServiceNewTabAddedAsync(EntMdiTabInstance panel)
        {
            if (_items.Any(x => x.Id == panel.Id))
            {
                await _tab.ActivateTabAsync(panel.Id);
                return;
            }
            _items.Add(panel);
            StateHasChanged();
        }

        private async Task OnServiceTabActivatedAsync(string id)
        {
            await _tab.ActivateTabAsync(id);
        }

        private async Task OnServiceTabRemovedAsync(string id)
        {
            await _tab.RemoveTabAsync(id);
        }

        private async Task OnTabActivatedCallbackAsync(string? id)
        {
            var activeTab = _items.FirstOrDefault(x => x.Id == id);

            if (activeTab != null && activeTab.OnActivatedAsync != null)
            {
               await activeTab.OnActivatedAsync.Invoke(id);
            }
            StateHasChanged();
        }

        private async Task OnTabAddedCallback(EntTabPanel panel)
        {
            if (_items.Count > 1)
            {
                await _tab.ActivateTabAsync(panel.Id);
            }
        }

        private async Task OnTabClosedCallback(string id)
        {
            await _tab.RemoveTabAsync(id);

        }

        private Task OnTabRemovedCallback(string id)
        {
            _items.RemoveAll(x => x.Id == id);
            StateHasChanged();
            return Task.CompletedTask;
        }

        private async Task OnAllTabClosedCallback()
        {
            var items = _items.ToList();
            foreach (var item in items)
            {
                await _tab.RemoveTabAsync(item.Id);
            }

        }

        public ValueTask DisposeAsync()
        {
            _entMdiService.OnTabAddedAsync -= OnServiceNewTabAddedAsync;
            _entMdiService.OnTabActivatedAsync -= OnServiceTabActivatedAsync;
            _entMdiService.OnTabClosedAsync -= OnServiceTabRemovedAsync;
            return ValueTask.CompletedTask;
        }
    }

}