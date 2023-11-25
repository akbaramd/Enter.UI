using System.Collections;
using System.Linq.Expressions;

namespace Enter.UI.Components.Modal;

public class EntModalParameters<TComponent>: EntModalParameters
{
  
    public EntModalParameters<TComponent> Add<TParam>(Expression<Func<TComponent, TParam>> expression, object? value)
    {
        Parameters[((MemberExpression)expression.Body).Member.Name] = value;
        return this;
    }
}

public class EntModalParameters: IEnumerable<KeyValuePair<string, object?>>
{
    internal readonly Dictionary<string, object?> Parameters;

    protected EntModalParameters()
    {
        Parameters = new Dictionary<string, object?>();
    }

    public EntModalParameters Add(string name, object? value)
    {
        Parameters[name] = value;
        return this;
    }

    public T Get<T>(string parameterName)
    {
        if (!Parameters.TryGetValue(parameterName, out var value))
        {
            throw new KeyNotFoundException($"{parameterName} does not exist in modal parameters");
        }

        if (value is not T typedValue)
        {
            throw new InvalidOperationException($"The value for parameter '{parameterName}' is not of the expected type {typeof(T)}.");
        }

        return typedValue;
    }

    public T? TryGet<T>(string parameterName) where T : class
    {
        return Parameters.TryGetValue(parameterName, out var objValue) && objValue is T typedValue
            ? typedValue
            : null;
    }

    public IEnumerator<KeyValuePair<string, object?>> GetEnumerator()
        => Parameters.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
        => Parameters.GetEnumerator();
}