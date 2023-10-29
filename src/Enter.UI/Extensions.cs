using Microsoft.Extensions.DependencyInjection;
using System.Linq.Expressions;
using Enter.UI.Abstractions;
using Enter.UI.Abstractions.JsServices;
using Enter.UI.Abstractions.Services;
using Enter.UI.Components;
using Enter.UI.Core;
using Enter.UI.JsService;

namespace Enter.UI
{
    public static class Extensions
    {
        public static IEntConfiguration AddEnterUI(this IServiceCollection services)
        {
            services.AddSingleton<IEntMdiService, EntMdiService>();
            services.AddSingleton<IModalService, ModalService>();
            services.AddSingleton<IEntPopoverService, EntPopoverService>();
            services.AddSingleton<IEntToastService, EntToastService>();
            services.AddSingleton<IEntJsService, EntJsService>();
            services.AddSingleton<IEntSharedJsService , EntSharedJsService>();
            return new EntConfiguration()
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
}
