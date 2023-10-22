namespace Enter.UI.Components;

public class EntModalInstance
{
    public string Key { get; init; }
    public string Title { get; set; }
    public Type Type { get; set; }
    public EntModalOptions? Options { get; set; }
    public Dictionary<string,object>? Parameters { get; set; }
    internal Func<string , ModalResult?, Task> OnClose { get; set; }
    internal Func<string , Task> OnCancel { get; set; }
    
    internal TaskCompletionSource<ModalResult?>? DialogResultTCS; 

    public Task CloseAsync(ModalResult? result = null)
    {
        var task = OnClose.Invoke(Key,result);
        return task;
    }
    
    public Task CancelAsync()
    {
        var task = OnCancel.Invoke(Key);
        return task;
    }
    
    
}