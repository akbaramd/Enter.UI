namespace Enter.UI.Core;

public class EntSelectItem<TValue> 
{
    public TValue Value  { get; set; }
    public string Text  { get; set; }
    public object? Icon  { get; set; }


    public IEnumerable<EntSelectItem<TValue>>? Childrens { get; set; }
}