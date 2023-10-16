using Enter.UI.Components;
using Microsoft.JSInterop;

namespace Enter.UI.JsService.Contracts;

public interface IEntLayoutJsService
{
    Task InitializeAsync(EntLayout layout, bool isSidebarShow, int breakWidth);
    Task ToggleAsync(bool isSidebarShow);
}