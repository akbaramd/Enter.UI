using Enter.Ui.Abstractions.Models;
using Enter.Ui.Core.Enums;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Enter.Ui.JsServices;

public interface IEntSharedJsService
{
    Task<BoundingClientRect> GetBoundingClientRectAsync(ElementReference reference);
    Task<EntBreakpoint> GetBreakpointAsync();
    Task InitializeBreakpointEventAsync<T>(DotNetObjectReference<T> reference) where T : class;
    Task SetAttributeByQuerySelectorAsync(string selector, string key, string value);
}