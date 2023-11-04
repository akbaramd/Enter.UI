using Enter.UI.Abstractions;
using Enter.UI.Abstractions.Components.Icon;
using Enter.UI.Providers;
using Microsoft.Extensions.DependencyInjection;

namespace Enter.UI;

public static class FontAwesomeIconExtensions
{
    public static IEntConfiguration AddFontAwesomeIcon(this IEntConfiguration config)
    {
        config.Services.AddSingleton<IEntIconProvider, FontAwesomeIconProvider>();
        return config;

    }
}