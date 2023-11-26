using Enter.Ui.Components.Modal;
using Microsoft.AspNetCore.Components;
using EntModalOptions = Enter.Ui.Components.Modal.EntModalOptions;

namespace Enter.Ui.Services;

public interface IEntModalService
{
    ModalReference MessageBox(string title, string message, string confirmText = "Confirm",
        string cancelText = "Cancel");

    ModalReference Show<TComponent>(string title, EntModalParameters? parameters = null,
        EntModalOptions? options = null, string? id = null) where TComponent : ComponentBase;

    ModalReference Show(Type componentType, string title, EntModalParameters? parameters = null,
        EntModalOptions? options = null, string? id = null);
}