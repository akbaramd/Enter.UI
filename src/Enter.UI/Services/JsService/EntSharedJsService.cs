using Enter.UI.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Enter.UI.JsService
{
    internal class EntSharedJsService : IEntSharedJsService
    {
        private readonly IEntJsService _entJsService;
        private readonly Lazy<Task<IJSObjectReference>> _moduleTask;

        public EntSharedJsService(IEntJsService entJsService)
        {
            _entJsService = entJsService;
            _moduleTask = new Lazy<Task<IJSObjectReference>>(() => entJsService.LoadReferenceAsync("getShared"));
        }

        public async Task<BoundingClientRect> GetBoundingClientRect(ElementReference reference)
        {
            var sharedModule = await _moduleTask.Value;
            return await sharedModule.InvokeAsync<BoundingClientRect>("getBoundingClientRect", reference);
        }

        public async Task InitializeBreakpointEvent<T>(DotNetObjectReference<T> reference) where T : class
        {
            var sharedModule = await _moduleTask.Value;
            await sharedModule.InvokeVoidAsync("initializeBreakpointEvent", reference);
        }

        public async Task SetAttributeByQuerySelectorAsync(string selector, string key, string value)
        {
            var sharedModule = await _moduleTask.Value;
             await sharedModule.InvokeVoidAsync("setAttributeByQuerySelector", selector,key,value);
        }
    }
}