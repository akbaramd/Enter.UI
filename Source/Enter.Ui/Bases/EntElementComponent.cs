using Enter.Ui.Core;
using Enter.Ui.Cores.Core;
using Microsoft.AspNetCore.Components;

namespace Enter.Ui.Bases;

public abstract class EntElementComponent : ComponentBase
{
    protected EntElementComponent()
    {
        ClassBuilder = new ClassBuilder(BuildClasses);
        StyleBuilder = new StyleBuilder(BuildStyles);
    }

    #region Properties

    [Parameter] public RenderFragment? ChildContent { get; set; }

    public abstract string ComponentName { get;  }
    
    
    #endregion
    
    protected string ClassNames => ClassBuilder?.Build() ?? string.Empty;
    protected string StyleNames => StyleBuilder?.Build() ?? string.Empty;

    protected ClassBuilder? ClassBuilder { get; set; }
    protected StyleBuilder? StyleBuilder { get; set; }


    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object?> AdditionalAttributes { get; set; } = new();


    private string _id = string.Empty;
    public string Id => AdditionalAttributes?.ContainsKey("id") == true
        ? AdditionalAttributes["id"]?.ToString() ?? GetNewId()
        : GetNewId();

    protected override void OnAfterRender(bool firstRender)
    {
       // Console.WriteLine($"Component ({ComponentName} rendered)");
        base.OnAfterRender(firstRender);
    }

    private string GetNewId()
    {

        if (string.IsNullOrEmpty(_id))
        {
            _id = Guid.NewGuid().ToString();
        }
        return _id;
    }


    protected virtual void BuildClasses(ClassBuilder builder)
    {
        builder.AddClass(AdditionalAttributes.TryGetValue("class", out var @class) ? @class.ToString() : string.Empty);
    }

    protected virtual void BuildStyles(StyleBuilder builder)
    {
        builder.AddStyle(AdditionalAttributes.TryGetValue("style", out var style)
            ? style.ToString()
            : string.Empty);
    }
    
}