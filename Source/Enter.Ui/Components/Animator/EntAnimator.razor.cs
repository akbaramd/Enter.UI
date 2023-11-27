using Enter.Ui.Bases;
using Enter.Ui.Components.Animator;
using Enter.Ui.Core;
using Microsoft.AspNetCore.Components;

// ReSharper disable once CheckNamespace
namespace Enter.Ui.Components;

public partial class EntAnimator : EntElementComponent
{
   

    internal ElementReference Reference { get; set; }

    [Parameter] public EntAnimatorState State { get; set; } = EntAnimatorState.Start;

    [Parameter] public EventCallback<EntAnimatorState> StateChanged { get; set; }

    [Parameter] public EventCallback OnAnimationEnd { get; set; }

    [Parameter] public EventCallback OnAnimationStart { get; set; }

    // Parameters
    [Parameter] public RenderFragment ChildContent { get; set; } = default!;


    protected override void OnParametersSet()
    {
        StyleBuilder?.CanUpdate();
        ClassBuilder?.CanUpdate();
        base.OnParametersSet();
    }
    protected override Task OnParametersSetAsync()
    {
        StyleBuilder?.CanUpdate();
        ClassBuilder?.CanUpdate();
        return base.OnParametersSetAsync();
    }

    protected override void BuildClasses(ClassBuilder builder)
    {
    
        base.BuildClasses(builder);
    }

    private async Task OnAnimationEndCallback()
    {
        if (OnAnimationEnd.HasDelegate) await OnAnimationEnd.InvokeAsync();
    }

    private async Task OnAnimationStartCallback()
    {
        if (OnAnimationStart.HasDelegate) await OnAnimationStart.InvokeAsync();
    }


    
}