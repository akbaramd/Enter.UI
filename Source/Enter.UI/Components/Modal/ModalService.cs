using Enter.UI.Components.Modal;
using Enter.UI.Services;
using Microsoft.AspNetCore.Components;

namespace Enter.UI.Components;

public class ModalService : IEntModalService
{
    public ModalReference Show<TComponent>(string title, EntModalParameters? parameters = null,
        EntModalOptions? options = null, string? id = null) where TComponent : ComponentBase
    {
        return Show(typeof(TComponent), title, parameters, options, id);
    }

    public ModalReference Show(Type componentType, string title, EntModalParameters? parameters = null,
        EntModalOptions? options = null,
        string? id = null)
    {
        if (!typeof(IComponent).IsAssignableFrom(componentType))
            throw new ArgumentException($"{componentType.FullName} must be a Blazor Component");

        if (string.IsNullOrWhiteSpace(id))
        {
            id = Guid.NewGuid().ToString();
        }
        
        ModalReference? modalReference = null;
        
        var modalContent = new RenderFragment(builder =>
        {
            var i = 0;
            builder.OpenComponent(i++, componentType);
            foreach (var (name, value) in parameters.Parameters) builder.AddAttribute(i++, name, value);
            builder.CloseComponent();
        });
        var modalInstance = new RenderFragment(builder =>
        {
            builder.OpenComponent<EntModal>(0);
            builder.SetKey("blazoredModalInstance_" + id);
            builder.AddAttribute(1, "Options", options);
            builder.AddAttribute(2, "Title", title);
            builder.AddAttribute(3, "ChildContent", modalContent);
            builder.AddAttribute(4, "Id", id);
            builder.AddComponentReferenceCapture(5, compRef => modalReference!.EntModalRef = (EntModal)compRef);
            builder.CloseComponent();
        });
        modalReference = new ModalReference(id, modalInstance, this);

        OnModalInstanceAdded?.Invoke(modalReference);

        return modalReference;
    }

    public ModalReference MessageBox(string title, string message, string confirmText = "Confirm",
        string cancelText = "Cancel")
    {
        var modalParameter = new EntModalParameters<EntMessageBox>()
            .Add(x => x.Message, message)
            .Add(x => x.CancelText, cancelText)
            .Add(x => x.ConfirmText, confirmText);

        return Show<EntMessageBox>(title, modalParameter, new EntModalOptions
        {
            Size = EntModalSize.Small,
            ShowCloseButton = false,
            Closeable = false
        })!;
    }

    internal void Close(ModalReference modal)
    {
        Close(modal, ModalResult.Ok());
    }

    internal void Close(ModalReference modal, ModalResult result)
    {
        OnModalCloseRequested?.Invoke(modal, result);
    }

    internal event Func<ModalReference, Task>? OnModalInstanceAdded;
    internal event Func<ModalReference, ModalResult, Task>? OnModalCloseRequested;
}