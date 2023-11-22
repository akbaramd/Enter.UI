using Enter.UI.Components.Modal;
using Microsoft.AspNetCore.Components;

namespace Enter.UI.Services;

public interface IEntModalService
{
    Task<ModalResult> MessageBoxAsync(string title, string message, string confirmText = "Confirm",
          string cancelText = "Cancel");
    Task<ModalResult?> ShowAsync<TComponent>(string title,Dictionary<string, object>? parameters = null, EntModalOptions? options = null, string? id = null) where TComponent : ComponentBase;


}