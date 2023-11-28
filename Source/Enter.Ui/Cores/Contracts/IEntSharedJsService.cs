using Enter.Ui.Cores.Enums;
using Enter.Ui.Cores.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Enter.Ui.Cores.Contracts;

public interface IEntSharedJsService
{
    Task<BoundingClientRect> GetBoundingClientRectAsync(ElementReference reference);
    Task<EntBreakpoint> GetBreakpointAsync();
    Task InitializeBreakpointEventAsync<T>(DotNetObjectReference<T> reference) where T : class;
    Task SetAttributeByQuerySelectorAsync(string selector, string key, string value);
}