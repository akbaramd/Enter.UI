using Enter.UI.Abstractions.Components.Toast;
using Enter.UI.Abstractions.Services;

namespace Enter.UI.Components;

public class EntToastService : IEntToastService
{
    public Task NotifyAsync(string title, string content, EntToastOptions? options = null)
    {
        var instance = new EntToastInstance(title, content, options);

        var delayMilliseconds = (long)instance.Options.DelaySpan.TotalMilliseconds;

        if (delayMilliseconds <= 0) delayMilliseconds = 3000; // Set a default delay of 1 second (1000 milliseconds)

        var timer = new Timer(s => { _ = CloseAsync(instance.Id); }, null, delayMilliseconds, Timeout.Infinite);

        InstanceCreated?.Invoke(EventArgs.Empty, instance);
        return Task.CompletedTask;
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

    public Task CloseAsync(Guid id)
    {
        InstanceClose?.Invoke(EventArgs.Empty, id);
        return Task.CompletedTask;
    }

    public event EventHandler<EntToastInstance>? InstanceCreated;
    public event EventHandler<Guid>? InstanceClose;
}