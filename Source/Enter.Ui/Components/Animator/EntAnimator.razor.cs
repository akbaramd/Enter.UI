using Enter.Ui.Bases;
using Enter.Ui.Components.Animator;
using Enter.Ui.Core;
using Microsoft.AspNetCore.Components;

// ReSharper disable once CheckNamespace
namespace Enter.Ui.Components;

public partial class EntAnimator : EntComponentBase
{
    private bool _expanded, _updateHeight;

    internal ElementReference Reference { get; set; }

    [Parameter] public EntAnimatorState State { get; set; } = EntAnimatorState.Start;

    [Parameter] public EventCallback<EntAnimatorState> StateChanged { get; set; }

    [Parameter] public EventCallback OnAnimationEnd { get; set; }

    [Parameter] public EventCallback OnAnimationStart { get; set; }

    // Style and Css
    protected override void BuildClasses(ClassBuilder builder)
    {
        builder.AddClass("ent-animator");
        base.BuildClasses(builder);
    }


    // Parameters
    [Parameter] public RenderFragment ChildContent { get; set; } = default!;

    private async Task OnAnimationEndCallback()
    {
        if (OnAnimationEnd.HasDelegate) await OnAnimationEnd.InvokeAsync();
    }


    private async Task OnAnimationStartCallback()
    {
        if (OnAnimationStart.HasDelegate) await OnAnimationStart.InvokeAsync();
    }


    
}