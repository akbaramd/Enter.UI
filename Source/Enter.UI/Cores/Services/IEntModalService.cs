using Enter.UI.Components.Modal;
using Microsoft.AspNetCore.Components;

namespace Enter.UI.Services;

public interface IEntModalService
{
    ModalReference MessageBox(string title, string message, string confirmText = "Confirm",
        string cancelText = "Cancel");

    ModalReference Show<TComponent>(string title, EntModalParameters? parameters = null,
        EntModalOptions? options = null, string? id = null) where TComponent : ComponentBase;

    ModalReference Show(Type componentType, string title, EntModalParameters? parameters = null,
        EntModalOptions? options = null, string? id = null);
}