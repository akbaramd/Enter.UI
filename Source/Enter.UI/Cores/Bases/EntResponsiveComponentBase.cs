using System.Diagnostics;
using Enter.UI.Components;
using Enter.UI.Core;
using Microsoft.AspNetCore.Components;

namespace Enter.UI.Cores.Bases;

public abstract class EntResponsiveComponentBase : EntComponentBase
{


    protected new CssBuilder CssBuilder
    {
        get
        {
            Debug.Assert(DarkMode != null, nameof(DarkMode) + " != null");
            return new CssBuilder(darkMode: DarkMode.Value, responsiveMode: ResponsiveMode)
                .AddCss("ent-responsive", ResponsiveMode)
                .AddCss("ent-dark", DarkMode.Value)
                .AddCss(AdditionalAttributes.TryGetValue("class", out var @class) ? @class.ToString() : string.Empty);
        }
    }


    [Parameter] public bool ResponsiveMode { get; set; }
 
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);
        
        if (firstRender)
        {
            Handle();
        }
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
        {
            throw  new Exception("please add 'EntThemeProvider' component to root of yout project component");
            
        }
        
       
        await base.OnInitializedAsync();
        
    }

}