using Enter.UI.Core;
using Enter.UI.Cores.Bases;
using Microsoft.AspNetCore.Components;

namespace Enter.UI.Components;

public partial class EntTab : EntTabBase
{
    private string? _activeTabId = null;


    private bool _toggleMenu = false;
    private EntTabPanel? _activeTab => Panels.FirstOrDefault(x => x.Id.Equals(_activeTabId));

    protected string RootCss => CssBuilder
        .AddCss("ent-tab")
        .AddResponsiveModeCss("ent-tab-resposive")
        .AddCss("ent-tab-horizontal", Direction == EntTabDirection.Horizontal)
        .AddCss("ent-tab-vertical", Direction == EntTabDirection.Vertical)
        .AddCss("ent-tab-expandable", Expandable)
        .Build();

    protected string PanelCss => new CssBuilder()
        .Clear()
        .AddCss("ent-tab-panel-container")
        .AddResponsiveModeCss("ent-tab-panel-container-resposive")
        .AddCss(PanelClass)
        .AddCss("active", Expandable && _activeTabId != null)
        .Build();

    [Parameter] public RenderFragment ChildContent { get; set; } = default!;

    [Parameter] public List<EntTabPanel> Panels { get; set; } = new();

    [Parameter] public EventCallback<List<EntTabPanel>> PanelsChanged { get; set; } = default!;


    [Parameter] public RenderFragment? DefaultPanel { get; set; } = null;

    protected override Task OnAfterRenderAsync(bool firstRender)
    {
        return base.OnAfterRenderAsync(firstRender);
    }


    public string GetItemClass(bool active)
    {
        return CssBuilder
            .Clear()
            .AddCss("ent-tab-item")
            .AddCss("active", active)
            .AddCss("ent-tab-item-horizontal", ItemDirection == EntTabItemDirection.Horizontal)
            .AddCss("ent-tab-item-vertical", ItemDirection == EntTabItemDirection.Vertical)
            .AddCss("ent-tab-item-minify", IconMinify)
            .AddCss(ItemClass)
            .Build();
    }

    public async Task AddTabAsync(EntTabPanel panel)
    {
        if (Panels.Any(x => x.Id.Equals(panel.Id)))
            throw new Exception(
                $"you can not add tab with duplicate id . tab with this id: '{panel.Id}' already exists");

        Panels.Add(panel);

        if (Panels.Count == 1)
            await ActivateTabAsync(panel.Id);

        StateHasChanged();
        await OnTabAdded.InvokeAsync(panel);
    }

    public async Task ActivateTabAsync(string id)
    {
        var panel = Panels.FirstOrDefault(x => x.Id.Equals(id));

        if (panel == null) return;

        if (Expandable && _activeTabId != null && _activeTabId == panel.Id)
            _activeTabId = null;
        else
            _activeTabId = panel.Id;
        if (ResponsiveMode) _toggleMenu = false;

        StateHasChanged();
        await OnTabActivated.InvokeAsync(_activeTabId);
    }

    public async Task RemoveTabAsync(string? id)
    {
        if (id == null) return;

        var panel = Panels.FirstOrDefault(x => x.Id.Equals(id));
        if (panel == null) return;

        Panels.Remove(panel);

        // navigate to next tab when active tab remove
        if (Panels.Count >= 1 && _activeTabId == id) await ActivateTabAsync(Panels.First().Id);


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

public class EntTabBase : EntResponsiveComponentBase
{
    [Parameter] public bool KeepPanelAlive { get; set; } = false;
    [Parameter] public bool Closeable { get; set; } = false;
    [Parameter] public string ItemClass { get; set; } = string.Empty;
    [Parameter] public string PanelClass { get; set; } = string.Empty;
    [Parameter] public string ActiveClass { get; set; } = string.Empty;
    [Parameter] public bool Expandable { get; set; } = false;

    [Parameter] public bool IconMinify { get; set; }

    [Parameter] public string TabNoContentMessage { get; set; } = "There is no content to display";
    [Parameter] public EntTabDirection Direction { get; set; } = EntTabDirection.Vertical;
    [Parameter] public EntTabItemDirection ItemDirection { get; set; } = EntTabItemDirection.Horizontal;

    [Parameter] public EventCallback<string?> OnTabActivated { get; set; }
    [Parameter] public EventCallback<EntTabPanel> OnTabAdded { get; set; }
    [Parameter] public EventCallback<string> OnTabRemoved { get; set; }
    [Parameter] public EventCallback<string> OnTabClosed { get; set; }
    [Parameter] public EventCallback OnAllTabClosed { get; set; }

    public override void Dispose()
    {
    }
}