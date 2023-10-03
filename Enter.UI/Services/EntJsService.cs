using Enter.UI.Models;
using Enter.UI.Services.Contracts;
using Microsoft.JSInterop;

namespace Enter.UI.Services;

public class EntJsService : IEntJsService, IAsyncDisposable
{
    private readonly IJSRuntime _jsRuntime;

    public EntJsService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task<IJSObjectReference> ImportJsFileAsync ( string path)
    {
        return await _jsRuntime
            .InvokeAsync<IJSObjectReference>("import",
                $"./_content/Enter.UI/dist/js/{path}");
    }

    public async ValueTask DisposeAsync()
    {
    }
}