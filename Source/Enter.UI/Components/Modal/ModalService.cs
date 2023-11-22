using Enter.UI.Components.Modal;
using Enter.UI.Services;
using Enter.UI.Core;
using Microsoft.AspNetCore.Components;

namespace Enter.UI.Components;

public class ModalService : IEntModalService 
{

    public async Task<ModalResult?> ShowAsync<TComponent>(string title, Dictionary<string, object>? parameters = null,
        EntModalOptions? options = null, string? id = null) where TComponent : ComponentBase
    {
        // var first = Items.FirstOrDefault(x => x.Id == id);
        // if (first != null)
        //     throw new Exception("Modal with this Id already exists");
        
        var modalId = id ?? Guid.NewGuid().ToString();
        var taskCompletionSource = new TaskCompletionSource<ModalResult?>();
        var item = new EntModalInstance
        {
            Id = modalId,
            Title = title,
            Type = typeof(TComponent),
            Options = options,
            Parameters = parameters,
            DialogResultTCS = taskCompletionSource
        };
        
        await OnModalAddedAsync.Invoke(item);
        return await taskCompletionSource.Task;
    }

    public Task<ModalResult> MessageBoxAsync(string title, string message, string confirmText = "Confirm",
        string cancelText = "Cancel")
    {
        var parametersBuilder = new ParameterBuilder<EntMessageBox>()
            .AddParameter(x => x.Message, message)
            .AddParameter(x => x.CancelText, cancelText)
            .AddParameter(x => x.ConfirmText, confirmText);

        var parameters = parametersBuilder.Build();

        return ShowAsync<EntMessageBox>(title, parameters, new EntModalOptions
        {
            Size = EntModalSize.Small,
            ShowCloseButton = false,
            CloseOnEscapeKey = false
        })!;
    }

    internal event Func<EntModalInstance, Task> OnModalAddedAsync = default!;

}