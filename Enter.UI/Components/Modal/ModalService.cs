using Microsoft.AspNetCore.Components;

namespace Enter.UI.Components;

public class ModalService : IModalService
{
    
    public List<EntModalInstance> Items = new List<EntModalInstance>();
    
    public event Action<string> OnModalShowed;
    public event Action<string> OnModalClosed;
    public event Action<string> OnModalCanceled;
    
    public Task<ModalResult?> ShowAsync<TComponent>(string title, EntModalOptions? options = null, string? id = null,Dictionary<string, object>? parameters = null) where TComponent : ComponentBase
    {
        var modalId = id ?? Guid.NewGuid().ToString();
        var taskCompletionSource = new TaskCompletionSource<ModalResult?>();
        var item = new EntModalInstance()
        {
            Key = modalId,
            Title = title,
            Type = typeof(TComponent),
            Options = options,
            Parameters = parameters,
            OnClose = CloseAsync,
            OnCancel = CancelAsync,
            DialogResultTCS = taskCompletionSource
        };
        Items.Add(item);
        OnModalShowed.Invoke(item.Key);
        return taskCompletionSource.Task;
    }

    public Task CloseAsync(string id , ModalResult? result = null )
    {
        var item = Items.First(x => x.Key == id);
        Items.Remove(item);
        OnModalClosed.Invoke(id);
        item.DialogResultTCS?.SetResult(result);
        return Task.CompletedTask;
    }

    public Task CnacelAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task CancelAsync(string id )
    {
        var item = Items.First(x => x.Key == id);
        Items.Remove(item);
        OnModalCanceled.Invoke(id);
        item.DialogResultTCS?.SetResult(ModalResult.Cancel());
        return Task.CompletedTask;
    }
}