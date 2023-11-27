using Enter.Ui.Bases;
using Enter.Ui.Core;
using Microsoft.AspNetCore.Components;

// ReSharper disable once CheckNamespace
namespace Enter.Ui.Components;

public partial class EntToolbar : EntComponentBase
{
    protected override void BuildClasses(ClassBuilder builder)
    {
        builder.AddClass("ent-toolbar");
        base.BuildClasses(builder);
    }

    [Parameter] public RenderFragment ChildContent { get; set; }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);
    }
}