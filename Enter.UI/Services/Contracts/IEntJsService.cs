using Enter.UI.Models;

namespace Enter.UI.Services.Contracts;

public interface IEntJsService
{
   
    
    Task<EntJsElement> GetElementByIdAsync( string id);
    Task<EntJsElement> GetElementByQuerySelectorAsync( string selector);
}