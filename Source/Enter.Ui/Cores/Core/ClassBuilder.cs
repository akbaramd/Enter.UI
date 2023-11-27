namespace Enter.Ui.Core;

public class ClassBuilder
{
    private readonly List<string> _cssClasses = new();

    public ClassBuilder()
    {
    }

    public ClassBuilder(string @class)
    {
        AddCss(@class);
    }

    public ClassBuilder AddCss(string @class, bool condition)
    {
        if (condition) AddCss(@class);

        return this;
    }

    public ClassBuilder AddCss(string @class)
    {
        if (!string.IsNullOrWhiteSpace(@class) && _cssClasses.All(x => !x.Equals(@class))) _cssClasses.Add(@class);
        return this;
    }


    public ClassBuilder AddDarkModeCss(string @class, bool condition)
    {
        if (condition) AddDarkModeCss(@class);

        return this;
    }

    public ClassBuilder AddDarkModeCss(string @class)
    {
        if (!string.IsNullOrWhiteSpace(@class) && _cssClasses.All(x => !x.Equals(@class)))
            _cssClasses.Add($"dark:{@class}");
        return this;
    }


    public ClassBuilder AddResponsiveModeCss(string @class, bool condition)
    {
        if (condition) AddResponsiveModeCss(@class);

        return this;
    }

    public ClassBuilder AddResponsiveModeCss(string @class)
    {
        if (!string.IsNullOrWhiteSpace(@class) && _cssClasses.All(x => !x.Equals(@class)))
            _cssClasses.Add($"responsive:{@class}");
        return this;
    }

    public ClassBuilder Clear()
    {
        _cssClasses.Clear();
        return this;
    }

    public string Build()
    {
        var res = string.Join(" ", _cssClasses);
        return res;
    }
}