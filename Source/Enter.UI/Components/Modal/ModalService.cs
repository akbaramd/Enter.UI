using Enter.UI.Abstractions.Components.Modal;
using Enter.UI.Abstractions.Services;
using Enter.UI.Core;
using Microsoft.AspNetCore.Components;

namespace Enter.UI.Components;

public class ModalService : IEntModalService , IDisposable
{
    public List<EntModalInstance> Items = new();

    public async Task<ModalResult?> ShowAsync<TComponent>(string title, Dictionary<string, object>? parameters = null,
        EntModalOptions? options = null, string? id = null) where TComponent : ComponentBase
    {
        var first = Items.FirstOrDefault(x => x.Id == id);
        if (first != null)
            throw new Exception("Modal with this Id already exists");
        
        var modalId = id ?? Guid.NewGuid().ToString();
        var taskCompletionSource = new TaskCompletionSource<ModalResult?>();
        var item = new EntModalInstance
        {
            Id = modalId,
            Title = title,
            Type = typeof(TComponent),
            Options = options,
            Parameters = parameters,
            OnClosedAsync = CloseAsync,
            OnCanceledAsync = CancelAsync,
            DialogResultTCS = taskCompletionSource
        };
        Items.Add(item);
        await OnModalShowedAsync.Invoke(item.Id);
        return await taskCompletionSource.Task;
    }

    public async Task CloseAsync(string id, ModalResult? result = null)
    {
        var item = Items.FirstOrDefault(x => x.Id == id);
        if (item == null)
            return;
        Items.Remove(item);
        await OnModalClosedAsync.Invoke(id);
        item.DialogResultTCS?.SetResult(result);
    }

    public async Task CancelAsync(string id)
    {
        var item = Items.FirstOrDefault(x => x.Id == id);
        if (item == null)
            return;
        Items.Remove(item);
        await OnModalCanceledAsync.Invoke(id);
        item.DialogResultTCS?.SetResult(ModalResult.Cancel());
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

    public event Func<string, Task> OnModalShowedAsync;
    public event Func<string, Task> OnModalClosedAsync;
    public event Func<string, Task> OnModalCanceledAsync;

    public void Dispose()
    {
    }
}