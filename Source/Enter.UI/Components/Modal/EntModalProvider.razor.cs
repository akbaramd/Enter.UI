using Enter.UI.Cores.Bases;
using Enter.UI.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace Enter.UI.Components.Modal;

public partial class EntModalProvider : EntComponentBase
{
    [Inject] private IEntModalService ModalService { get; set; } = default!;
    [Inject] private NavigationManager  NavigationManager { get; set; } = default!;

    private ModalService _modalService { get; set; }

    public List<ModalReference> ModalInstances = new();

    protected override async Task OnInitializedAsync()
    {
        _modalService = (ModalService)ModalService ?? throw new InvalidOperationException("AddEnterUI is not added to your program.cs");
        
        _modalService.OnModalInstanceAdded += OnInstanceAdded;
        _modalService.OnModalCloseRequested += CloseInstance;
        NavigationManager.LocationChanged += CancelModals;
        await base.OnInitializedAsync();
    }

    internal event Action? OnModalClosed;

    public async Task OnInstanceAdded(ModalReference reference)
    {
        ModalInstances.Add(reference);
        //
        // if (!_haveActiveModals)
        // {
        //     _haveActiveModals = true;
        //     if (_styleFunctions is not null)
        //     {
        //         await _styleFunctions.InvokeVoidAsync("setBodyStyle");
        //     }
        // }
        
        await InvokeAsync(StateHasChanged);
    }

    internal async Task CloseInstance(ModalReference? modal, ModalResult result)
    {
        if (modal?.EntModalRef != null)
        {
            // Gracefully close the modal
            await modal.EntModalRef.CloseAsync(result);
            if (!ModalInstances.Any())
            {
                // todo: Check this
                //await ClearBodyStyles();
            }
            OnModalClosed?.Invoke();
        }
        else
        {
            await DismissInstance(modal, result);
        }
    }

    internal Task DismissInstance(string id, ModalResult result)
    {
        var reference = GetModalReference(id);
        return DismissInstance(reference, result);
    }

    internal async Task DismissInstance(ModalReference? modal, ModalResult result)
    {
        if (modal != null)
        {
            modal.Dismiss(result);
            ModalInstances.Remove(modal);
            if (!ModalInstances.Any())
            {
                // todo: check this
                //await ClearBodyStyles();
            }
            await InvokeAsync(StateHasChanged);
            OnModalClosed?.Invoke();
        }
    }

    private async void CancelModals(object? sender, LocationChangedEventArgs e)
    {
        foreach (var modalReference in ModalInstances.ToList())
        {
            modalReference.Dismiss(ModalResult.Cancel());
        }

        ModalInstances.Clear();
        //await ClearBodyStyles();
        await InvokeAsync(StateHasChanged);
    }
    private ModalReference? GetModalReference(string id)
        => ModalInstances.SingleOrDefault(x => x.Id == id);
    public override void Dispose()
    {
        _modalService.OnModalInstanceAdded -= OnInstanceAdded;
    }

}