using System.ComponentModel.DataAnnotations;
using Enter.Ui.Bases;
using Enter.Ui.Core;
using Enter.Ui.Cores.Core;
using Microsoft.AspNetCore.Components;

// ReSharper disable once CheckNamespace
namespace Enter.Ui.Components;

public partial class EntNavMenuTextItem : EntBaseComponent
{
    public override string ComponentName => this.GetType().Name;
    private ClassBuilder IconClassBuilder { get; set; }
    private ClassBuilder ContentClassBuilder { get; set; }

    [CascadingParameter]
    public EntNavMenu NavMenu { get; set; }
    
    private string IconClassNames => IconClassBuilder.Build();
    private string ContentClassNames => ContentClassBuilder.Build();

    public EntNavMenuTextItem()
    {
        IconClassBuilder = new ClassBuilder(BuildIconClasses);
        ContentClassBuilder = new ClassBuilder(BuildContentClasses);
    }
    
    protected override void BuildClasses(ClassBuilder builder)
    {
        builder.AddClass("ent-nav-menu-item ent-nav-menu-item-text");
        builder.AddClass("active",IsActive);
        base.BuildClasses(builder);
    }
    
    protected virtual  void BuildIconClasses(ClassBuilder builder)
    {
        builder.AddClass("ent-nav-menu-item-icon");
    }
    protected virtual  void BuildContentClasses(ClassBuilder builder)
    {
        builder.AddClass("ent-nav-menu-item-content");
    }

    [Parameter] public object Icon { get; set; }

    [Required] [Parameter] public string Text { get; set; }

    [Parameter] public EventCallback Click { get; set; }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);
    }

    internal bool IsActive => NavMenu.ActiveItemId == Id;
    
    private async Task OnClick()
    {
        NavMenu.ActiveItemId = Id;
        await Click.InvokeAsync();
    }
}