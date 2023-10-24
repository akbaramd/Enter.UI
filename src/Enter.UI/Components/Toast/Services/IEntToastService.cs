using Microsoft.AspNetCore.Components;

namespace Enter.UI.Components;

public interface IEntToastService
{
    Task NotifyAsync(string title, string content, EntToastOptions? options = null);
    Task CloseAsync(Guid id);
}