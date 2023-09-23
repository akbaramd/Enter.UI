using Enter.UI.Services;
using Enter.UI.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enter.UI
{
    public static class Extensions
    {
        public static void AddEnterUI(this IServiceCollection services)
        {
            services.AddSingleton<IMdiService, MdiService>();
        }
    }
}
