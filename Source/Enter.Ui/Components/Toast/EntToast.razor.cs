using Enter.Ui.Bases;
using Enter.Ui.Components.Toast;
using Enter.Ui.Components.Toast.Configuration;
using Enter.Ui.Components.Toast.Services;
using Microsoft.AspNetCore.Components;

// ReSharper disable once CheckNamespace
// ReSharper disable once CheckNamespace
namespace Enter.Ui.Components;

public partial class EntToast : EntComponentComponent
{
    [CascadingParameter] private EntToastProviders ToastsContainer { get; set; } = default!;

    [Parameter, EditorRequired] public Guid ToastId { get; set; }
    [Parameter, EditorRequired] public EntToastOptions Options { get; set; } = default!;
    [Parameter] public EntToastLevel? Level { get; set; }
    [Parameter] public RenderFragment? Message { get; set; }

    private RenderFragment? CloseButtonContent => ToastsContainer.CloseButtonContent;

    private CountdownTimer? _countdownTimer;
    private int _progress = 100;

    protected override async Task OnInitializedAsync()
    {
        if (Options.DisableTimeout ?? false)
        {
            return;
        }
        
        if (Options.ShowProgressBar!.Value)
        {
            _countdownTimer = new CountdownTimer(Options.Timeout, Options.ExtendedTimeout!.Value)
                .OnTick(CalculateProgressAsync)
                .OnElapsed(Close);
        }
        else
        {
            _countdownTimer = new CountdownTimer(Options.Timeout, Options.ExtendedTimeout!.Value)
                .OnElapsed(Close);
        }

        await _countdownTimer.StartAsync();
    }

    /// <summary>
    /// Closes the toast
    /// </summary>
    public void Close()
        => ToastsContainer.RemoveToast(ToastId);

    private void TryPauseCountdown()
    {
        if (Options.PauseProgressOnHover!.Value)
        {
            Options.ShowProgressBar= false;
            _countdownTimer?.Pause();
        }
    }

    private void TryResumeCountdown()
    {        
        if (Options.PauseProgressOnHover!.Value )
        {
            Options.ShowProgressBar = true;
            _countdownTimer?.UnPause();
        }
    }

    private async Task CalculateProgressAsync(int percentComplete)
    {
        _progress = 100 - percentComplete;
        await InvokeAsync(StateHasChanged);
    }

    private void ToastClick()
        => Options.OnClick?.Invoke();

    private bool ShowIconDiv()
        => !string.IsNullOrWhiteSpace(Options.Icon);

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _countdownTimer?.Dispose();
            _countdownTimer = null;
        }
    }
}