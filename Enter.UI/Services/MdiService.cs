using Enter.UI.Components;
using Enter.UI.Models;
using Enter.UI.Services.Contracts;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enter.UI.Services
{
    internal class MdiService : IMdiService
    {
        public List<EntMdiTabItem> TabPanels { get; set; } = new List<EntMdiTabItem>();
        public EntMdiTabItem? ActiveTabPanel { get; set; }



        public event Action<EntMdiTabItem> OnTabAdded;
        public event Action<EntMdiTabItem?> OnTabActivated;
        public event Action OnTabRemoved;

        public void AddNewTab<TComponent>(string title, string icon, Dictionary<string, object>? parameters = null) where TComponent : ComponentBase
        {
             AddNewTab(typeof(TComponent), title, icon, parameters);
        }

        public  void AddNewTab(Type type, string title, string icon, Dictionary<string, object>? parameters = null)
        {
            var item = new EntMdiTabItem() { ComponentType = type, Icon = icon, Title = title, ComponentParameters = parameters, TabId = Guid.NewGuid() };
            TabPanels.Add(item);
            OnTabAdded.Invoke(item);
        }

        public  void RemoveTab(Guid id)
        {
            TabPanels.Remove(TabPanels.First(x => x.TabId == id));
            OnTabRemoved.Invoke();
        }

        public  void SetActiveTab(Guid? id,bool notify = true)
        {
            ActiveTabPanel = TabPanels.FirstOrDefault(x=>x.TabId == id);

            if (notify)
            {
                OnTabActivated.Invoke(ActiveTabPanel);
            }
        }
    }
}
