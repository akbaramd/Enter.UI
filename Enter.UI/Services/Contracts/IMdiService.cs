using Enter.UI.Components;
using Enter.UI.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enter.UI.Services.Contracts
{
    public interface IMdiService 
    {
        //public List<EntMdiTabItem> TabPanels { get; set; } 
        public EntMdiTabItem? ActiveTabPanel { get; set; }

        //public event Action<EntMdiTabItem> OnTabAdded;
        //public event Action<EntMdiTabItem> OnTabActivated;
        //public event Action OnTabRemoved;

        public void AddNewTab<TComponent>(string title, string icon, Dictionary<string,object>? parameters = null) where TComponent: ComponentBase;
        public void AddNewTab(Type type, string title, string icon, Dictionary<string, object>? parameters = null);
        public void RemoveTab(Guid id);
        public void SetActiveTab(Guid? guid,bool notify = true);
    }
}
