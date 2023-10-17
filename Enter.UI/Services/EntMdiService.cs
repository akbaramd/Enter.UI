﻿using Enter.UI.Components;
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
    internal class EntMdiService : IEntMdiService
    {
        public List<EntMdiTabInstance> TabPanels { get; set; } = new List<EntMdiTabInstance>();
        public EntMdiTabInstance? ActiveTabPanel { get; set; }


        public event Action<EntMdiTabInstance> OnTabAdded;
        public event Action<EntMdiTabInstance?> OnTabActivated;
        public event Action OnTabRemoved;

        public void AddNewTab<TComponent>(string id , string title,string icon,Dictionary<string, object>? parameters = null)
            where TComponent : ComponentBase
        {
            AddNewTab(id,typeof(TComponent), title, icon, parameters);
        }

        public void AddNewTab(string id , Type type, string title, string icon, Dictionary<string, object>? parameters = null)
        {

            if (TabPanels.Any(x=>x.Id == id))
            {
                SetActiveTab(id,true);
                return;
            }
            
            var item = new EntMdiTabInstance()
            {
                ComponentType = type, 
                Icon = icon, 
                Title = title, 
                ComponentParameters = parameters, 
                Id = id
            };
            TabPanels.Add(item);
            OnTabAdded.Invoke(item);
        }

        public void RemoveTab(string id)
        {
            TabPanels.Remove(TabPanels.First(x => x.Id == id));
            OnTabRemoved.Invoke();
        }

        public void SetActiveTab(string id,bool notify = true)
        {
            
            ActiveTabPanel = TabPanels.FirstOrDefault(x => x.Id == id);

            if (notify)
            {
                OnTabActivated.Invoke(ActiveTabPanel);
            }
        }
    }
}