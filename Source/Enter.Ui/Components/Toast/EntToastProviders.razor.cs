using Enter.Ui.Bases;
using Enter.Ui.Components.Toast;
using Enter.Ui.Components.Toast.Configuration;
using Enter.Ui.Components.Toast.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

// ReSharper disable once CheckNamespace
namespace Enter.Ui.Components;

public partial class EntToastProviders : EntComponentComponent
{
    [Inject] private IEntToastService EntToastService { get; set; } = default!;
    [Inject] private NavigationManager NavigationManager { get; set; } = default!;

    [Parameter] public string? InfoClass { get; set; }
    [Parameter] public string? InfoIcon { get; set; }
    [Parameter] public string? SuccessClass { get; set; }
    [Parameter] public string? SuccessIcon { get; set; }
    [Parameter] public string? WarningClass { get; set; }
    [Parameter] public string? WarningIcon { get; set; }
    [Parameter] public string? ErrorClass { get; set; }
    [Parameter] public string? ErrorIcon { get; set; }
    [Parameter] public EntToastPosition Position { get; set; } = EntToastPosition.BottomRight;
    [Parameter] public int Timeout { get; set; } = 5;
    [Parameter] public int MaxToastCount { get; set; } = int.MaxValue;
    [Parameter] public bool RemoveToastsOnNavigation { get; set; }
    [Parameter] public bool ShowProgressBar { get; set; }
    [Parameter] public RenderFragment? CloseButtonContent { get; set; }
    [Parameter] public bool ShowCloseButton { get; set; } = true;
    [Parameter] public bool DisableTimeout { get; set; }
    [Parameter] public bool PauseProgressOnHover { get; set; } = false;
    [Parameter] public int ExtendedTimeout { get; set; }

    private List<EntToastInstance> ToastList { get; set; } = new();
    private Queue<EntToastInstance> ToastWaitingQueue { get; set; } = new();

    protected override void OnInitialized()
    {
        EntToastService.OnShow += ShowToast;
        EntToastService.OnShowComponent += ShowCustomToast;
        EntToastService.OnClearAll += ClearAll;
        EntToastService.OnClearToasts += ClearToasts;
        EntToastService.OnClearCustomToasts += ClearCustomToasts;
        EntToastService.OnClearQueue += ClearQueue;
        EntToastService.OnClearQueueToasts += ClearQueueToasts;

        if (RemoveToastsOnNavigation)
        {
            NavigationManager.LocationChanged += ClearToasts;
        }

       
    }

    private EntToastOptions BuildCustomToastSettings(Action<EntToastOptions>? settings)
    {
        var instanceToastSettings = new EntToastOptions();
        settings?.Invoke(instanceToastSettings);
        instanceToastSettings.Timeout = instanceToastSettings.Timeout == 0 ? Timeout : instanceToastSettings.Timeout;
        instanceToastSettings.DisableTimeout ??= DisableTimeout;
        instanceToastSettings.PauseProgressOnHover ??= PauseProgressOnHover;
        instanceToastSettings.ExtendedTimeout ??= ExtendedTimeout;
        instanceToastSettings.Position ??= Position;

        return instanceToastSettings;
    }

    private EntToastOptions BuildToastSettings(EntToastLevel level, Action<EntToastOptions>? settings)
    {
        var toastInstanceSettings = new EntToastOptions();
        settings?.Invoke(toastInstanceSettings);

        return level switch
        {
            EntToastLevel.Error => BuildToastSettings(toastInstanceSettings, "ent-toast-error", ErrorIcon ?? "ri-error-warning-line", ErrorClass),
            EntToastLevel.Info => BuildToastSettings(toastInstanceSettings, "ent-toast-info", InfoIcon ?? "ri-information-line", InfoClass),
            EntToastLevel.Success => BuildToastSettings(toastInstanceSettings, "ent-toast-success", SuccessIcon??"ri-check-line", SuccessClass),
            EntToastLevel.Warning => BuildToastSettings(toastInstanceSettings, "ent-toast-warning", WarningIcon??"ri-error-warning-line", WarningClass),
            _ => throw new ArgumentOutOfRangeException(nameof(level))
        };
    }

