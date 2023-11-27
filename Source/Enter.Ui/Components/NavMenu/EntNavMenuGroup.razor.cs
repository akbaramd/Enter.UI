using Enter.Ui.Bases;
using Enter.Ui.Core;
using Microsoft.AspNetCore.Components;

// ReSharper disable once CheckNamespace
namespace Enter.Ui.Components;

public partial class EntNavMenuGroup : EntComponentComponent
{
    protected string ContainerCss => ClassBuilder.CanUpdate() .AddClass("ent-nav-menu-group-container")
        .Build();

    protected override void BuildClasses(ClassBuilder builder)
    {
        builder.AddClass("ent-nav-menu-group")
           ;
        base.BuildClasses(builder);
    }

    [Parameter] public RenderFragment ChildContent { get; set; }

    [CascadingParameter] public EntNavMenu NavMenu { get; set; }

    public string Id { get; set; }

    public bool IsShow { get; set; } = false;

    [Parameter] public string Title { get; set; }

    [Parameter] public object? Icon { get; set; }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);
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