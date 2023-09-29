using Microsoft.AspNetCore.Components;

namespace Enter.UI.Components;

public interface IModalService
{
    Task<ModalResult?> ShowAsync<TComponent>(string title, EntModalOptions? options = null, string? id = null,Dictionary<string, object>? parameters = null) where TComponent : ComponentBase;

    Task CloseAsync(string id , ModalResult? result = null);
    Task CancelAsync(string id);

}