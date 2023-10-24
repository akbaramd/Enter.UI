namespace Enter.UI.Components;

public class EntToastOptions
{
    public TimeSpan DelaySpan { get; set; } = TimeSpan.FromSeconds(5);
    public EntToastType Type { get; set; } = EntToastType.Info;
    public string Icon { get; set; } = "fa-light fa-info";
}