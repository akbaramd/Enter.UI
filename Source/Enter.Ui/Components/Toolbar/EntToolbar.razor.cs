using Enter.Ui.Bases;
using Enter.Ui.Core;
using Enter.Ui.Cores.Core;
using Microsoft.AspNetCore.Components;

// ReSharper disable once CheckNamespace
namespace Enter.Ui.Components;

public partial class EntToolbar : EntBaseComponent
{   public override string ComponentName => this.GetType().Name;

    [Parameter]
    public RenderFragment? StartContent { get; set; }
    [Parameter]
    public RenderFragment? EndContent { get; set; }
    [Parameter]
    public RenderFragment? ExpandContent { get; set; }
    
    [Parameter]
    public bool Expanded { get; set; }
    [Parameter]
    public EventCallback<bool> ExpandedChanged { get; set; }
    
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