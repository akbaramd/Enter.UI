namespace Enter.UI.Abstractions.Core.Extensions;

public static class SelectExtensions
{
    public static IEnumerable<EntSelectItem<TValue>> ProjectToSelectItem<TType,TValue>(this IEnumerable<TType> sources,
        Func<TType,string> textFunc,
        Func<TType,TValue> valueFunc,
        Func<TType,IEnumerable<TType>?> childrenFunc,
        object? defaultIcon = null)
    {
        return sources.Select(x => new EntSelectItem<TValue>
        {
            Text = textFunc.Invoke(x),
            Value = valueFunc.Invoke(x),
            Icon = defaultIcon,
            Childrens = childrenFunc.Invoke(x)?.ProjectToSelectItem(textFunc,valueFunc,childrenFunc,defaultIcon)??new List<EntSelectItem<TValue>>()
        });
    }
}