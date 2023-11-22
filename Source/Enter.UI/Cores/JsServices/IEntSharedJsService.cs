using Enter.UI.Abstractions.Models;
using Enter.UI.Core.Enums;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Enter.UI.JsServices
{
    public interface IEntSharedJsService
    {
        Task<BoundingClientRect> GetBoundingClientRectAsync(ElementReference reference);
        Task<EntBreakpoint> GetBreakpointAsync();
        Task InitializeBreakpointEventAsync<T>(DotNetObjectReference<T> reference) where T : class;
        Task SetAttributeByQuerySelectorAsync(string selector, string key, string value);
    }
}
