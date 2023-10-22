﻿using Enter.UI.Core;
using Enter.UI.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Enter.UI.JsService;

public interface IEntJsService
{


    // Task<EntJsElement> GetElementByIdAsync( string id);
    // Task<EntJsElement> GetElementByQuerySelectorAsync( string selector);
    Task<IJSObjectReference> ImportJsFileAsync(string path);
    Task<IJSObjectReference> LoadReferenceAsync(string path);



}