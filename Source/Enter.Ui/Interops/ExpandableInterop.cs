﻿using Enter.Ui.Cores.Services;
using Microsoft.JSInterop;

namespace Enter.Ui.Interops;

internal class ExpandableInterop
{
    private readonly Lazy<Task<IJSObjectReference>> _moduleTask;

    public ExpandableInterop(IEntJsService entJsService)
    {
        _moduleTask =
            new Lazy<Task<IJSObjectReference>>(() => entJsService.LoadReferenceAsync("getExpandableComponent"));
    }


    public async Task InitializeAsync(string id, bool show)
    {
        var module = await _moduleTask.Value;
        var objectReference = DotNetObjectReference.Create(this);
        await module.InvokeVoidAsync("initialize", objectReference, id, show);
    }

    public async Task ToggleAsync(string id, bool show)
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("toggle", id, show);
    }
}