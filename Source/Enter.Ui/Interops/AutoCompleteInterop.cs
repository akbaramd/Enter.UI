using Enter.Ui.Components;
using Enter.Ui.Cores.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Enter.Ui.Interops;

internal class AutoCompleteInterop
{
    private readonly Lazy<Task<IJSObjectReference>> _moduleTask;

    public AutoCompleteInterop(IEntJsService entJsService)
    {
        _moduleTask = new Lazy<Task<IJSObjectReference>>(() => entJsService.LoadReferenceAsync("getAutoCompleteComponent"));
    }


    public async Task InitializeAsync(EntInputAutoCompleteV2 component, ElementReference inputElement)
    {
        var module = await _moduleTask.Value;
        var objectReference = DotNetObjectReference.Create(component);
        await module.InvokeVoidAsync("initialize", objectReference, inputElement);
    }

   
}