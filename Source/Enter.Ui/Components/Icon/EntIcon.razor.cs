using System.ComponentModel.DataAnnotations;
using Enter.Ui.Components.Icon;
using Enter.Ui.Cores.Bases;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;

// ReSharper disable once CheckNamespace
namespace Enter.Ui.Components;

public partial class EntIcon : EntComponentBase
{
    private EntIcon? _entIcon => ServiceProvider.GetService<EntIcon>();

    [Inject] public IServiceProvider ServiceProvider { get; set; } = default!;
    [Inject] public IEntIconProvider IconProvider { get; set; } = default!;
    [Required] [Parameter] public object Icon { get; set; }
    [Parameter] public EntIconStyle IconStyle { get; set; } = EntIconStyle.Light;
    [Parameter] public EntIconSize IconSize { get; set; } = EntIconSize.Medium;

    [Parameter] public string ViewBox { get; set; } = "0 0 24 24";

    public string RootCss => CssBuilder
        .AddCss("ent-icon")
        .AddCss("ent-icon-size-sm", IconSize == EntIconSize.Small)
        .AddCss("ent-icon-size-lg", IconSize == EntIconSize.Large)
        .Build();

    [Parameter] public EventCallback Click { get; set; }

    public override void Dispose()
    {
    }
}