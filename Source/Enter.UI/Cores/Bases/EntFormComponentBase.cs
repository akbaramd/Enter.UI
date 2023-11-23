﻿using Enter.UI.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace Enter.UI.Cores.Bases;

public class EntFormComponentBase : EditForm
{
      
    [Parameter(CaptureUnmatchedValues =true)]
    public Dictionary<string, object?> Attributes { get; set; } = new Dictionary<string, object?>();

    protected CssBuilder CssBuilder =>
        new CssBuilder().AddCss(Attributes.TryGetValue("class", out var @class) ? @class.ToString() : string.Empty);
    
    public string Id => (Attributes?.ContainsKey("id") == true ? Attributes["id"]?.ToString() ?? $"ent-form-{Guid.NewGuid()}" : $"ent-form-{Guid.NewGuid()}");
    
}