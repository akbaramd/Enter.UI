using Microsoft.AspNetCore.Components;

namespace Enter.Ui.Components.Modal;

public class ModalReference : IModalReference
{
    private readonly TaskCompletionSource<ModalResult> _resultCompletion = new(TaskCreationOptions.RunContinuationsAsynchronously);
    private readonly Action<ModalResult> _closed;
    private readonly ModalService _modalService;

    internal string Id { get; }
    internal RenderFragment ModalInstance { get; }
    internal EntModal? EntModalRef { get; set; }
    
    public ModalReference(string modalInstanceId, RenderFragment modalInstance, ModalService modalService)
    {
        Id = modalInstanceId;
        ModalInstance = modalInstance;
        _closed = HandleClosed;
        _modalService = modalService;
    }

    public void Close() 
        => _modalService.Close(this);

    public void Close(ModalResult result) 
        => _modalService.Close(this, result);

    public Task<ModalResult> Result => _resultCompletion.Task;

    internal void Dismiss(ModalResult result) 
        => _closed.Invoke(result);
    
    private void HandleClosed(ModalResult obj) 
        => _ = _resultCompletion.TrySetResult(obj);
}