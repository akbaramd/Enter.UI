using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Enter.UI.Froala.Interops
{
    public static class FroalaInterop
    {
        private const string CommandCreateFroala = "FroalaFunctions.create";
        
        internal static async ValueTask InitializeFroala(
            IJSRuntime jsRuntime)
        {

            var module = await jsRuntime
                .InvokeAsync<IJSObjectReference>("import",
                    $"./_content/Enter.UI.Froala/Enter.UI.Froala.min.js");
            await module.InvokeVoidAsync(
                "FroalaFunctions.initialize");
        }
        
        internal static async ValueTask CreateFroala(
            IJSRuntime jsRuntime,
            ElementReference quillElement)
        {

            var module = await jsRuntime
                .InvokeAsync<IJSObjectReference>("import",
                    $"./_content/Enter.UI.Froala/Enter.UI.Froala.min.js");
            await module.InvokeVoidAsync(
                CommandCreateFroala,
                quillElement);
        }

    }
}
