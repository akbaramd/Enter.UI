namespace Enter.Ui.Cores.Extensions;

internal static class DictionaryExtensions
{
    internal static void Set<TKey, TValue>(this Dictionary<TKey, TValue> dic, TKey key, TValue value)
        where TKey : notnull
    {
        if (dic.ContainsKey(key))
            dic[key] = value;
        else
            dic.Add(key, value);
    }

    internal static Dictionary<string, object> RemoveAttribute(this Dictionary<string, object> dic, string attribute)
    {
        if (dic.ContainsKey(attribute))
            dic.Remove(attribute);

        return dic;
    }
}