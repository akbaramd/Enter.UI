using Enter.Ui.Components.Tabs;
using Enter.Ui.Services;
using Microsoft.AspNetCore.Components;

// ReSharper disable once CheckNamespace
namespace Enter.Ui.Components;

internal class EntMdiService : IEntMdiService
{
    private readonly List<EntMdiTabInstance> Instances = new();

    public async Task AddNewTabAsync<TComponent>(string id, string title, object icon,
        Dictionary<string, object>? parameters = null)
        where TComponent : ComponentBase
    {
        await AddNewTabAsync(id, typeof(TComponent), title, icon, parameters);
    }

    public async Task AddNewTabAsync(EntMdiTabInstance instance)
    {
        Instances.Add(instance);
        await OnTabAddedAsync.Invoke(instance);
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
            IsActive = true
        };
        await AddNewTabAsync(item);
    }

    public async Task CloseTabAsync(string id)
    {
        var instance = Instances.First(x => x.Id == id);
        await OnTabClosedAsync.Invoke(instance);
      
    }

    public async Task ActivateTabAsync(string id)
    {
        var instance = Instances.First(x => x.Id == id);
        await OnTabActivatedAsync.Invoke(instance);
    }

    public List<EntMdiTabInstance> GetInstance()
    {
        return Instances;
    }
 
    


    public event Func<EntMdiTabInstance, Task> OnTabAddedAsync = default!;
    public event Func<EntMdiTabInstance, Task> OnTabActivatedAsync = default!;
    public event Func<EntMdiTabInstance, Task> OnTabClosedAsync = default!;
}