using Enter.Ui.Core;
using Enter.Ui.Cores.Core;
using Microsoft.AspNetCore.Components;

namespace Enter.Ui.Bases;

public abstract class EntResponsiveComponent : EntBaseComponent
{
    [Parameter] public bool? ResponsiveMode { get; set; }

    protected override void OnInitialized()
    {
        Handle();
        base.OnInitialized();
    }

    protected override void BuildClasses(ClassBuilder builder)
    {
        builder.AddClass("ent-responsive", ResponsiveMode.GetValueOrDefault(false));
        base.BuildClasses(builder);
    }

    public void Handle()
    {
        if (EntThemeProvider != null)
        {
            if (!ResponsiveMode.HasValue)
            {
                ResponsiveMode = EntThemeProvider.ResponsiveMode;
                Console.WriteLine("sss");
               
            }

        }
    }

    protected override async Task OnInitializedAsync()
    {
        if (EntThemeProvider == null)
            throw new Exception("please add 'EntThemeProvider' component to root of yout project component");


        await base.OnInitializedAsync();
    }
}