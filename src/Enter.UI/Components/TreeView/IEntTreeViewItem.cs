namespace Enter.UI.Components;

public interface IEntTreeViewItem<TType,TValue> where TType:IEntTreeViewItem<TType,TValue>
{
    public TValue Value  { get; set; }
    public string Text  { get; set; }
    public string? Icon  { get; set; }
    
    public IEnumerable<TType>? Childrens { get; set; }
}