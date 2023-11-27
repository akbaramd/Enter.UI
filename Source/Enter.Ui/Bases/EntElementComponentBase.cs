﻿using Enter.Ui.Core;
using Microsoft.AspNetCore.Components;

namespace Enter.Ui.Bases;

public abstract class EntElementComponentBase : EntBaseAfterRenderComponent, IDisposable, IAsyncDisposable
{
    protected EntElementComponentBase()
    {
        ClassBuilder = new ClassBuilder(BuildClasses);
        StyleBuilder = new StyleBuilder(BuildStyles);
    }

    

    protected string ClassNames => ClassBuilder?.Build() ?? string.Empty;
    protected string StyleNames => StyleBuilder?.Build() ?? string.Empty;

    protected ClassBuilder? ClassBuilder { get; set; }
    protected StyleBuilder? StyleBuilder { get; set; }


    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object?> AdditionalAttributes { get; set; } = new();

    [Parameter]
    public string Tag { get; set; } = string.Empty;

    public string Id => AdditionalAttributes?.ContainsKey("id") == true
        ? AdditionalAttributes["id"]?.ToString() ?? Guid.NewGuid().ToString()
        : Guid.NewGuid().ToString();


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


    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            ClassBuilder = null;
            StyleBuilder = null;
        }

        base.Dispose(disposing);
    }

    /// <inheritdoc />
    protected override ValueTask DisposeAsync(bool disposing)
    {
        if (disposing)
        {
            ClassBuilder = null;
            StyleBuilder = null;
        }

        return base.DisposeAsync(disposing);
    }
}