using Enter.UI.Components;
using Enter.UI.Core;
using Microsoft.AspNetCore.Components;

namespace Enter.UI.Cores.Bases;

public abstract class EntComponentBase : ComponentBase, IDisposable
{
    //todo : Remove Style and Create Style Builder

    private string? _id;

    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object?> AdditionalAttributes { get; set; } = new();

    protected CssBuilder CssBuilder =>
        new CssBuilder(darkMode:DarkMode != null && DarkMode.Value , responsiveMode:false)
            .AddCss("ent-dark",DarkMode != null && DarkMode.Value)
            .AddCss(AdditionalAttributes.TryGetValue("class", out var @class) ? @class.ToString() : string.Empty);

    protected StyleBuilder StyleBuilder =>
        new StyleBuilder().AddStyle(AdditionalAttributes.TryGetValue("style", out var style)
            ? style.ToString()
            : string.Empty);

    public string Id => AdditionalAttributes?.ContainsKey("id") == true
        ? AdditionalAttributes["id"]?.ToString() ?? GetId()
        : GetId();


    public bool FirstRendered { get; set; }

    [Parameter] public string Tag { get; set; } = default!;


    private bool _darkMode = false;

    [Parameter]
    public bool? DarkMode
    {
        get
        {
            return  _darkMode;
        }
        set
        {
            if (value == null)
            {
                _darkMode = EntThemeProvider?.DarkMode??false;
            }
            else
            {
                _darkMode = value.Value;
            }
        }
    }

    [CascadingParameter] public EntThemeProvider? EntThemeProvider { get; set; } = default!;


    protected override Task OnAfterRenderAsync(bool firstRender)
    {
        FirstRendered = true;
        return base.OnAfterRenderAsync(firstRender);
    }

    protected override void OnAfterRender(bool firstRender)
    {
        FirstRendered = true;
        base.OnAfterRender(firstRender);
    }

    public abstract void Dispose();


    private string GetId()
    {
        _id ??= $"ent-{Guid.NewGuid()}";
        return _id;
    }


   
}