using Enter.Ui.Core;
using Enter.Ui.Cores.Core;
using Microsoft.AspNetCore.Components;

namespace Enter.Ui.Bases;

public abstract class EntResponsiveComponent : EntBaseComponent
{
    [Parameter] public bool Responsive { get; set; } = false;
    [Parameter] public bool AutoResponsive { get; set; } = false;

    protected override void OnInitialized()
    {
        Handle();
        base.OnInitialized();
    }

    protected override void BuildClasses(ClassBuilder builder)
    {
        builder.AddClass("ent-responsive", Responsive);
        base.BuildClasses(builder);
    }

    public void Handle()
    {
        
        if (AutoResponsive)
        {
            if (EntThemeProvider == null) return;
            
            Responsive = EntThemeProvider.ResponsiveMode;
        }
    }

    protected override async Task OnInitializedAsync()
    {
        if (EntThemeProvider == null)
            throw new Exception("please add 'EntThemeProvider' component to root of yout project component");


        await base.OnInitializedAsync();
    }
}