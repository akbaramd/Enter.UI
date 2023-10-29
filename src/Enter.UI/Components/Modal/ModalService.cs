using Enter.UI.Abstractions.Components.Modal;
using Enter.UI.Abstractions.Services;
using Enter.UI.Core;
using Microsoft.AspNetCore.Components;

namespace Enter.UI.Components;

public class ModalService : IModalService
{
    public List<EntModalInstance> Items = new();

    public Task<ModalResult?> ShowAsync<TComponent>(string title, Dictionary<string, object>? parameters = null,
        EntModalOptions? options = null, string? id = null) where TComponent : ComponentBase
    {
        var modalId = id ?? Guid.NewGuid().ToString();
        var taskCompletionSource = new TaskCompletionSource<ModalResult?>();
        var item = new EntModalInstance
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

    public Task CloseAsync(string id, ModalResult? result = null)
    {
        var item = Items.First(x => x.Key == id);
        Items.Remove(item);
        OnModalClosed.Invoke(id);
        item.DialogResultTCS?.SetResult(result);
        return Task.CompletedTask;
    }

    public Task CancelAsync(string id)
    {
        var item = Items.First(x => x.Key == id);
        Items.Remove(item);
        OnModalCanceled.Invoke(id);
        item.DialogResultTCS?.SetResult(ModalResult.Cancel());
        return Task.CompletedTask;
    }

    public Task<ModalResult> MessageBoxAsync(string title, string message, string confirmText = "Confirm", string cancelText = "Cancel")
    {
        var parametersBuilder = new ParameterBuilder<EntMessageBox>()
                .AddParameter(x => x.Message, message)
                .AddParameter(x => x.CancelText, cancelText)
                .AddParameter(x => x.ConfirmText, confirmText);
        
        var parameters = parametersBuilder.Build();
        
        return ShowAsync<EntMessageBox>(title, parameters, new EntModalOptions()
        {
            Size = EntModalSize.Small,
            ShowCloseButton = false,
            CloseOnEscapeKey = false
        })!;
    }

    public event Action<string> OnModalShowed;
    public event Action<string> OnModalClosed;
    public event Action<string> OnModalCanceled;
}