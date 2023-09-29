using global::System;
using global::System.Collections.Generic;
using global::System.Linq;
using global::System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Enter.UI.Core;
using Enter.UI.Core.Bases;

namespace Enter.UI.Components
{
    public partial class EntTab : EntTabBase
    {
        protected string RootCss => CssClassBuilder
            .AddClass("ent-tab")
            .AddClass("ent-tab-horizontal", Direction == EntTabDirection.Horizontal)
            .AddClass("ent-tab-vertical", Direction == EntTabDirection.Vertical)
            .AddClass("ent-tab-expandable", Expandable)
            .Build();

        protected string ItemCss => CssClassBuilder
            .Clear()
            .AddClass("ent-tab-item")
            .AddClass("ent-tab-item-horizontal", ItemDirection == EntTabItemDirection.Horizontal)
            .AddClass("ent-tab-item-vertical", ItemDirection == EntTabItemDirection.Vertical)
            .AddClass(ItemClass)
            .Build();

        protected string PanelCss => CssClassBuilder
            .Clear()
            .AddClass("ent-tab-panel-container")
            .AddClass(PanelClass)
            .AddClass($"active", Expandable && ActiveTabId != null)
            .Build();

        [Parameter] public RenderFragment ChildContent { get; set; }
        
        [Parameter] public RenderFragment? DefaultPanel { get; set; }
        private List<EntTabPanel> TabPanels = new List<EntTabPanel>();
        private string? ActiveTabId = null;

        public async Task AddNewTab(EntTabPanel panel)
        {
            TabPanels.Add(panel);

            if (TabPanels.Count == 1)
                ActiveTab(panel.Id);

            OnTabAdded.InvokeAsync(panel).GetAwaiter().GetResult();
            StateHasChanged();
        }

        public void ActiveTab(string? id)
        {
            if (id == null)
            {
                return;
            }

            var panel = TabPanels.FirstOrDefault(x => x.Id.Equals(id));

            if (panel == null) return;

            if (Expandable && ActiveTabId != null && ActiveTabId == panel.Id)
            {
                ActiveTabId = null;
            }
            else
            {
                ActiveTabId = panel.Id;
            }

            OnTabActived.InvokeAsync(ActiveTabId).GetAwaiter().GetResult();
            StateHasChanged();
        }

        public void RemoveTab(string? id)
        {
            if (id == null)
            {
                return;
            }

            var panel = TabPanels.FirstOrDefault(x => x.Id.Equals(id));
            if (panel == null) return;

            TabPanels.Remove(panel);
            
            // navigate to next tab when active tab remove
            if (TabPanels.Count >= 1 && ActiveTabId == id)
            {
                ActiveTab(TabPanels.First().Id);
            }
            
            StateHasChanged();
        }

        public bool IsActivePanel(string? id)
        {
            if (id == null)
            {
                return false;
            }

            return ActiveTabId != null && ActiveTabId.Equals(id);
        }

        private void OnTabClose(string id) =>
            OnTabClosed.InvokeAsync(id).GetAwaiter().GetResult();
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
        [Parameter] public string ItemClass { get; set; }
        [Parameter] public string PanelClass { get; set; }
        [Parameter] public string ActiveClass { get; set; }
        [Parameter] public bool Expandable { get; set; } = false;
        [Parameter] public EntTabDirection Direction { get; set; } = EntTabDirection.Vertical;
        [Parameter] public EntTabItemDirection ItemDirection { get; set; } = EntTabItemDirection.Horizontal;

        [Parameter] public EventCallback<string?> OnTabActived { get; set; }
        [Parameter] public EventCallback<EntTabPanel> OnTabAdded { get; set; }
        [Parameter] public EventCallback<string> OnTabClosed { get; set; }
    }
}