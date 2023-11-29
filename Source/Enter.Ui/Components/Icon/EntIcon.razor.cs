using System.ComponentModel.DataAnnotations;
using Enter.Ui.Bases;
using Enter.Ui.Components.Icon;
using Enter.Ui.Core;
using Enter.Ui.Cores.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;

// ReSharper disable once CheckNamespace
namespace Enter.Ui.Components;

public partial class EntIcon : EntBaseComponent
{
    public override string ComponentName => nameof(EntIcon);
    
    private EntIcon? _entIcon => ServiceProvider.GetService<EntIcon>();

    [Inject] public IServiceProvider ServiceProvider { get; set; } = default!;
    [Inject] public IEntIconProvider IconProvider { get; set; } = default!;
    [Required] [Parameter] public object Icon { get; set; }
    [Parameter] public EntIconStyle IconStyle { get; set; } = EntIconStyle.Light;
    [Parameter] public EntIconSize IconSize { get; set; } = EntIconSize.Medium;


    protected override void BuildClasses(ClassBuilder builder)
    {
        builder.AddClass("ent-icon")
            .AddClass("ent-icon-size-sm", IconSize == EntIconSize.Small)
            .AddClass("ent-icon-size-lg", IconSize == EntIconSize.Large);
        
        base.BuildClasses(builder);
    }

    [Parameter] public EventCallback Click { get; set; }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);
    }
}