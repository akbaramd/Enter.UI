using Enter.UI.Abstractions.JsServices;
using Enter.UI.JsService;
using Microsoft.JSInterop;

namespace Enter.UI.Interops;

internal class PopoverInterop
{
    

    private readonly Lazy<Task<IJSObjectReference>> _moduleTask;

    public PopoverInterop(IEntJsService entJsService)
    {
        _moduleTask = new Lazy<Task<IJSObjectReference>>(() => entJsService.LoadReferenceAsync("getPopoverComponent"));
    }

    
    public async Task InitializeAsync(Guid id)
    {
        var module = await _moduleTask.Value;
        var objectReference = DotNetObjectReference.Create(this);
        await module.InvokeVoidAsync("initialize", objectReference, id);
    }

    public async Task<bool> ConnectAsync(Guid id) 
    {
        try
        {
            var module = await _moduleTask.Value;
            await module.InvokeVoidAsync("connect", id);
            return true;
        }
        catch (Exception exception)
        {
            return false;
        }
    }
}