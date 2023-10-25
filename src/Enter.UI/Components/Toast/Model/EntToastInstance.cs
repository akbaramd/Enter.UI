namespace Enter.UI.Components;

public class EntToastInstance
{
    public EntToastInstance(string title, string content, EntToastOptions? options = null)
    {
        Id = Guid.NewGuid();
        Title = title;
        Content = content;
        Options = options ?? new EntToastOptions();
        AnimatorState = EntAnimatorState.Starting;
    }

    public Guid Id { get; set; }
    public string Title { get; set; } 
    public string Content { get; set; }

    public EntAnimatorState AnimatorState { get; set; }
    
    public EntToastOptions Options { get; set; } 

}