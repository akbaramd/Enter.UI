using global::System;
using global::System.Collections.Generic;
using global::System.Linq;
using global::System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web;
using Enter.UI.Components.Controllers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Enter.UI.Bases;
using Enter.UI.Core;

namespace Enter.UI.Components
{
    public partial class EntTab : EntTabBase
    {


        protected string tabCssClass => new CssClassBuilder("ent-tab")
          .AddClass($"ent-tab-horizontal", Direction == EntTabDirection.Horizontal)
          .AddClass($"ent-tab-vertical", Direction == EntTabDirection.Vertical)
          .AddClass($"ent-tab-expandable", Direction == EntTabDirection.Vertical)
          .AddClass(Class)
          .Build();

        protected string tabItemCssClass => new CssClassBuilder("ent-tab-item")
         .AddClass($"ent-tab-item-horizontal", ItemDirection == EntTabItemDirection.Horizontal)
         .AddClass($"ent-tab-item-vertical", ItemDirection == EntTabItemDirection.Vertical)
          .AddClass(ItemClass)
         .Build();

        protected string tabPanelCssClass => new CssClassBuilder("ent-tab-panel-container")
         .AddClass(PanelClass)
         .AddClass($"ent-tab-panel-container-collapse", Expandable && ActiveTabId == null)
         .Build();

        [Parameter]
        public RenderFragment ChildContent { get; set; }


        private List<EntTabPanel> TabPanels = new List<EntTabPanel>();
        private Guid? ActiveTabId = null;


        public async Task AddNewTab(EntTabPanel panel)
        {
            TabPanels.Add(panel);

            if (TabPanels.Count == 1)
                ActiveTab(panel.TabId);

            OnTabAdded.InvokeAsync(panel).GetAwaiter().GetResult();
            StateHasChanged();
        }

        public void ActiveTab(Guid? id)
        {

            if (!id.HasValue || id.Value == Guid.Empty) { return; }

            var panel = TabPanels.FirstOrDefault(x => x.TabId.Equals(id.Value));

            if (panel == null) return;

            if (Expandable && ActiveTabId.HasValue && ActiveTabId.Value == panel.TabId)
            {
                ActiveTabId = null;
            }
            else
            {
                ActiveTabId = panel.TabId;
            }

            OnTabActived.InvokeAsync(ActiveTabId).GetAwaiter().GetResult();
            StateHasChanged();
        }
        public void RemoveTab(Guid? id)
        {
            if (!id.HasValue || id.Value == Guid.Empty) { return; }
            var panel = TabPanels.FirstOrDefault(x => x.TabId.Equals(id.Value));
            if (panel == null) return;

            TabPanels.Remove(panel);
            StateHasChanged();
        }
        public bool IsActivePanel(Guid id)
        {
            return ActiveTabId != null && ActiveTabId.Value.Equals(id);
        }

        private void OnTabClose(Guid id) =>
            OnTabClosed.InvokeAsync(id).GetAwaiter().GetResult();
    }

    public enum EntTabDirection
    {
        Vertical, Horizontal
    }

    public enum EntTabItemDirection
    {
        Vertical, Horizontal
    }

    public class EntTabBase : EntBaseComponent
    {
        [Parameter]
        public bool KeepPanelAlive { get; set; } = false;
        [Parameter]
        public bool Closeable { get; set; } = false;
        [Parameter]
        public string ItemClass { get; set; }
        [Parameter]
        public string PanelClass { get; set; }
        [Parameter]
        public string ActiveClass { get; set; }
        [Parameter]
        public bool Expandable { get; set; } = false;
        [Parameter]
        public EntTabDirection Direction { get; set; } = EntTabDirection.Vertical;
        [Parameter]
        public EntTabItemDirection ItemDirection { get; set; } = EntTabItemDirection.Horizontal;

        [Parameter]
        public EventCallback<Guid?> OnTabActived { get; set; }
        [Parameter]
        public EventCallback<EntTabPanel> OnTabAdded { get; set; }
        [Parameter]
        public EventCallback<Guid> OnTabClosed { get; set; }

    }
}