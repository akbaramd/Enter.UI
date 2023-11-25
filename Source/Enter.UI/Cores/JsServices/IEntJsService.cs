using Microsoft.JSInterop;

namespace Enter.UI.JsServices;

public interface IEntJsService
{
    // Task<EntJsElement> GetElementByIdAsync( string id);
    // Task<EntJsElement> GetElementByQuerySelectorAsync( string selector);
    Task<IJSObjectReference> ImportJsFileAsync(string path);
    Task<IJSObjectReference> LoadReferenceAsync(string path);
}