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
    [Parameter] public EntIconNameize IconSize { get; set; } = EntIconNameize.Default;
    
    [Parameter]
    public string ViewBox { get; set; } = "0 0 24 24";

    public string RootCss => CssClassBuilder
        .AddClass("ent-icon")
        .AddClass("ent-icon-size-xs",IconSize == EntIconNameize.ExtraSmall)
        .AddClass("ent-icon-size-sm",IconSize == EntIconNameize.Small)
        .AddClass("ent-icon-size-lg",IconSize == EntIconNameize.Large)
        .AddClass("ent-icon-size-xl",IconSize == EntIconNameize.ExtraLarge)
        .AddClass("ent-icon-size-x2",IconSize == EntIconNameize.x2)
        .AddClass("ent-icon-size-x3",IconSize == EntIconNameize.x3)
        .AddClass("ent-icon-size-x4",IconSize == EntIconNameize.x4)
        .AddClass("ent-icon-size-x5",IconSize == EntIconNameize.x5)
        .AddClass("ent-icon-size-x6",IconSize == EntIconNameize.x6)
        .AddClass("ent-icon-size-x7",IconSize == EntIconNameize.x7)
        .AddClass("ent-icon-size-x8",IconSize == EntIconNameize.x8)
        .AddClass("ent-icon-size-x9",IconSize == EntIconNameize.x9)
        .AddClass("ent-icon-size-x10",IconSize == EntIconNameize.x10)
        .Build();


    public override void Dispose()
    {
        
    }
}