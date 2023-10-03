﻿using Enter.UI.Components.Contracts;
using Enter.UI.Services.Contracts;
using Microsoft.JSInterop;

namespace Enter.UI.Components;

public class EntLayoutJsService : IEntLayoutJsService , IAsyncDisposable
{
    private readonly IEntJsService _entJsService;
    
    private DotNetObjectReference<EntLayout>? _objectReference;

    private readonly Lazy<Task<IJSObjectReference>> _moduleTask;

    public EntLayoutJsService( IEntJsService entJsService)
    {
        _entJsService = entJsService;
        _moduleTask = new Lazy<Task<IJSObjectReference>>(async () =>
        {
            var jsReference = await entJsService.ImportJsFileAsync("components/layout.component.js");
            return await jsReference.InvokeAsync<IJSObjectReference>("getLayoutComponent");
        });
    }

    public async Task InitializeAsync(EntLayout layout, bool isSidebarShow, int breakWidth)
    {
        var module = await _moduleTask.Value;
        _objectReference = DotNetObjectReference.Create(layout);
        await module.InvokeVoidAsync("initialize", _objectReference, isSidebarShow, breakWidth);
    }
    
    public async Task ToggleAsync( bool isSidebarShow)
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("toggleSidebar", isSidebarShow);
    }

    public async ValueTask DisposeAsync()
    {
        if (_moduleTask.IsValueCreated)
        {
            var module = await _moduleTask.Value;
            await module.DisposeAsync();
        }
    }
}