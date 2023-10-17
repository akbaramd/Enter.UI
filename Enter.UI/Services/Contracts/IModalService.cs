using System.Linq.Expressions;
using Microsoft.AspNetCore.Components;

namespace Enter.UI.Components;

public interface IModalService
{
    Task<ModalResult?> ShowAsync<TComponent>(string title,Dictionary<string, object>? parameters = null, EntModalOptions? options = null, string? id = null) where TComponent : ComponentBase;

    Task CloseAsync(string id , ModalResult? result = null);
    Task CancelAsync(string id);

}