    private EntToastOptions BuildToastSettings(EntToastOptions entToastInstanceOptions, string cssClassForLevel, string? configIcon, string? configAdditionalClasses)
    {
        string? additonalClasses = string.IsNullOrEmpty(entToastInstanceOptions.AdditionalClasses) ? configAdditionalClasses : entToastInstanceOptions.AdditionalClasses;

        return new EntToastOptions(
            $"{cssClassForLevel} {additonalClasses}",
            entToastInstanceOptions.Icon ?? configIcon ?? "",
            entToastInstanceOptions.ShowProgressBar ?? ShowProgressBar,
            entToastInstanceOptions.ShowCloseButton ?? ShowCloseButton,
            entToastInstanceOptions.OnClick,
            entToastInstanceOptions.Timeout == 0 ? Timeout : entToastInstanceOptions.Timeout,
            entToastInstanceOptions.DisableTimeout ?? DisableTimeout,
            entToastInstanceOptions.PauseProgressOnHover ?? PauseProgressOnHover,
            entToastInstanceOptions.ExtendedTimeout ?? ExtendedTimeout,
            entToastInstanceOptions.Position ?? Position);
    }

    private void ShowToast(EntToastLevel level, RenderFragment message, Action<EntToastOptions>? toastSettings)
    {
        InvokeAsync(() =>
        {
            var settings = BuildToastSettings(level, toastSettings);
            var toast = new EntToastInstance(message, level, settings);

            if (ToastList.Count < MaxToastCount)
            {
                ToastList.Add(toast);

                StateHasChanged();
            }
            else
            {
                ToastWaitingQueue.Enqueue(toast);
            }
        });
    }

    private void ShowCustomToast(Type contentComponent, ToastParameters? parameters, Action<EntToastOptions>? settings)
    {
        InvokeAsync(() =>
        {
            var childContent = new RenderFragment(builder =>
            {
                var i = 0;
                builder.OpenComponent(i++, contentComponent);
                if (parameters is not null)
                {
                    foreach (var parameter in parameters.Parameters)
                    {
                        builder.AddAttribute(i++, parameter.Key, parameter.Value);
                    }
                }

                builder.CloseComponent();
            });

            var toastSettings = BuildCustomToastSettings(settings);
            var toastInstance = new EntToastInstance(childContent, toastSettings);

            ToastList.Add(toastInstance);

            StateHasChanged();
        });
    }

    private void ShowEnqueuedToast()
    {
        InvokeAsync(() =>
        {
            var toast = ToastWaitingQueue.Dequeue();

            ToastList.Add(toast);

            StateHasChanged();
        });
    }

    public void RemoveToast(Guid toastId)
    {
        InvokeAsync(() =>
        {
            var toastInstance = ToastList.SingleOrDefault(x => x.Id == toastId);

            if (toastInstance is not null)
            {
                ToastList.Remove(toastInstance);
                StateHasChanged();
            }

            if (ToastWaitingQueue.Any())
            {
                ShowEnqueuedToast();
            }
        });
    }

    private void ClearToasts(object? sender, LocationChangedEventArgs args)
    {
        InvokeAsync(() =>
        {
            ToastList.Clear();
            StateHasChanged();

            if (ToastWaitingQueue.Any())
            {
                ShowEnqueuedToast();
            }
        });
    }

    private void ClearAll()
    {
        InvokeAsync(() =>
        {
            ToastList.Clear();
            StateHasChanged();
        });
    }

    private void ClearToasts(EntToastLevel entToastLevel)
    {
        InvokeAsync(() =>
        {
            ToastList.RemoveAll(x => x.CustomComponent is null && x.Level == entToastLevel);
            StateHasChanged();
        });
    }

    private void ClearCustomToasts()
    {
        InvokeAsync(() =>
        {
            ToastList.RemoveAll(x => x.CustomComponent is not null);
            StateHasChanged();
        });
    }

    private void ClearQueue()
    {
        InvokeAsync(() =>
        {
            ToastWaitingQueue.Clear();
            StateHasChanged();
        });
    }

    private void ClearQueueToasts(EntToastLevel entToastLevel)
    {
        InvokeAsync(() =>
        {
            ToastWaitingQueue = new(ToastWaitingQueue.Where(x => x.Level != entToastLevel));
            StateHasChanged();
        });
    }

    protected override void Dispose(bool disposing)
    {
    }
}
