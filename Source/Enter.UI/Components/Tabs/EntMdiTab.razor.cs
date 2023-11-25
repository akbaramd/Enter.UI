using Enter.UI.Components.Tabs;
using Enter.UI.Services;
using Microsoft.AspNetCore.Components;

namespace Enter.UI.Components;

public partial class EntMdiTab : EntTabBase, IDisposable
{
    private string? _activeTabId = null;
   
    private List<EntMdiTabInstance> _items = new();
    private EntTab _tab = default!;

    private string RootCss => CssBuilder
        .AddCss("ent-mdi-tab")
        .Build();

    [Inject] public IEntMdiService EntMdiService { get; set; } = default!;

    [Parameter] public RenderFragment? ChildContent { get; set; }

    public void Dispose()
    {
        EntMdiService.OnTabAddedAsync -= OnServiceNewTabAddedAsync;
        EntMdiService.OnTabActivatedAsync -= OnServiceTabActivatedAsync;
        EntMdiService.OnTabClosedAsync -= OnServiceTabRemovedAsync;
    }


    protected override async Task OnInitializedAsync()
    {
        // Initilize MdiTabService Event
        EntMdiService.OnTabAddedAsync += OnServiceNewTabAddedAsync;
        EntMdiService.OnTabActivatedAsync += OnServiceTabActivatedAsync;
        EntMdiService.OnTabClosedAsync += OnServiceTabRemovedAsync;

        await base.OnInitializedAsync();
    }

    protected override Task OnAfterRenderAsync(bool firstRender)
    {
        return base.OnAfterRenderAsync(firstRender);
    }

    protected override Task OnParametersSetAsync()
    {
        return base.OnParametersSetAsync();
    }

    private async Task OnServiceNewTabAddedAsync(EntMdiTabInstance panel)
    {
        await InvokeAsync(async () =>
        {
            if (_items.Any(x => x.Id == panel.Id))
            {
                await _tab.ActivateTabAsync(panel.Id);
                return;
            }

            _items.Add(panel);
            StateHasChanged();
        });
    }

    private async Task OnServiceTabActivatedAsync(EntMdiTabInstance instance)
    {
        await InvokeAsync(async () => { await _tab.ActivateTabAsync(instance.Id); });
    }

    private async Task OnServiceTabRemovedAsync(EntMdiTabInstance instance)
    {
        await InvokeAsync(async () => { await _tab.RemoveTabAsync(instance.Id); });
    }

    
    private async Task OnTabActivatedCallbackAsync(string? id)
    {
        var activeTab = _items.FirstOrDefault(x => x.Id == id);

        if (activeTab != null && activeTab.OnActivatedAsync != null)

        {
            activeTab.IsActive = true;
            await activeTab.OnActivatedAsync.Invoke(id);
        }

        await OnTabActivated.InvokeAsync(id);
        StateHasChanged();
    }

    private async Task OnTabAddedCallback(EntTabPanel panel)
    {
        if (_items.Count > 1) 
            await _tab.ActivateTabAsync(panel.Id);
        await OnTabAdded.InvokeAsync(panel);
    }

    private async Task OnTabClosedCallback(string id)
    {
        await _tab.RemoveTabAsync(id);
        await OnTabClosed.InvokeAsync(id);
    }

    private async Task OnTabRemovedCallback(string id)
    {
        _items.RemoveAll(x => x.Id == id);
        StateHasChanged();
        await OnTabRemoved.InvokeAsync(id);
    }

    private async Task OnAllTabClosedCallback()
    {
        var items = _items.ToList();
        foreach (var item in items) 
            await _tab.RemoveTabAsync(item.Id);
        await OnAllTabClosed.InvokeAsync();
    }


    public List<EntMdiTabInstance> GetInstance()
    {
        return _items;
    }
}