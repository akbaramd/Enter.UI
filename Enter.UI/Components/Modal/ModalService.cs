using Microsoft.AspNetCore.Components;

namespace Enter.UI.Components;

public class ModalService : IModalService
{
    
    public List<EntModalInstance> Items = new List<EntModalInstance>();
    
    public event Action<string> OnModalShowed;
    public event Action<string> OnModalClosed;
    
    public Task<dynamic?> ShowAsync<TComponent>(string title, EntModalOptions? options = null, string? id = null) where TComponent : ComponentBase
    {
        var modalId = id ?? Guid.NewGuid().ToString();
        var taskCompletionSource = new TaskCompletionSource<dynamic?>();
        var item = new EntModalInstance()
        {
            Key = modalId,
            Title = title,
            Type = typeof(TComponent),
            Parameters = options?.Parameters ?? new Dictionary<string, object>(),
            OnClose = CloseAsync,
            DialogResultTCS = taskCompletionSource
        };
        Items.Add(item);
        OnModalShowed.Invoke(item.Key);
        return taskCompletionSource.Task;
    }

    public Task CloseAsync(string id)
    {
        var item = Items.First(x => x.Key == id);
        Items.Remove(item);
        OnModalClosed.Invoke(id);
        item.DialogResultTCS?.SetResult(item);
        return Task.CompletedTask;
    }
}