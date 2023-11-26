using Enter.Ui.Components;
using Enter.Ui.Components.Tabs;
using Enter.Ui.Components.Toast.Services;
using Enter.Ui.Services;
using Microsoft.AspNetCore.Components;

namespace Enter.Ui.Cores.Bases;

public abstract class EntPageBase : ComponentBase, IDisposable
{
    [Inject] public IEntModalService ModalService { get; set; } = default!;

    [Inject] public IEntToastService ToastService { get; set; } = default!;

    [Inject] public IEntMdiService MdiTabService { get; set; } = default!;

    [CascadingParameter] public EntMdiTabInstance? MdiTabInstance { get; set; }

    [CascadingParameter] public EntModal? EntModal { get; set; }

    public bool IsMdiTabInstance => MdiTabInstance != null;

    public virtual void Dispose()
    {
    }

    protected override Task OnInitializedAsync()
    {
        if (IsMdiTabInstance) MdiTabInstance.OnActivatedAsync += OnMdiTabActivatedAsync;
        return Task.CompletedTask;
    }

    protected virtual async Task OnMdiTabActivatedAsync(string tabId)
    {
        await InvokeAsync(StateHasChanged);
    }
}