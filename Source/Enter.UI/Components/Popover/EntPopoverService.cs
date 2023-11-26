using Enter.Ui.Components.Popover;
using Enter.Ui.Interops;
using Enter.Ui.JsServices;
using Enter.Ui.Services;
using Microsoft.AspNetCore.Components;

// ReSharper disable once CheckNamespace
namespace Enter.Ui.Components;

public class EntPopoverService : IEntPopoverService
{
    private readonly PopoverInterop _popoverInterop;


    public EntPopoverService(IEntJsService entJsService)
    {
        _popoverInterop = new PopoverInterop(entJsService);
    }

    public Dictionary<Guid, EntPopoverInstance> PopoverInstances { get; set; } = new();

    public event EventHandler? FragmentsChanged;

    public async Task CloseAllAsync()
    {
        foreach (var popoverInstance in PopoverInstances) popoverInstance.Value.ShowContent = false;
        FragmentsChanged?.Invoke(this, EventArgs.Empty);
    }


    public async Task ConnectAsync(Guid id)
    {
        var res = await _popoverInterop.ConnectAsync(id);
        var item = PopoverInstances[id];
        item.IsConnected = res;
        FragmentsChanged?.Invoke(this, EventArgs.Empty);
    }

    public async Task<Guid> RegisterAsync(RenderFragment renderFragment, string popoverClass, bool showContent = false)
    {
        var instance = new EntPopoverInstance
        {
            Key = Guid.NewGuid(),
            ContentFragment = renderFragment,
            ShowContent = showContent,
            PopoverClass = popoverClass
        };
        PopoverInstances.TryAdd(instance.Key, instance);
        FragmentsChanged?.Invoke(this, EventArgs.Empty);
        return instance.Key;
    }


    public async Task UpdateParameterAsync(Guid id, string popoverCss, bool open)
    {
        var item = PopoverInstances[id];

        item.ShowContent = open;
        item.PopoverClass = popoverCss;

        FragmentsChanged?.Invoke(this, EventArgs.Empty);
    }
}