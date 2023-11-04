using Enter.UI.Abstractions.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Enter.UI.Abstractions.JsServices
{
    public interface IEntSharedJsService
    {
        Task<BoundingClientRect> GetBoundingClientRect(ElementReference reference);
        
        Task InitializeBreakpointEvent<T>(DotNetObjectReference<T> reference) where T : class;

        Task SetAttributeByQuerySelectorAsync(string selector, string key, string value);
    }
}
