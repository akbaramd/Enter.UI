using Microsoft.JSInterop;

namespace Enter.UI.Components.Contracts;

public interface IEntLayoutJsService
{
    Task InitializeAsync(EntLayout layout, bool isSidebarShow, int breakWidth);
    Task ToggleAsync(bool isSidebarShow);
}