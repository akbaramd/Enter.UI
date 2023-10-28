using Enter.UI.Components;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enter.UI.Components
{
    public interface IEntMdiService
    {
       

        //public event Action<EntMdiTabInstance> OnTabAdded;
        //public event Action<string> OnTabActivated;
        //public event Action<string> OnTabClosed;

        public void AddNewTab<TComponent>(string id , string title,string icon, Dictionary<string, object>? parameters = null) where TComponent : ComponentBase;
        public void AddNewTab(string id , Type type, string title, string icon, Dictionary<string, object>? parameters = null);
        public void CloseTab(string id);
        public void SetActiveTab(string id);
    }
}
