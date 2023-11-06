using System.ComponentModel.DataAnnotations;
using Enter.UI.Abstractions.Components.Icon;
using Enter.UI.Abstractions.Core.Bases;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;

namespace Enter.UI.Components;

public partial class EntIcon : EntComponentBase
{

    private EntIcon? _entIcon => ServiceProvider.GetService<EntIcon>();
    
    [Inject] public IServiceProvider ServiceProvider { get; set; } = default!;
    [Inject] public IEntIconProvider IconProvider { get; set; } = default!;
    [Required] [Parameter] public object Icon { get; set; }
    [Parameter] public EntIconStyle IconStyle { get; set; } = EntIconStyle.Light;
    [Parameter] public EntIconSize IconSize { get; set; } = EntIconSize.Default;
    
    [Parameter]
    public string ViewBox { get; set; } = "0 0 24 24";

    public string RootCss => CssClassBuilder
        .AddClass("ent-icon")
        .AddClass("ent-icon-size-xs",IconSize == EntIconSize.ExtraSmall)
        .AddClass("ent-icon-size-sm",IconSize == EntIconSize.Small)
        .AddClass("ent-icon-size-lg",IconSize == EntIconSize.Large)
        .AddClass("ent-icon-size-xl",IconSize == EntIconSize.ExtraLarge)
        .AddClass("ent-icon-size-x2",IconSize == EntIconSize.x2)
        .AddClass("ent-icon-size-x3",IconSize == EntIconSize.x3)
        .AddClass("ent-icon-size-x4",IconSize == EntIconSize.x4)
        .AddClass("ent-icon-size-x5",IconSize == EntIconSize.x5)
        .AddClass("ent-icon-size-x6",IconSize == EntIconSize.x6)
        .AddClass("ent-icon-size-x7",IconSize == EntIconSize.x7)
        .AddClass("ent-icon-size-x8",IconSize == EntIconSize.x8)
        .AddClass("ent-icon-size-x9",IconSize == EntIconSize.x9)
        .AddClass("ent-icon-size-x10",IconSize == EntIconSize.x10)
        .Build();
    [Parameter]
    public EventCallback Click { get; set; }

    public override void Dispose()
    {
        
    }
}