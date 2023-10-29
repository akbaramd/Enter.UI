using Enter.UI.Abstractions.Core;
using Enter.UI.Abstractions.Core.Bases;
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
    public partial class EntTab : EntTabBase
    {
        
        private List<EntTabPanel> _tabPanels = new List<EntTabPanel>();
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
        
        public async Task AddNewTab(EntTabPanel panel)
        {
            _tabPanels.Add(panel);

            if (_tabPanels.Count == 1)
                ActivateTab(panel.Id);

            await OnTabAdded.InvokeAsync(panel);
            StateHasChanged();
        }

        public void ActivateTab(string? id)
        {
            if (id == null)
            {
                return;
            }

            var panel = _tabPanels.FirstOrDefault(x => x.Id.Equals(id));

            if (panel == null) return;

            if (Expandable && _activeTabId != null && _activeTabId == panel.Id)
            {
                _activeTabId = null;
            }
            else
            {
                _activeTabId = panel.Id;
            }

            OnTabActivated.InvokeAsync(_activeTabId).GetAwaiter().GetResult();
            StateHasChanged();
        }

        public void RemoveTab(string? id)
        {
            if (id == null)
            {
                return;
            }

            var panel = _tabPanels.FirstOrDefault(x => x.Id.Equals(id));
            if (panel == null) return;

            _tabPanels.Remove(panel);
            
            // navigate to next tab when active tab remove
            if (_tabPanels.Count >= 1 && _activeTabId == id)
            {
                ActivateTab(_tabPanels.First().Id);
            }
            
            StateHasChanged();
        }

        public bool IsActive(string? id)
        {
            if (id == null)
            {
                return false;
            }

            return _activeTabId != null && _activeTabId.Equals(id);
        }

        private void OnTabClose(string id)
        {
            OnTabRemoveClick.InvokeAsync(id).GetAwaiter().GetResult();
        }

        private Task OnTabAllClose()
        {
            OnAllTabRemoveClick.InvokeAsync().GetAwaiter().GetResult();
            return Task.CompletedTask;
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

    public class EntTabBase : EntBaseComponent
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
        [Parameter] public EventCallback<string> OnTabRemoveClick { get; set; }
        [Parameter] public EventCallback OnAllTabRemoveClick { get; set; }
    }
}