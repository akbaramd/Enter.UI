namespace Enter.UI.Components;

public class EntToastInstance
{
    public EntToastInstance(EntToastType type, string title, string content, string icon)
    {
        Id = Guid.NewGuid();
        Type = type;
        Title = title;
        Content = content;
        Icon = icon;
    }

    public Guid Id { get; set; }
    
    public EntToastType Type { get; set; } = EntToastType.Info;
    public string Title { get; set; } 
    public string Content { get; set; } 
    public string Icon { get; set; } 

}