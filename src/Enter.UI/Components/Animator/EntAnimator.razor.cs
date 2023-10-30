using Enter.UI.Abstractions.Components.Animator;
using Enter.UI.Abstractions.Core.Bases;
using Microsoft.AspNetCore.Components;

namespace Enter.UI.Components;

public partial class EntAnimator : EntComponentBase
{
    
    private bool _expanded, _updateHeight;
    
    internal ElementReference Reference { get; set; }

    [Parameter]
    public EntAnimatorState State { get; set; } = EntAnimatorState.Start;
    
    [Parameter]
    public EventCallback<EntAnimatorState> StateChanged { get; set; }
    
    [Parameter]
    public EventCallback OnAnimationEnd { get; set; } 
    
    [Parameter]
    public EventCallback OnAnimationStart { get; set; } 
   
    // Style and Css
    private string RootCss => CssClassBuilder
        .AddClass("ent-animator")
        .Build();
    
    private string RootStyle => StyleBuilder.Build();

    // Parameters
    [Parameter]
    public RenderFragment ChildContent { get; set; } = default!;

    private  async Task OnAnimationEndCallback()
    {
        if (OnAnimationEnd.HasDelegate)
        {
            await OnAnimationEnd.InvokeAsync();
        }
     
        
    }


    private async Task OnAnimationStartCallback()
    {
        if (OnAnimationStart.HasDelegate)
        {
            await OnAnimationStart.InvokeAsync();
        }
    }

}