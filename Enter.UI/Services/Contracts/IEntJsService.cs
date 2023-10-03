using Enter.UI.Models;
using Microsoft.JSInterop;

namespace Enter.UI.Services.Contracts;

public interface IEntJsService
{
   
    
    // Task<EntJsElement> GetElementByIdAsync( string id);
    // Task<EntJsElement> GetElementByQuerySelectorAsync( string selector);
    Task<IJSObjectReference> ImportJsFileAsync ( string path);
}