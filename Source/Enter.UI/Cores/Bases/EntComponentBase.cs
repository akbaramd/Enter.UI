using Enter.UI.Components;
using Enter.UI.Core;
using Microsoft.AspNetCore.Components;

namespace Enter.UI.Cores.Bases;

public abstract class EntComponentBase : ComponentBase, IDisposable
{
    private string? _id;

    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object?> AdditionalAttributes { get; set; } = new();

    protected CssBuilder CssBuilder =>
        new CssBuilder()
            .AddCss(AdditionalAttributes.TryGetValue("class", out var @class) ? @class.ToString() : string.Empty)
            .AddCss("ent-dark", DarkMode);

    protected StyleBuilder StyleBuilder =>
        new StyleBuilder().AddStyle(AdditionalAttributes.TryGetValue("style", out var style)
            ? style.ToString()
            : string.Empty);

    public string Id => AdditionalAttributes?.ContainsKey("id") == true
        ? AdditionalAttributes["id"]?.ToString() ?? GetId()
        : GetId();


    [Parameter] public string Tag { get; set; } = default!;


    [Parameter] public bool DarkMode { get; set; }

    [CascadingParameter] public EntThemeProvider? EntThemeProvider { get; set; }

    public abstract void Dispose();


    protected override Task OnAfterRenderAsync(bool firstRender)
    {
        return base.OnAfterRenderAsync(firstRender);
    }

    protected override void OnAfterRender(bool firstRender)
    {
        base.OnAfterRender(firstRender);
    }


    private string GetId()
    {
        _id ??= $"ent-{Guid.NewGuid()}";
        return _id;
    }
}