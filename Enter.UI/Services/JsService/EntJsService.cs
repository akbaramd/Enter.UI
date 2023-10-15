﻿using Enter.UI.Core;
using Enter.UI.Models;
using Enter.UI.Services.Contracts;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Enter.UI.Services;

public class EntJsService : IEntJsService, IAsyncDisposable
{
    private readonly IJSRuntime _jsRuntime;

    private readonly Lazy<Task<IJSObjectReference>> _moduleTask;

    public EntJsService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
        _moduleTask = new Lazy<Task<IJSObjectReference>>( () => ImportJsFileAsync("EnterUi.min.js"));
    }

    public async Task<IJSObjectReference> ImportJsFileAsync ( string path)
    {
        return await _jsRuntime
            .InvokeAsync<IJSObjectReference>("import",
                $"./_content/Enter.UI/{path}").AsTask();
    }

    public async Task<IJSObjectReference> LoadReferenceAsync(string path)
    {
       var module =  await _moduleTask.Value;
        return await module.InvokeAsync<IJSObjectReference>(path);
    }

    public async Task<BoundingClientRect> GetBoundingClientRect(ElementReference reference)
    {
        var module =  await _moduleTask.Value;
        var sharedModule = await module.InvokeAsync<IJSObjectReference>("getShared");
        
        return await sharedModule.InvokeAsync<BoundingClientRect>("getBoundingClientRect", reference);
    }

    public async ValueTask DisposeAsync()
    {
        
    }
}