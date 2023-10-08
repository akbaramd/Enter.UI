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
    public interface IEntMdiService
    {
        //public List<EntMdiTabItem> TabPanels { get; set; } 
        public EntMdiTabItem? ActiveTabPanel { get; set; }

        //public event Action<EntMdiTabItem> OnTabAdded;
        //public event Action<EntMdiTabItem> OnTabActivated;
        //public event Action OnTabRemoved;

        public void AddNewTab<TComponent>(string id , string title,string icon, EntIconType iconType= EntIconType.IconTag, Dictionary<string, object>? parameters = null) where TComponent : ComponentBase;
        public void AddNewTab(string id , Type type, string title, string icon, EntIconType iconType= EntIconType.IconTag, Dictionary<string, object>? parameters = null);
        public void RemoveTab(string id);
        public void SetActiveTab(string id, bool notify = true);
    }
}
