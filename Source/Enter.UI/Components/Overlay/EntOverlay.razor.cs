using System.Windows.Input;
using Enter.Ui.Cores.Bases;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

// ReSharper disable once CheckNamespace
namespace Enter.Ui.Components;

public partial class EntOverlay : EntComponentBase
{
    private bool _visible;

    protected string Classname =>
        CssBuilder.AddCss("ent-overlay")
            .AddCss("ent-overlay-absolute", Absolute)
            .Build();

    protected string ScrimClassname =>
        CssBuilder.Clear()
            .AddCss("ent-overlay-scrim")
            .AddCss("ent-overlay-dark", DarkBackground)
            .AddCss("ent-overlay-light", LightBackground)
            .Build();

    [Parameter] public RenderFragment? ChildContent { get; set; }

    [Parameter] public EventCallback<bool> VisibleChanged { get; set; }

    [Parameter]
    public bool Visible
    {
        get => _visible;
        set
        {
            if (_visible == value)
                return;
            _visible = value;
            VisibleChanged.InvokeAsync(_visible);
        }
    }

    [Parameter] public bool AutoClose { get; set; }

    [Parameter] public bool LockScroll { get; set; } = true;

    [Parameter] public string LockScrollClass { get; set; } = "scroll-locked";


    [Parameter] public bool DarkBackground { get; set; }

    [Parameter] public bool LightBackground { get; set; }

    [Parameter] public bool Absolute { get; set; }

    [Parameter] public int ZIndex { get; set; } = 5;

    [Parameter]
    [Obsolete("This will be removed in v7.")]
    public object? CommandParameter { get; set; }

    [Parameter]
    [Obsolete($"Use {nameof(OnClick)} instead. This will be removed in v7.")]
    public ICommand? Command { get; set; }

    [Parameter] public EventCallback<MouseEventArgs> OnClick { get; set; }

    protected internal async Task OnClickHandlerAsync(MouseEventArgs ev)
    {
        if (AutoClose)
            Visible = false;
        await OnClick.InvokeAsync(ev);
        if (Command?.CanExecute(CommandParameter) ?? false) Command.Execute(CommandParameter);
    }

    //if not visible or CSS `position:absolute`, don't lock scroll
    protected override async Task OnAfterRenderAsync(bool firstTime)
    {
        if (!LockScroll || Absolute)
            return;
    }

    public override void Dispose()
    {
    }
}