using Enter.UI.Cores.Bases;
using Microsoft.AspNetCore.Components;

namespace Enter.UI.Components;

public partial class EntNavMenuGroup : EntComponentBase
{
    protected string RootCss => CssBuilder.AddCss("ent-nav-menu-group")
        .Build();

    protected string ContainerCss => CssBuilder
        .Clear()
        .AddCss("ent-nav-menu-group-container")
        .Build();

    [Parameter] public RenderFragment ChildContent { get; set; }

    [CascadingParameter] public EntNavMenu NavMenu { get; set; }

    public string Id { get; set; }

    public bool IsShow { get; set; } = false;

    [Parameter] public string Title { get; set; }

    [Parameter] public object? Icon { get; set; }

    public override void Dispose()
    {
    }


    public void ToggleItem()
    {
        NavMenu.Toggle(Id);
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();
        Id = Guid.NewGuid().ToString();
        NavMenu.AddGroup(this);
    }
}