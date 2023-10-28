using Enter.UI.Core;
using Enter.UI.JsService;
using Enter.UI.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Enter.UI.JsService;

public class EntJsService : IEntJsService, IAsyncDisposable
{
    private readonly IJSRuntime _jsRuntime;

    private readonly Lazy<Task<IJSObjectReference>> _moduleTask;

    public EntJsService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
        _moduleTask = new Lazy<Task<IJSObjectReference>>(() => ImportJsFileAsync("EnterUi.min.js"));
    }

    public async Task<IJSObjectReference> ImportJsFileAsync(string path)
    {
        return await _jsRuntime
            .InvokeAsync<IJSObjectReference>("import",
                $"./_content/Enter.UI/{path}").AsTask();
    }

    public async Task<IJSObjectReference> LoadReferenceAsync(string path)
    {
        var module = await _moduleTask.Value;
        return await module.InvokeAsync<IJSObjectReference>(path);
    }

  


    public async ValueTask DisposeAsync()
    {

    }
}