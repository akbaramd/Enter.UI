using Enter.UI.Core;
using Enter.UI.JsService;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enter.UI.JsService
{
    internal class EntSharedJsService : IEntSharedJsService
    {
        private readonly Lazy<Task<IJSObjectReference>> _moduleTask;

        public EntSharedJsService(IEntJsService entJsService)
        {
            _moduleTask = new Lazy<Task<IJSObjectReference>>(() => entJsService.LoadReferenceAsync("getShared"));
        }

        public async Task<BoundingClientRect> GetBoundingClientRect(ElementReference reference)
        {
            var sharedModule = await _moduleTask.Value;
            return await sharedModule.InvokeAsync<BoundingClientRect>("getBoundingClientRect", reference);
        }
    }
}
