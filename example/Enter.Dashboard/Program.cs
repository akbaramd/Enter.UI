using Enter.UI;
using Enter.UI.Froala;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace Enter.Dashboard
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            
            Console.WriteLine();
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddEnterUI()
                .AddFroalaModule();

            await builder.Build().RunAsync();

        
        }
    }
}