using Enter.UI.Components.Tabs;
using Enter.UI.Services;
using Microsoft.AspNetCore.Components;

namespace Enter.UI.Components;

internal class EntMdiService : IEntMdiService
{
    public async Task AddNewTabAsync<TComponent>(string id, string title, object icon,
        Dictionary<string, object>? parameters = null)
        where TComponent : ComponentBase
    {
      await  AddNewTabAsync(id, typeof(TComponent), title, icon, parameters);
    }

    public async Task AddNewTabAsync(string id, Type type, string title, object icon,
        Dictionary<string, object>? parameters = null)
    {
        id = string.IsNullOrWhiteSpace(id) ? Guid.NewGuid().ToString() : id;

        var item = new EntMdiTabInstance
        {
            Id = id,
            Title = title,
            Icon = icon,
            ComponentType = type,
            ComponentParameters = parameters,
            OnCloseAsync = CloseTabAsync,
        };
        await OnTabAddedAsync.Invoke(item);
    }

    public async Task CloseTabAsync(string id)
    {
       await OnTabClosedAsync.Invoke(id);
    }

    public async Task ActivateTabAsync(string id)
    {
       await OnTabActivatedAsync.Invoke(id);
    }

    internal event Func<EntMdiTabInstance, Task> OnTabAddedAsync = default!;
    internal event Func<string,Task> OnTabActivatedAsync = default!;
    internal event Func<string,Task> OnTabClosedAsync = default!;
}