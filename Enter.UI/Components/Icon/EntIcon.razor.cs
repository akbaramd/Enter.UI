using global::System;
using global::System.Collections.Generic;
using global::System.Linq;
using global::System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Enter.UI.Core;
using System.ComponentModel.DataAnnotations;
using Enter.UI.Core.Bases;

namespace Enter.UI.Components
{
    public partial class EntIcon : EntBaseComponent
    {
        public EntIcon()
        {
        }
        

        [Required] [Parameter] public string Data { get; set; }
        
        [Parameter]
        public EventCallback Click { get; set; }

        [Parameter] public EntIconType Type { get; set; } = EntIconType.IconTag;

        protected string RootCss => CssClassBuilder
            .AddClass("ent-icon")
            .AddClass($"ent-icon-tag", Type == EntIconType.IconTag)
            .AddClass($"ent-icon-image-tag", Type == EntIconType.ImageTag)
            .AddClass($"ent-icon-svg-content", Type == EntIconType.SvgContent)
            .Build();
        
    }


    public enum EntIconType
    {
        ImageTag,
        IconTag,
        SvgContent
    }
}