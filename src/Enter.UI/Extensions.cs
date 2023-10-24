using Enter.UI.Services;
using Enter.UI.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Enter.UI.Components;
using Enter.UI.Core;
using Enter.UI.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

using Enter.UI.JsService;
using Enter.UI.JsService;

namespace Enter.UI
{
    public static class Extensions
    {
        public static void AddEnterUI(this IServiceCollection services)
        {
            services.AddSingleton<IEntMdiService, EntMdiService>();
            services.AddSingleton<IModalService, ModalService>();
            services.AddSingleton<IEntPopoverService, EntPopoverService>();
            services.AddSingleton<IEntToastService, EntToastService>();
            services.AddSingleton<IEntJsService, EntJsService>();
            services.AddSingleton<IEntSharedJsService , EntSharedJsService>();
        }
        
        public static string GetPropertyName<TProp>(this Expression<Func<TProp>> expression)
        {
            var memberExpression = (MemberExpression)expression.Body;
            return memberExpression.Member.Name;
        }
        
    }
}
