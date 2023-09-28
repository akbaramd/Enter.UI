using Microsoft.AspNetCore.Components;

namespace Enter.UI.Components;

public class ModalService : IModalService
{
    
    public List<EntModalItem> Items = new List<EntModalItem>();
    
    public event Action<string> OnModalShowed;
    
    public Task ShowAsync<TComponent>(string title , EntModalOptions? options = null ,string? id = null) where TComponent : ComponentBase
    {
        var item = new EntModalItem()
        {
            Key = id ?? Guid.NewGuid().ToString(),
            Title = title,
            Type = typeof(TComponent),
            Parameters = options?.Parameters ?? new Dictionary<string, object>()
        };
        Items.Add(item);
        OnModalShowed.Invoke(item.Key);
        return Task.CompletedTask;
    }
}