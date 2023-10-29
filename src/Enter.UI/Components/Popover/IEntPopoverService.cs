using Microsoft.AspNetCore.Components;

namespace Enter.UI.Components;

public interface IEntPopoverService
{

    Task ConnectAsync(Guid id);

    Task<Guid> RegisterAsync(RenderFragment renderFragment,string popoverClass,bool showContent = false);
    Task UpdateParameterAsync(Guid id,string popoverCss,bool showContent);
    event EventHandler? FragmentsChanged;
    Task CloseAllAsync();
}