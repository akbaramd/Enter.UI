using Enter.UI.Abstractions.Core;
using Enter.UI.Abstractions.Core.Bases;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Enter.UI.Core;


namespace Enter.UI.Components
{
    public partial class EntTab : EntTabBase
    {
        
        
        private string? _activeTabId = null;
        
        protected string RootCss => CssClassBuilder
      
            .AddClass("ent-tab-horizontal", Direction == EntTabDirection.Horizontal)
            .AddClass("ent-tab-vertical", Direction == EntTabDirection.Vertical)
            .AddClass("ent-tab-expandable", Expandable)
            .AddClass("ent-tab")
            .Build();
        protected string PanelCss => new CssClassBuilder()
            .Clear()
            .AddClass("ent-tab-panel-container")
            .AddClass(PanelClass)
            .AddClass($"active", Expandable && _activeTabId != null)
            .Build();

        [Parameter] 
        public RenderFragment ChildContent { get; set; } = default!;
        
        [Parameter] public List<EntTabPanel> Panels { get; set; } = new List<EntTabPanel>();

        [Parameter] public EventCallback<List<EntTabPanel>> PanelsChanged { get; set; } = default!;
        
        [Parameter] 
        public RenderFragment? DefaultPanel { get; set; } = null;
        
        public string GetItemClass(bool active)
        {
            return  CssClassBuilder
                .Clear()
                .AddClass("ent-tab-item")
                .AddClass("active",active)
                .AddClass("ent-tab-item-horizontal", ItemDirection == EntTabItemDirection.Horizontal)
                .AddClass("ent-tab-item-vertical", ItemDirection == EntTabItemDirection.Vertical)
                .AddClass(ItemClass)
                .Build();
        }
        
        public async Task AddTabAsync(EntTabPanel panel)
        {

            if (Panels.Any(x => x.Id.Equals(panel.Id)))
                throw new Exception($"you can not add tab with duplicate id . tab with this id: '{panel.Id}' already exists");
            
            Panels.Add(panel);

            if (Panels.Count == 1)
              await  ActivateTabAsync(panel.Id);

            StateHasChanged();
            await OnTabAdded.InvokeAsync(panel);
        }

        public async Task ActivateTabAsync(string id)
        {
            
            var panel = Panels.FirstOrDefault(x => x.Id.Equals(id));

            if (panel == null) return;

            if (Expandable && _activeTabId != null && _activeTabId == panel.Id)
            {
                _activeTabId = null;
            }
            else
            {
                _activeTabId = panel.Id;
            }
            StateHasChanged();
            await OnTabActivated.InvokeAsync(_activeTabId);
        }

        public async Task RemoveTabAsync(string? id)
        {
            if (id == null)
            {
                return;
            }

            var panel = Panels.FirstOrDefault(x => x.Id.Equals(id));
            if (panel == null) return;

            Panels.Remove(panel);
            
            // navigate to next tab when active tab remove
            if (Panels.Count >= 1 && _activeTabId == id)
            {
                await ActivateTabAsync(Panels.First().Id);
            }
            StateHasChanged();
            await OnTabRemoved.InvokeAsync(id);
        }

        public bool IsActiveTab(string? id)
        {
            if (id == null)
            {
                return false;
            }
            return _activeTabId != null && _activeTabId.Equals(id);
        }

        private async Task OnTabClose(string id)
        {
            await OnTabClosedClick.InvokeAsync(id);
        }

        private async Task OnTabAllClose()
        {
            await OnAllTabClosedClick.InvokeAsync();
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

    public class EntTabBase : EntComponentBase
    {
        [Parameter] public bool KeepPanelAlive { get; set; } = false;
        [Parameter] public bool Closeable { get; set; } = false;
        [Parameter] public string ItemClass { get; set; } = string.Empty;
        [Parameter] public string PanelClass { get; set; } = string.Empty;
        [Parameter] public string ActiveClass { get; set; } = string.Empty;
        [Parameter] public bool Expandable { get; set; } = false;
        [Parameter] public string TabNoContentMessage { get; set; } = "There is no content to display";
        [Parameter] public EntTabDirection Direction { get; set; } = EntTabDirection.Vertical;
        [Parameter] public EntTabItemDirection ItemDirection { get; set; } = EntTabItemDirection.Horizontal;

        [Parameter] public EventCallback<string?> OnTabActivated { get; set; }
        [Parameter] public EventCallback<EntTabPanel> OnTabAdded { get; set; }
        [Parameter] public EventCallback<string> OnTabRemoved { get; set; }
        [Parameter] public EventCallback<string> OnTabClosedClick { get; set; }
        [Parameter] public EventCallback OnAllTabClosedClick { get; set; }
        public override void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}