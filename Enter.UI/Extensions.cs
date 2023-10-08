using Enter.UI.Services;
using Enter.UI.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enter.UI.Components;
using Enter.UI.Components.Contracts;
using Enter.UI.Models;
using Microsoft.JSInterop;

namespace Enter.UI
{
    public static class Extensions
    {
        public static void AddEnterUI(this IServiceCollection services)
        {
            services.AddSingleton<IEntMdiService, EntMdiService>();
            services.AddSingleton<IModalService, ModalService>();
            services.AddSingleton<IEntPopoverService, EntPopoverService>();
            services.AddSingleton<IEntJsService, EntJsService>();
            services.AddSingleton<IEntLayoutJsService, EntLayoutJsService>();
        }
        
        
        
        
    }
}
