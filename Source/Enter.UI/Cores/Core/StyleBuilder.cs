namespace Enter.UI.Core;

public class StyleBuilder
{
    private readonly List<string> _styles = new();

    public StyleBuilder AddStyle(params string[] styles)
    {
        foreach (var style in styles) AddStyle(style);


        return this;
    }

    public StyleBuilder AddStyle(bool condition, params string[] styles)
    {
        if (condition) AddStyle(styles);

        return this;
    }

    public StyleBuilder AddStyle(string style, bool condition)
    {
        if (condition) AddStyle(style);
        return this;
    }

    public StyleBuilder AddStyle(string style)
    {
        if (!string.IsNullOrWhiteSpace(style)) _styles.Add(style);
        return this;
    }

    public StyleBuilder Clear()
    {
        _styles.Clear();
        return this;
    }

    public string Build()
    {
        return string.Join(";", _styles);
    }
}