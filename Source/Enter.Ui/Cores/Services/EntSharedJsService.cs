using Enter.Ui.Cores.Contracts;
using Enter.Ui.Cores.Enums;
using Enter.Ui.Cores.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Enter.Ui.Cores.Services;

internal class EntSharedJsService : IEntSharedJsService, IAsyncDisposable
{
    private readonly IEntJsService _entJsService;
    private readonly Lazy<Task<IJSObjectReference>> _moduleTask;

    public EntSharedJsService(IEntJsService entJsService)
    {
        _entJsService = entJsService;
        _moduleTask = new Lazy<Task<IJSObjectReference>>(() => entJsService.LoadReferenceAsync("getShared"));
    }

    public async ValueTask DisposeAsync()
    {
        var module = await _moduleTask.Value;
        await module.DisposeAsync();
    }

    public async Task<BoundingClientRect> GetBoundingClientRectAsync(ElementReference reference)
    {
        var sharedModule = await _moduleTask.Value;
        return await sharedModule.InvokeAsync<BoundingClientRect>("getBoundingClientRect", reference);
    }

    public async Task<EntBreakpoint> GetBreakpointAsync()
    {
        var sharedModule = await _moduleTask.Value;
        var breakPoint = await sharedModule.InvokeAsync<string>("getBreakpoint");
        return Enum.Parse<EntBreakpoint>(breakPoint);
    }

    public async Task InitializeBreakpointEventAsync<T>(DotNetObjectReference<T> reference) where T : class
    {
        var sharedModule = await _moduleTask.Value;
        await sharedModule.InvokeVoidAsync("initializeBreakpointEvent", reference);
    }

    public async Task SetAttributeByQuerySelectorAsync(string selector, string key, string value)
    {
        var sharedModule = await _moduleTask.Value;
        await sharedModule.InvokeVoidAsync("setAttributeByQuerySelector", selector, key, value);
    }
}