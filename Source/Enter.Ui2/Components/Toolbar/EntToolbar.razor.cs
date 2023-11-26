using Enter.Ui.Cores.Bases;
using Microsoft.AspNetCore.Components;

// ReSharper disable once CheckNamespace
namespace Enter.Ui.Components;

public partial class EntToolbar : EntComponentBase
{
    protected string RootCss => CssBuilder.AddCss("ent-toolbar")
        .Build();

    [Parameter] public RenderFragment ChildContent { get; set; }

    public override void Dispose()
    {
    }
}