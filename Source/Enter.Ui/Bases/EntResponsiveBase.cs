using Enter.Ui.Core;
using Microsoft.AspNetCore.Components;

namespace Enter.Ui.Bases;

public abstract class EntResponsiveComponentComponent : EntComponentComponent
{

    [Parameter] public bool ResponsiveMode { get; set; }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender) Handle();
    }

    protected override void BuildClasses(ClassBuilder builder)
    {
        builder.AddClass("ent-responsive", ResponsiveMode);
        base.BuildClasses(builder);
    }

    public void Handle()
    {
        if (EntThemeProvider != null)
        {
            ResponsiveMode = EntThemeProvider.ResponsiveMode;
            StateHasChanged();

            if (Tag == "MdiTabPage")
            {
                Console.WriteLine("---------------- EntComponentBase (OnInitializedAsync) ----------------");
                Console.WriteLine("Component : " + Tag);
                Console.WriteLine("ResponsiveMode : " + ResponsiveMode);
                Console.WriteLine("DarkMode : " + DarkMode);
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