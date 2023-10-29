namespace Enter.UI.Abstractions.Components.Modal;

public class EntModalInstance
{
    public string Key { get; init; }
    public string Title { get; set; }
    public Type Type { get; set; }
    public EntModalOptions? Options { get; set; }
    public Dictionary<string,object>? Parameters { get; set; }
    public Func<string , ModalResult?, Task> OnClose { get; set; }
    public Func<string , Task> OnCancel { get; set; }
    
    public TaskCompletionSource<ModalResult?>? DialogResultTCS; 

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