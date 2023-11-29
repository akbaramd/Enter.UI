using Enter.Ui.Components;
using Enter.Ui.Core;
using Enter.Ui.Cores.Core;
using Microsoft.AspNetCore.Components;

namespace Enter.Ui.Bases;

public abstract class EntBaseComponent : EntElementComponent, IDisposable
{
    
    public abstract override string ComponentName { get; }
    
    [Parameter] public bool DarkMode { get; set; }

    [CascadingParameter] public EntThemeProvider? EntThemeProvider { get; set; }

    protected override void BuildClasses(ClassBuilder builder)
    {
        builder.AddClass("ent-dark", DarkMode);
        base.BuildClasses(builder);
    }
    
}