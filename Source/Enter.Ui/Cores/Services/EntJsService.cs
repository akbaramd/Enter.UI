using Microsoft.JSInterop;

namespace Enter.Ui.Cores.Services;

public class EntJsService : IEntJsService, IAsyncDisposable
{
    private readonly IJSRuntime _jsRuntime;

    private readonly Lazy<Task<IJSObjectReference>> _moduleTask;

    public EntJsService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
        _moduleTask = new Lazy<Task<IJSObjectReference>>(() => ImportJsFileAsync("Enter.Ui.js"));
    }


    public async ValueTask DisposeAsync()
    {
        var module = await _moduleTask.Value;
        await module.DisposeAsync();
    }

    public async Task<IJSObjectReference> ImportJsFileAsync(string path)
    {
        return await _jsRuntime
            .InvokeAsync<IJSObjectReference>("import",
                $"./_content/Enter.Ui/js/{path}").AsTask();
    }

    public async Task<IJSObjectReference> LoadReferenceAsync(string path)
    {
        var module = await _moduleTask.Value;
        return await module.InvokeAsync<IJSObjectReference>(path);
    }
}