namespace Enter.UI.Components.Modal;

public class EntModalOptions
{
    public bool ShowCloseButton { get; set; } = true;
    public bool Closeable { get; set; } = true;
    public string? Class { get; set; } 
    public EntModalSize Size { get; set; } = EntModalSize.Medium;
}