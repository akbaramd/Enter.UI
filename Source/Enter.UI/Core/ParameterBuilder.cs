using System.Linq.Expressions;

namespace Enter.Ui.Core;

public class ParameterBuilder<TComponent>
{
    private readonly Dictionary<string, object> _parameters = new();

    public ParameterBuilder<TComponent> AddParameter<TParam>(Expression<Func<TComponent, TParam>> expression,
        TParam value)
    {
        return AddParameter(((MemberExpression)expression.Body).Member.Name, value);
    }

    public ParameterBuilder<TComponent> AddParameter<TParam>(string name,
        TParam value)
    {
        if (value != null) _parameters.Add(name, value);
        return this;
    }

    public Dictionary<string, object> Build()
    {
        return _parameters;
    }
}