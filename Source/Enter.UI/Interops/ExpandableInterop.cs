using Enter.UI.Abstractions.JsServices;
using Enter.UI.JsService;
using Microsoft.JSInterop;

namespace Enter.UI.Interops;

internal class ExpandableInterop
{
    

    private readonly Lazy<Task<IJSObjectReference>> _moduleTask;

    public ExpandableInterop(IEntJsService entJsService)
    {
        _moduleTask = new Lazy<Task<IJSObjectReference>>(() => entJsService.LoadReferenceAsync("getExpandableComponent"));
    }

    
    public async Task InitializeAsync(string id , bool show)
    {
        var module = await _moduleTask.Value;
        var objectReference = DotNetObjectReference.Create(this);
        await module.InvokeVoidAsync("initialize", objectReference, id , show);
    }

    public async Task ToogleAsync(string id, bool show)
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("toggle", id, show);
    }

}