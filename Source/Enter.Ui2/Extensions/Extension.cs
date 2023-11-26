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
        services.AddScoped<IEntMdiService, EntMdiService>();
        services.AddScoped<IEntModalService, ModalService>();
        services.AddScoped<IEntPopoverService, EntPopoverService>();
        services.AddScoped<IEntToastService, EntToastService>();
        services.AddScoped<IEntJsService, EntJsService>();
        services.AddScoped<IEntSharedJsService, EntSharedJsService>();
        
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