using Microsoft.AspNetCore.Components;

namespace Enter.UI.Services.Contracts;

public interface IPopoverService
{
    Task<Guid> RegisterAsync(RenderFragment renderFragment,bool showContent = false);

    Task OpenAsync(Guid id, bool open);
    event EventHandler? FragmentsChanged;
}