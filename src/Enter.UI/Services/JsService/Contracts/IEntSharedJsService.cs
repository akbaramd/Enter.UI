using Enter.UI.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Enter.UI.JsService
{
    public interface IEntSharedJsService
    {
        Task<BoundingClientRect> GetBoundingClientRect(ElementReference reference);
        
        Task InitializeBreakpointEvent<T>(DotNetObjectReference<T> reference) where T : class;

        Task SetAttributeByQuerySelectorAsync(string selector, string key, string value);
    }
}
