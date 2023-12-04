using Enter.Ui.Components.Drawer;
using Enter.Ui.Cores.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Enter.Ui.Interops;

public class DrawerInterop
{
    private readonly Lazy<Task<IJSObjectReference>> _moduleTask;

    public DrawerInterop(IEntJsService entJsService)
    {
        _moduleTask = new Lazy<Task<IJSObjectReference>>(() => entJsService.LoadReferenceAsync("getDrawerComponent"));
    }


    public async Task Open(ElementReference reference,EntDrawerDirection drawerDirection)
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("open", reference, drawerDirection.ToString());
    }

    public async Task Close(ElementReference reference,EntDrawerDirection drawerDirection,double width)
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("close", reference, drawerDirection.ToString(),width);
    }
}