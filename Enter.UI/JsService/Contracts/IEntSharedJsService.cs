using Enter.UI.Core;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enter.UI.JsService.Contracts
{
    internal interface IEntSharedJsService
    {
        Task<BoundingClientRect> GetBoundingClientRect(ElementReference reference);
    }
}
