using Microsoft.AspNetCore.Components;

namespace Enter.UI.Components;

internal class EntMdiService : IEntMdiService
{
    public void AddNewTab<TComponent>(string id, string title, string icon,
        Dictionary<string, object>? parameters = null)
        where TComponent : ComponentBase
    {
        AddNewTab(id, typeof(TComponent), title, icon, parameters);
    }

    public void AddNewTab(string id, Type type, string title, string icon,
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
            OnClose = CloseTab,
            OnActivate = ActivateTab
        };
        OnTabAdded?.Invoke(item);
    }

    public void CloseTab(string id)
    {
        OnTabClosed?.Invoke(id);
    }

    public void ActivateTab(string id)
    {
        OnTabActivated?.Invoke(id);
    }

    internal event Action<EntMdiTabInstance>? OnTabAdded;
    internal event Action<string>? OnTabActivated;
    internal event Action<string>? OnTabClosed;
}