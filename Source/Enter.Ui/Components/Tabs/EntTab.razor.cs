using Enter.Ui.Bases;
using Enter.Ui.Core;
using Enter.Ui.Cores.Core;
using Microsoft.AspNetCore.Components;

// ReSharper disable once CheckNamespace
namespace Enter.Ui.Components;

public partial class EntTab : EntTabComponent
{
    private string? _activeTabId = null;


    private bool _toggleMenu = false;
    private EntTabPanel? _activeTab => Panels.FirstOrDefault(x => x.Id.Equals(_activeTabId));

    
   

    public EntTab()
    {
        PanelClassBuilder = new ClassBuilder(BuildPanelClasses);
        ItemClassBuilder = new ClassBuilder(BuildItemClasses);
    }

    public ClassBuilder PanelClassBuilder { get; set; }
    public ClassBuilder ItemClassBuilder { get; set; }
    
    public string PanelClassNames => PanelClassBuilder.Build();
    public string ItemClassNames => ItemClassBuilder.Build();

    
    protected override void BuildClasses(ClassBuilder builder)
    {
        builder.AddClass("ent-tab")
            .AddClass("ent-tab-resposive")
            .AddClass("ent-tab-horizontal", Direction == EntTabDirection.Horizontal)
            .AddClass("ent-tab-vertical", Direction == EntTabDirection.Vertical)
            .AddClass("ent-tab-expandable", Expandable);
        base.BuildClasses(builder);
    }

    protected  void BuildPanelClasses(ClassBuilder builder)
    {
        builder.AddClass("ent-tab-panel-container")
            .AddClass("ent-tab-panel-container-resposive")
            .AddClass(PanelClass)
            .AddClass("active", Expandable && _activeTabId != null);
    }
    protected  void BuildItemClasses(ClassBuilder builder)
    {
        builder.AddClass("ent-tab-item")
            .AddClass("ent-tab-item-horizontal", ItemDirection == EntTabItemDirection.Horizontal)
            .AddClass("ent-tab-item-vertical", ItemDirection == EntTabItemDirection.Vertical)
            .AddClass("ent-tab-item-minify", IconMinify)
            .AddClass(ItemClass);
    }
    protected override void OnAfterRender(bool firstRender)
    {
        base.OnAfterRender(firstRender);
    }
    [Parameter] public List<EntTabPanel> Panels { get; set; } = new();

    [Parameter] public EventCallback<List<EntTabPanel>> PanelsChanged { get; set; } = default!;


    [Parameter] public RenderFragment? DefaultPanel { get; set; } = null;

    protected override void OnParametersSet()
    {
        StyleBuilder?.CanUpdate();
        ClassBuilder?.CanUpdate();
        ItemClassBuilder.CanUpdate();
        PanelClassBuilder.CanUpdate();
        base.OnParametersSet();
    }

    public async Task AddTabAsync(EntTabPanel panel , bool render = true)
    {
        if (Panels.Any(x => x.Id.Equals(panel.Id)))
            throw new Exception(
                $"you can not add tab with duplicate id . tab with this id: '{panel.Id}' already exists");

        Panels.Add(panel);

        if (Panels.Count == 1)
            await ActivateTabAsync(panel.Id);


        if (render)
            StateHasChanged();
        await OnTabAdded.InvokeAsync(panel);
    }

    public async Task ActivateTabAsync(string id, bool render = true)
    {
        var panel = Panels.FirstOrDefault(x => x.Id.Equals(id));

        if (panel == null) return;

        if (Expandable && _activeTabId != null && _activeTabId == panel.Id)
            _activeTabId = null;
        else
            _activeTabId = panel.Id;
        
        if (ResponsiveMode.GetValueOrDefault(false)) _toggleMenu = false;

  
        if (render)
            StateHasChanged();
        await OnTabActivated.InvokeAsync(_activeTabId);
    }

    public async Task RemoveTabAsync(string? id, bool render = true)
    {
        if (id == null) return;

        var panel = Panels.FirstOrDefault(x => x.Id.Equals(id));
        if (panel == null) return;

        Panels.Remove(panel);

        // navigate to next tab when active tab remove
        if (Panels.Count >= 1 && _activeTabId == id) await ActivateTabAsync(Panels.First().Id);

        if (ResponsiveMode.GetValueOrDefault(false)) _toggleMenu = false;
        
        if (render)
            StateHasChanged();
        await OnTabRemoved.InvokeAsync(id);
    }

    public bool IsActiveTab(string? id)
    {
        if (id == null) return false;
        return _activeTabId != null && _activeTabId.Equals(id);
    }

    private async Task OnTabClose(string id)
    {
        await OnTabClosed.InvokeAsync(id);
    }

    private async Task OnTabAllClose()
    {
        await OnAllTabClosed.InvokeAsync();
        
    }

    private void OnToggleMenu()
    {
        if (Panels.Any()) _toggleMenu = !_toggleMenu;
    }
}

public enum EntTabDirection
{
    Vertical,
    Horizontal
}

public enum EntTabItemDirection
{
    Vertical,
    Horizontal
}

public class EntTabComponent : EntResponsiveComponent
{
    public override string ComponentName { get; }
    [Parameter] public bool KeepPanelAlive { get; set; } = false;
    [Parameter] public bool Closeable { get; set; } = false;
    [Parameter] public string ItemClass { get; set; } = string.Empty;
    [Parameter] public string PanelClass { get; set; } = string.Empty;
    [Parameter] public string ActiveClass { get; set; } = string.Empty;
    [Parameter] public bool Expandable { get; set; } = false;

    [Parameter] public bool IconMinify { get; set; }
    [Parameter] 
    public bool HasBackdrop { get; set; } = false;
    [Parameter] public string TabNoContentMessage { get; set; } = "There is no content to display";
    [Parameter] public EntTabDirection Direction { get; set; } = EntTabDirection.Vertical;
    [Parameter] public EntTabItemDirection ItemDirection { get; set; } = EntTabItemDirection.Horizontal;

    [Parameter] public EventCallback<string?> OnTabActivated { get; set; }
    [Parameter] public EventCallback<EntTabPanel> OnTabAdded { get; set; }
    [Parameter] public EventCallback<string> OnTabRemoved { get; set; }
    [Parameter] public EventCallback<string> OnTabClosed { get; set; }
    [Parameter] public EventCallback OnAllTabClosed { get; set; }

   
}