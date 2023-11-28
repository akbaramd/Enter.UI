using Enter.Ui.Components.Tabs;
using Microsoft.AspNetCore.Components;

namespace Enter.Ui.Cores.Contracts;

public interface IEntMdiService
{
    public Task AddNewTabAsync<TComponent>(string id, string title, object icon,
        Dictionary<string, object>? parameters = null) where TComponent : ComponentBase;

    public Task AddNewTabAsync(EntMdiTabInstance instance);

    public Task AddNewTabAsync(string id, Type type, string title, object icon,
        Dictionary<string, object>? parameters = null);

    public Task CloseTabAsync(string id);
    public Task ActivateTabAsync(string id);



    public event Func<EntMdiTabInstance, Task> OnTabAddedAsync;
    public event Func<EntMdiTabInstance, Task> OnTabActivatedAsync;
    public event Func<EntMdiTabInstance, Task> OnTabClosedAsync;
}