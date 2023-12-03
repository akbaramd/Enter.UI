using Enter.Ui.Bases;
using Enter.Ui.Core;
using Enter.Ui.Cores.Core;
using Microsoft.AspNetCore.Components;

// ReSharper disable once CheckNamespace
namespace Enter.Ui.Components;

public partial class EntNavMenuGroup : EntBaseComponent
{
    public override string ComponentName => this.GetType().Name;
    public EntNavMenuGroup()
    {
        ContainerClassBuilder = new ClassBuilder(BuildContainerClasses);
    }
    private ClassBuilder ContainerClassBuilder { get; set; }

    private string ContainerClassNames => ContainerClassBuilder.Build();

    protected override void BuildClasses(ClassBuilder builder)
    {
        builder.AddClass("ent-nav-menu-group");
        builder.AddClass("active",IsShow);
        base.BuildClasses(builder);
    }
    
    protected  void BuildContainerClasses(ClassBuilder builder)
    {
        builder.AddClass("ent-nav-menu-group-container");
        base.BuildClasses(builder);
    }


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