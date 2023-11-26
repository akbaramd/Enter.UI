using Enter.Ui.Abstractions;
using Enter.Ui.Components.Icon;
using Enter.Ui.Providers;
using Microsoft.Extensions.DependencyInjection;

namespace Enter.Ui;

public static class FontAwesomeIconExtensions
{
    public static IEntConfiguration AddFontAwesomeIconModule(this IEntConfiguration config)
    {
        config.Services.AddSingleton<IEntIconProvider, FontAwesomeIconProvider>();
        return config;
    }
}