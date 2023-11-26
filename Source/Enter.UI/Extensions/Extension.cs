using System.Linq.Expressions;
using Enter.Ui.Abstractions;
using Enter.Ui.Components;
using Enter.Ui.Components.Icon;
using Enter.Ui.Components.Toast.Services;
using Enter.Ui.Core;
using Enter.Ui.JsService;
using Enter.Ui.JsServices;
using Enter.Ui.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Enter.Ui;

public static class Extensions
{
    public static IEntConfiguration AddEnterUI(this IServiceCollection services)
    {
#if DEBUG
        services.AddSassCompiler();
#endif
        
        services.AddSingleton<IEntIconProvider, EntIconProvider>();
        services.AddSingleton<IEntMdiService, EntMdiService>();
        services.AddSingleton<IEntModalService, ModalService>();
        services.AddSingleton<IEntPopoverService, EntPopoverService>();
        services.AddSingleton<IEntToastService, EntToastService>();
        services.AddSingleton<IEntJsService, EntJsService>();
        services.AddSingleton<IEntSharedJsService, EntSharedJsService>();
        services.AddTransient<EntIcon>();
        return new EntConfiguration
        {
            Services = services
        };
    }


    public static string GetPropertyName<TProp>(this Expression<Func<TProp>> expression)
    {
        var memberExpression = (MemberExpression)expression.Body;
        return memberExpression.Member.Name;
    }
}