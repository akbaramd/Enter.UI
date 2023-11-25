using Enter.UI.Cores.Bases;
using Microsoft.AspNetCore.Components;

namespace Enter.UI.Components;

public partial class EntToolbar : EntComponentBase
{
    protected string RootCss => CssBuilder.AddCss("ent-toolbar")
        .Build();

    [Parameter] public RenderFragment ChildContent { get; set; }

    public override void Dispose()
    {
    }
}