using Enter.UI.Components;
using Enter.UI.Services.Contracts;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enter.UI.Components
{
    internal class EntMdiService : IEntMdiService
    {

        public event Action<EntMdiTabInstance> OnTabAdded;
        public event Action<string> OnTabActivated;
        public event Action<string> OnTabClosed;

        public void AddNewTab<TComponent>(string id, string title, string icon, Dictionary<string, object>? parameters = null)
            where TComponent : ComponentBase
        {
            AddNewTab(id, typeof(TComponent), title, icon, parameters);
        }

        public void AddNewTab(string id, Type type, string title, string icon, Dictionary<string, object>? parameters = null)
        {

            var item = new EntMdiTabInstance()
            {
                ComponentType = type,
                Icon = icon,
                Title = title,
                ComponentParameters = parameters,
                Id = id,
                OnClose = CloseTab
            };
            OnTabAdded.Invoke(item);
        }

        public void CloseTab(string id)
        {
            OnTabClosed.Invoke(id);
        }

        public void SetActiveTab(string id)
        {

            OnTabActivated.Invoke(id);
        }
        
    }
}