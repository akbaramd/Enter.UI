using Enter.UI.Abstractions.Components.Modal;

namespace Enter.UI.Components;

public class EntModalInstance
{
    public string Id { get; init; }
    public string Title { get; set; }
    public Type Type { get; set; }
    public EntModalOptions? Options { get; set; }
    public Dictionary<string,object>? Parameters { get; set; }
    public Func<string, ModalResult, Task> OnClosedAsync { get; set; } = default!;
    public Func<string , Task> OnCanceledAsync { get; set; } = default!;

    public TaskCompletionSource<ModalResult?>? DialogResultTCS; 

    public Task CloseAsync(ModalResult? result = null)
    {
        var task = OnClosedAsync.Invoke(Id,result);
        return task;
    }
    
    public Task CancelAsync()
    {
        var task = OnCanceledAsync.Invoke(Id);
        return task;
    }
    
    
}