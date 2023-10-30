using Enter.UI.Abstractions.Components.Toast;
using Enter.UI.Abstractions.Services;

namespace Enter.UI.Components;

public class EntToastService : IEntToastService
{
    public async Task NotifyAsync(string title, string content, EntToastOptions? options = null)
    {
        var instance = new EntToastInstance(title, content, options);
        await InstanceCreatedAsync?.Invoke(instance);
    }

    public Task NotifyInfoAsync(string title, string content, string? icon = null, TimeSpan? delaySpan = null)
    {
        return NotifyAsync(title, content, new EntToastOptions
        {
            Icon = icon,
            Type = EntToastType.Info,
            DelaySpan = delaySpan ?? TimeSpan.FromSeconds(2)
        });
    }

    public Task NotifyDangerAsync(string title, string content, string? icon = null, TimeSpan? delaySpan = null)
    {
        return NotifyAsync(title, content, new EntToastOptions
        {
            Icon = icon,
            Type = EntToastType.Danger,
            DelaySpan = delaySpan ?? TimeSpan.FromSeconds(2)
        });
    }

    public Task NotifySuccessAsync(string title, string content, string? icon = null, TimeSpan? delaySpan = null)
    {
        return NotifyAsync(title, content, new EntToastOptions
        {
            Icon = icon,
            Type = EntToastType.Success,
            DelaySpan = delaySpan ?? TimeSpan.FromSeconds(2)
        });
    }

    public async Task CloseAsync(Guid id)
    {
        await InstanceCloseAsync?.Invoke(id);
    }

    public event Func<EntToastInstance, Task>? InstanceCreatedAsync;
    public event Func<Guid, Task>? InstanceCloseAsync;
}