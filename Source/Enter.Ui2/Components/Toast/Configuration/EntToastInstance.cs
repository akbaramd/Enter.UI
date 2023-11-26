using Enter.Ui.Components.Toast.Services;
using Microsoft.AspNetCore.Components;

namespace Enter.Ui.Components.Toast.Configuration;

internal class EntToastInstance
{
    public EntToastInstance(RenderFragment message, EntToastLevel level, EntToastOptions entToastOptions)
    {
        Message = message;
        Level = level;
        EntToastOptions = entToastOptions;
    }
    public EntToastInstance(RenderFragment customComponent, EntToastOptions options)
    {
        CustomComponent = customComponent;
        EntToastOptions = options;
    }

    public Guid Id { get; } = Guid.NewGuid();
    public DateTime TimeStamp { get; } = DateTime.Now;
    public RenderFragment? Message { get; set; }
    public EntToastLevel Level { get; }
    public EntToastOptions EntToastOptions { get; }
    public RenderFragment? CustomComponent { get; }
}
