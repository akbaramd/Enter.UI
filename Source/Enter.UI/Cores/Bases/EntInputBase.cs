using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace Enter.UI.Core.Bases
{
    public abstract class EntInputBase<T> : InputBase<T> , IAsyncDisposable
    {

        public string ValidationCss => new CssClassBuilder()
       .AddClass("ent-input-validation", UseValidation)
       .AddClass("modified", UseValidation && IsModified)
       .AddClass("validation-requested", UseValidation && ValidationRequested)
       .AddClass("invalid", UseValidation && !IsValid)
       .AddClass("valid", UseValidation && IsValid)
       .Build();

        public string BaseCss => new CssClassBuilder()
        .AddClass("readonly", Readonly)
        .AddClass("disabled", Disabled)
        .Build();

        [Parameter]
        public bool UseValidation { get; set; } = true;
        [Parameter]
        public bool Readonly { get; set; } = false;
        [Parameter]
        public bool Disabled { get; set; } = false;
        [Parameter]
        public string PlaceHolder { get; set; }
        internal bool IsValid { get; set; } = false;
        internal bool ValidationRequested { get; set; } = false;
        internal bool IsModified { get; set; } = false;


        protected CssClassBuilder CssBuilder =>
           new CssClassBuilder()
            .AddClass(AdditionalAttributes?.TryGetValue("class", out var @class) ?? false ? @class?.ToString() ?? string.Empty : string.Empty);


        public string Id => (AdditionalAttributes?.ContainsKey("id") == true ? AdditionalAttributes["id"]?.ToString() ?? $"ent-{Guid.NewGuid()}" : $"ent-{Guid.NewGuid()}");

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

        public ValueTask DisposeAsync()
        {
            if (EditContext != null && UseValidation)
            {
                EditContext.OnValidationRequested -= EditContextOnOnValidationRequested;
                EditContext.OnFieldChanged -= EditContextOnOnFieldChanged;
            }

            return ValueTask.CompletedTask;
        }

        internal void NotifyFieldChanged()
        {
            var name = FieldIdentifier.Create(ValueExpression);
            EditContext.NotifyFieldChanged(name);
        }
    }
}
