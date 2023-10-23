using Microsoft.AspNetCore.Components;

namespace Enter.UI.Components;

public interface IEntToastService
{
    Task NotifyAsync(string title , string content , EntToastType type = EntToastType.Info , string icon = "");
    Task CloseAsync(Guid id);
}