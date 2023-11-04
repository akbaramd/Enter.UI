using Enter.UI.Abstractions;
using Enter.UI.Abstractions.Components.Icon;
using Enter.UI.Components;
using Enter.UI.Providers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Enter.UI;

public static class FontAwesomeIconExtensions
{
    public static IEntConfiguration AddFontAwesomeIconModule(this IEntConfiguration config)
    {
        config.Services.AddSingleton<IEntIconProvider, FontAwesomeIconProvider>();
        return config;

    }
}