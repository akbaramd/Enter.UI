using Enter.UI.Models;
using Enter.UI.Services.Contracts;
using Microsoft.JSInterop;

namespace Enter.UI.Services;

public class EntJsService : IEntJsService
{

    private readonly IJSRuntime _jsRuntime;

    public EntJsService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task<EntJsElement> GetElementByIdAsync(string id)
    {
        return await _jsRuntime.InvokeAsync<EntJsElement>("EnterUi.Shared.GetElementById",id); 
    }

    public async Task<EntJsElement> GetElementByQuerySelectorAsync(string selector)
    {
        return await _jsRuntime.InvokeAsync<EntJsElement>("EnterUi.Shared.GetElementByQuerySelector",selector); 
    }
}