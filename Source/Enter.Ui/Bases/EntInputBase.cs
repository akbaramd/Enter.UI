using Enter.Ui.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace Enter.Ui.Bases;

public abstract class EntInputBase<T> : InputBase<T>, IAsyncDisposable
{

    protected EntInputBase()
    {
        ClassBuilder = new ClassBuilder(BuildClasses);
    }

    protected string ClassNames => ClassBuilder.Build(); 
    protected ClassBuilder ClassBuilder { get; private set; }

    protected virtual void BuildClasses(ClassBuilder builder)
    {
        builder.AddClass(AdditionalAttributes.TryGetValue("class", out var @class) ? @class.ToString() : string.Empty);
    }
    [Parameter] public bool UseValidation { get; set; } = true;

    [Parameter] public bool Readonly { get; set; }

    [Parameter] public bool Disabled { get; set; }

    [Parameter] public string PlaceHolder { get; set; }

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