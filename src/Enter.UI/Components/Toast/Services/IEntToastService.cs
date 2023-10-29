namespace Enter.UI.Components;

public interface IEntToastService
{
    Task NotifyAsync(string title, string content, EntToastOptions? options = null);
    Task NotifyInfoAsync(string title, string content,string? icon = null , TimeSpan? delaySpan = null);
    Task NotifyDangerAsync(string title, string content,string? icon = null , TimeSpan? delaySpan = null);
    Task NotifySuccessAsync(string title, string content,string? icon = null , TimeSpan? delaySpan = null);
    Task CloseAsync(Guid id);
}