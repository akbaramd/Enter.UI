using Enter.Ui.Components;
using Enter.Ui.Core;
using Microsoft.AspNetCore.Components;

namespace Enter.Ui.Bases;

public abstract class EntComponentBase : ComponentBase, IDisposable
{
    protected EntComponentBase()
    {
        ClassBuilder = new ClassBuilder(BuildClasses);
        StyleBuilder = new StyleBuilder(BuildStyles);
    }
    
    protected string ClassNames => ClassBuilder.Build(); 
    protected string StyleNames => StyleBuilder.Build(); 
    
    protected ClassBuilder ClassBuilder { get; }
    protected StyleBuilder StyleBuilder { get; }
    
    
    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object?> AdditionalAttributes { get; set; } = new();



    public string Id => AdditionalAttributes?.ContainsKey("id") == true
        ? AdditionalAttributes["id"]?.ToString() ?? GetId()
        : GetId();


    [Parameter] public string Tag { get; set; } = default!;


    [Parameter] public bool DarkMode { get; set; }
    

    [CascadingParameter] public EntThemeProvider? EntThemeProvider { get; set; }


   

    public abstract void Dispose();

   

    protected virtual void BuildClasses(ClassBuilder builder)
    {
        builder.AddClass(AdditionalAttributes.TryGetValue("class", out var @class) ? @class.ToString() : string.Empty);
        builder.AddClass("ent-dark", DarkMode);
    }
    protected virtual void BuildStyles(StyleBuilder builder)
    {
      builder.AddStyle(AdditionalAttributes.TryGetValue("style", out var style)
          ? style.ToString()
          : string.Empty);
    }

    
}