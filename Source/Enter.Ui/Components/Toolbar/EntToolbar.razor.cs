using Enter.Ui.Bases;
using Enter.Ui.Core;
using Enter.Ui.Cores.Core;
using Microsoft.AspNetCore.Components;

// ReSharper disable once CheckNamespace
namespace Enter.Ui.Components;

public partial class EntToolbar : EntComponentComponent
{
    protected override void BuildClasses(ClassBuilder builder)
    {
        builder.AddClass("ent-toolbar");
        base.BuildClasses(builder);
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);
    }
}