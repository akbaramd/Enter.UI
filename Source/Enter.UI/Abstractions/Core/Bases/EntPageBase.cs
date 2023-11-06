﻿using Enter.UI.Abstractions.Components.Modal;
using Enter.UI.Abstractions.Components.Tabs;
using Enter.UI.Abstractions.Services;
using Enter.UI.Components;
using Microsoft.AspNetCore.Components;

namespace Enter.UI.Abstractions.Core.Bases
{
    public abstract class EntPageBase : ComponentBase, IDisposable
    {

        [Inject]
        public IEntModalService ModalService { get; set; } = default!;

        [Inject]
        public IEntToastService ToastService { get; set; } = default!;

        [Inject]
        public IEntMdiService MdiTabService { get; set; } = default!;

        [CascadingParameter]
        public EntMdiTabInstance? MdiTabInstance { get; set; } = default!;

        [CascadingParameter]
        public EntModal? EntModal { get; set; } = null;

        public bool IsMdiTabInstance => MdiTabInstance != null;
        
        protected override  Task OnInitializedAsync()
        {
            if (IsMdiTabInstance)
            {
                MdiTabInstance.OnActivatedAsync += OnMdiTabActivatedAsync;
            }
            return Task.CompletedTask;
        }

        protected virtual async Task OnMdiTabActivatedAsync(string tabId)
        {
            await InvokeAsync(StateHasChanged);
        }

        public virtual void Dispose()
        {
        }
        
    }
}