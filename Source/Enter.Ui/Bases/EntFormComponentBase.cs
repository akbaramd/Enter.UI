using Enter.Ui.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace Enter.Ui.Bases;

public class EntFormComponentBase : EditForm
{
    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object?> Attributes { get; set; } = new();
    protected EntFormComponentBase()
    {
        ClassBuilder = new ClassBuilder(BuildClasses);
    }
    

    protected string ClassNames => ClassBuilder.Build(); 
    protected ClassBuilder ClassBuilder { get; private set; }

    protected virtual void BuildClasses(ClassBuilder builder)
    {
        builder.AddClass(AdditionalAttributes.TryGetValue("class", out var @class) ? @class.ToString() : string.Empty);
    }

    public string Id => Attributes?.ContainsKey("id") == true
        ? Attributes["id"]?.ToString() ?? $"ent-form-{Guid.NewGuid()}"
        : $"ent-form-{Guid.NewGuid()}";
}