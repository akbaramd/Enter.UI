using Enter.Ui.Core;
using Enter.Ui.Cores.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace Enter.Ui.Bases;

public abstract class EntInputBase<T> : InputBase<T>, IAsyncDisposable
{

    protected EntInputBase()
    {
        ClassBuilder = new ClassBuilder(BuildClasses);
        StyleBuilder = new StyleBuilder(BuildStyles);
    }

    protected string ClassNames => ClassBuilder.Build(); 
    protected string StyleNames => StyleBuilder.Build(); 
    protected ClassBuilder ClassBuilder { get; private set; }
    protected StyleBuilder StyleBuilder{ get; private set; }

    protected virtual void BuildClasses(ClassBuilder builder)
    {
        builder.AddClass("ent-input");
        builder.AddClass("ent-input-disable",Disabled);
        builder.AddClass("ent-input-readonly",Readonly);
        builder.AddClass("ent-input-valid",IsValid);
        builder.AddClass("ent-input-modified",IsModified);
        builder.AddClass("ent-input-validation-requested",IsModified);
        if (AdditionalAttributes is not null)
        {
            builder.AddClass((AdditionalAttributes.TryGetValue("class", out var @class) ? @class.ToString() : string.Empty) ?? string.Empty);
        }
    }

    protected virtual void BuildStyles(StyleBuilder builder)
    {
        if (AdditionalAttributes is not null)
        {
            builder.AddStyle((AdditionalAttributes.TryGetValue("style", out var @class)
                ? @class.ToString()
                : string.Empty) ?? string.Empty);
        }

        builder.AddStyle("width: 100%",FullWidth);
    }

    [Parameter] public bool UseValidation { get; set; } = true;

    [Parameter] public bool Readonly { get; set; }

    [Parameter] public bool Disabled { get; set; }

    [Parameter] public string PlaceHolder { get; set; }

    [Parameter] public bool FullWidth { get; set; }

    internal bool IsValid { get; set; }
    internal bool ValidationRequested { get; set; }
    internal bool IsModified { get; set; }

    public string Id => AdditionalAttributes?.ContainsKey("id") == true
        ? AdditionalAttributes["id"]?.ToString() ?? $"ent-{Guid.NewGuid()}"
        : $"ent-{Guid.NewGuid()}";

    public ValueTask DisposeAsync()
    {
        if (EditContext != null && UseValidation)
        {
            EditContext.OnValidationRequested -= EditContextOnOnValidationRequested;
            EditContext.OnFieldChanged -= EditContextOnOnFieldChanged;
        }

        return ValueTask.CompletedTask;
    }

    protected override async Task OnInitializedAsync()
    {
        if (EditContext != null && UseValidation)
        {
            EditContext.OnValidationRequested += EditContextOnOnValidationRequested;
            EditContext.OnFieldChanged += EditContextOnOnFieldChanged;
        }

        await base.OnInitializedAsync();
    }

    private void EditContextOnOnFieldChanged(object? sender, FieldChangedEventArgs e)
    {
        if (ValueExpression == null || UseValidation == false)
            return;

        var name = FieldIdentifier.Create(ValueExpression);
        var messages = EditContext?.GetValidationMessages(name);

        IsValid = !messages?.Any() ?? false;
        IsModified = EditContext?.IsModified(name) ?? false;

        StateHasChanged();
    }

    private void EditContextOnOnValidationRequested(object? sender, ValidationRequestedEventArgs e)
    {
        if (ValueExpression == null || UseValidation == false)
            return;

        var name = FieldIdentifier.Create(ValueExpression);
        var messages = EditContext?.GetValidationMessages(name);

        IsValid = !messages?.Any() ?? false;
        IsModified = EditContext?.IsModified(name) ?? false;
        ValidationRequested = true;

        StateHasChanged();
    }

    internal void NotifyFieldChanged()
    {
        var name = FieldIdentifier.Create(ValueExpression);
        EditContext.NotifyFieldChanged(name);
    }
}