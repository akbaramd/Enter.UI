using System.Linq.Expressions;
using Enter.UI.Abstractions;
using Enter.UI.Components;
using Enter.UI.Components.Icon;
using Enter.UI.Core;
using Enter.UI.JsService;
using Enter.UI.JsServices;
using Enter.UI.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Enter.UI;

public static class Extensions
{
    public static IEntConfiguration AddEnterUI(this IServiceCollection services)
    {
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