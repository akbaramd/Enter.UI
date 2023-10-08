using Enter.UI.Models;
using Enter.UI.Services.Contracts;
using Microsoft.AspNetCore.Components;

namespace Enter.UI.Services;

public class PopoverService : IPopoverService
{
    public Dictionary<Guid, EntPopoverInstance> PopoverInstances { get; set; } =
        new Dictionary<Guid, EntPopoverInstance>();
    
    public event EventHandler? FragmentsChanged;
    
    public async Task<Guid> RegisterAsync(RenderFragment renderFragment,bool showContent = false)
    {
        var instance = new EntPopoverInstance()
        {
            Key = Guid.NewGuid(),
            ContentFragment = renderFragment,
            ShowContent = showContent
        };

        PopoverInstances.TryAdd(instance.Key, instance);
        
        FragmentsChanged?.Invoke(this,EventArgs.Empty);

        return instance.Key;
    }

    public async  Task OpenAsync(Guid id, bool open)
    {
        var item = PopoverInstances[id];

        item.ShowContent = open;
        
        FragmentsChanged?.Invoke(this,EventArgs.Empty);
    }
}