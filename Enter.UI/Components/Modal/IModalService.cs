using Microsoft.AspNetCore.Components;

namespace Enter.UI.Components;

public interface IModalService
{
    Task ShowAsync<TComponent>(string title , EntModalOptions? options = null , string? id = null) where TComponent : ComponentBase;
    
    
}