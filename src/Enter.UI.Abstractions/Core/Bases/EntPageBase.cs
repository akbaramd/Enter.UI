using Enter.UI.Abstractions.Components.Modal;
using Enter.UI.Abstractions.Components.Tabs;
using Enter.UI.Abstractions.Services;
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
        public EntMdiTabInstance? MdiTabInstance { get; set; } = null;

        [CascadingParameter]
        public EntModalInstance? ModalInstance { get; set; } = null;

     
        protected override  Task OnInitializedAsync()
        {
            if (MdiTabInstance != null)
            {
                MdiTabInstance.OnActivatedAsync += OnMdiTabActivatedAsync;
                MdiTabInstance.OnCloseAsync += OnMdiTabCloseAsync;
            }

            if (ModalInstance!= null)
            {
                ModalInstance.OnCanceledAsync += OnModalCanceledAsync;
                ModalInstance.OnClosedAsync += OnModalClosedAsync;
            }

            return Task.CompletedTask;
        }

        protected virtual async Task OnMdiTabActivatedAsync(string tabId)
        {
            await InvokeAsync(StateHasChanged);
        }
        protected virtual async Task OnMdiTabCloseAsync(string tabId)
        {
            await InvokeAsync(Dispose);
        }
        protected virtual async Task OnModalCanceledAsync(string modalId)
        {
            await InvokeAsync(Dispose);
        }

        protected virtual async Task OnModalClosedAsync(string modalId , ModalResult modalResult)
        {
            await InvokeAsync(Dispose);
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
        protected async Task ModalCloseAsync<TResult>(TResult? result)
        {
            if (ModalInstance != null)
            {
                await ModalInstance.CloseAsync(ModalResult.Ok(result));
            }
        }
        protected async Task ModalCloseAsync()
        {
            if (ModalInstance != null)
            {
                await ModalInstance.CloseAsync(ModalResult.Ok());
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
        
        public virtual void  Dispose()
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
            ;
        }

       
    }
}