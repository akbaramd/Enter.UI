namespace Enter.UI.Components;

public class EntModalInstance
{
    public string Key { get; init; }
    public string Title { get; set; }
    public Type Type { get; set; }
    public Dictionary<string,object>? Parameters { get; set; }
    internal Func<string, Task> OnClose { get; set; }
    
    internal TaskCompletionSource<dynamic?>? DialogResultTCS;

    public Task CloseAsync()
    {
        var task = OnClose.Invoke(Key);
        return task;
    }
}