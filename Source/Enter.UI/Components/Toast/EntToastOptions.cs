using Enter.UI.Components.Icon;

namespace Enter.UI.Components.Toast;

public class EntToastOptions
{
    public TimeSpan DelaySpan { get; set; } = TimeSpan.FromSeconds(2);
    public EntToastType Type { get; set; } = EntToastType.Info;
    public object? Icon { get; set; } = null;
}