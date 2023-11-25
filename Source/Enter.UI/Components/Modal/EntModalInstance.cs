namespace Enter.UI.Components.Modal;

public class EntModalInstance
{
    public TaskCompletionSource<ModalResult?>? DialogResultTCS;
    public string Id { get; init; }
    public string Title { get; set; }
    public Type Type { get; set; }
    public EntModalOptions? Options { get; set; }
    public Dictionary<string, object>? Parameters { get; set; }
}