using Enter.UI.Abstractions.Components.Modal;
using Enter.UI.Abstractions.Components.Tabs;
using Enter.UI.Abstractions.Services;
using Enter.UI.Components;
using Microsoft.AspNetCore.Components;

namespace Enter.UI.Abstractions.Core.Bases
{
    public abstract class EntPageBase : ComponentBase, IAsyncDisposable
    {

        [Inject]
        public IEntModalService ModalService { get; set; } = default!;

        [Inject]
        public IEntToastService ToastService { get; set; } = default!;

        [Inject]
        public IEntMdiService MdiTabService { get; set; } = default!;

        [CascadingParameter]
        public EntMdiTabInstance? MdiTabInstance { get; set; } = null;

        [CascadingParameter]
        public EntModalInstance? ModalInstance { get; set; } = null;

     
        protected override  Task OnInitializedAsync()
        {
            if (MdiTabInstance != null)
            {
                MdiTabInstance.OnActivatedAsync += OnMdiTabActivatedAsync;
            }

            if (ModalInstance!= null)
            {
                ModalInstance.OnCanceledAsync += OnModalCanceledAsync;
                ModalInstance.OnClosedAsync += OnModalClosedAsync;
            }

            return Task.CompletedTask;
        }

        protected virtual Task OnMdiTabActivatedAsync(string tabId)
        {
            return Task.CompletedTask;
        }

        protected virtual Task OnModalCanceledAsync(string modalId)
        {
            return Task.CompletedTask;
        }

        protected virtual Task OnModalClosedAsync(string modalId , ModalResult modalResult)
        {
            return Task.CompletedTask;
        }

        protected async Task MdiTabCloseAsync()
        {
            if (MdiTabInstance != null)
            {
                await MdiTabInstance.CloseAsync();;
            }
        }

        protected async Task ModalCancelAsync()
        {
            if (ModalInstance != null)
            {
                await ModalInstance.CancelAsync(); 
            }
        }
        protected async Task ModalCloseAsync<TResult>(TResult? result = default)
        {
            if (ModalInstance != null)
            {
                await ModalInstance.CloseAsync(ModalResult.Ok(result));
            }
        }

        protected bool IsModalInstance()
        {
            return ModalInstance != null;
        }
        protected bool IsMdiTabInstance()
        {
            return MdiTabInstance != null;
        }
        
        public  ValueTask DisposeAsync()
        {
            if (MdiTabInstance != null)
            {
                MdiTabInstance.OnActivatedAsync -= OnMdiTabActivatedAsync;
            }

            if (ModalInstance != null)
            {
                ModalInstance.OnCanceledAsync -= OnModalCanceledAsync;
                ModalInstance.OnClosedAsync -= OnModalClosedAsync;
            }
            return ValueTask.CompletedTask;
        }

       
    }
}