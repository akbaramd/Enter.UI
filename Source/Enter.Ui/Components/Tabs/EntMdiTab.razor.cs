using Enter.Ui.Components.Tabs;
using Enter.Ui.Core;
using Enter.Ui.Cores.Contracts;
using Enter.Ui.Cores.Core;
using Microsoft.AspNetCore.Components;

// ReSharper disable once CheckNamespace
namespace Enter.Ui.Components;

public partial class EntMdiTab : EntTabComponent, IDisposable
{
    private string? _activeTabId = null;
   
    private List<EntMdiTabInstance> _items = new();
    private EntTab _tab = default!;

    
    protected override void BuildClasses(ClassBuilder builder)
    {
        builder.AddClass("ent-mdi-tab");
        base.BuildClasses(builder);
    }

    [Inject] public IEntMdiService EntMdiService { get; set; } = default!;



    public void Dispose()
    {
        EntMdiService.OnTabAddedAsync -= OnServiceNewTabAddedAsync;
        EntMdiService.OnTabActivatedAsync -= OnServiceTabActivatedAsync;
        EntMdiService.OnTabClosedAsync -= OnServiceTabRemovedAsync;
    }


    protected override void OnInitialized()
    {
        EntMdiService.OnTabAddedAsync += OnServiceNewTabAddedAsync;
        EntMdiService.OnTabActivatedAsync += OnServiceTabActivatedAsync;
        EntMdiService.OnTabClosedAsync += OnServiceTabRemovedAsync;
        base.OnInitialized();
    }

    protected override void OnAfterRender(bool firstRender)
    {
        base.OnAfterRender(firstRender);
    }
 
    private async Task OnServiceNewTabAddedAsync(EntMdiTabInstance panel)
    {

       

        if (_items.Any(x => x.Id == panel.Id))
        {

            await _tab.ActivateTabAsync(panel.Id, render: false);
        }
        else
        {
            _items.Add(panel);
            StateHasChanged();
        }
    }

    private async Task OnServiceTabActivatedAsync(EntMdiTabInstance instance)
    {
        await InvokeAsync(async () => { await _tab.ActivateTabAsync(instance.Id,render:false); });
    }

    private async Task OnServiceTabRemovedAsync(EntMdiTabInstance instance)
    {
        await InvokeAsync(async () => { await _tab.RemoveTabAsync(instance.Id,render:false); });
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
            await _tab.ActivateTabAsync(panel.Id,render:false);
     
        await OnTabAdded.InvokeAsync(panel);
 
    }

    private async Task OnTabClosedCallback(string id)
    {
        await _tab.RemoveTabAsync(id,render:false);
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
            await _tab.RemoveTabAsync(item.Id,render:false);
        

        await OnAllTabClosed.InvokeAsync();
    }


    public List<EntMdiTabInstance> GetInstance()
    {
        return _items;
    }
}