using Enter.Ui.Components.Icon;
using Microsoft.Extensions.DependencyInjection;

namespace Enter.Ui.Cores.Extensions.Icons.FontAwesomeIcon;

public static class FontAwesomeIconExtensions
{
    public static IEntConfiguration AddFontAwesomeIconModule(this IEntConfiguration config)
    {
        config.Services.AddSingleton<IEntIconProvider, FontAwesomeIconProvider>();
        return config;
    }
}