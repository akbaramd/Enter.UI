using System.Linq.Expressions;
using Enter.UI.Core.Bases;
using Microsoft.AspNetCore.Components;

namespace Enter.UI.Components;

public partial class EntFormGroup<TValue> : EntBaseComponent
{
    private string RootClass => CssClassBuilder
        .AddClass("ent-form-group")
        .Build();
    
    [Parameter]
    public string Label { get; set; }
    
    [Parameter] public Expression<Func<TValue>>? For { get; set; }
    
    [Parameter]
    public RenderFragment? ChildContent { get; set; }
}