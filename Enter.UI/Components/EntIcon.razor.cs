using global::System;
using global::System.Collections.Generic;
using global::System.Linq;
using global::System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web;
using Enter.UI.Components.Controllers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Enter.UI.Bases;
using Enter.UI.Core;
using System.ComponentModel.DataAnnotations;

namespace Enter.UI.Components
{
    public partial class EntIcon : EntBaseComponent
    {

        public EntIcon()
        {
            
        }
        public EntIcon(EntIconType type,string data)
        {
            Data = data;
            Type = type;
        }

        [Required]
        [Parameter]
        public string Data { get; set; }


        [Parameter]
        public EntIconType Type { get; set; } = EntIconType.IconTag;

       
        protected string cssClass => new CssClassBuilder("ent-icon")
           .AddClass($"ent-icon-tag", Type == EntIconType.IconTag)
           .AddClass($"ent-icon-image-tag", Type == EntIconType.ImageTag)
           .AddClass($"ent-icon-svg-content", Type == EntIconType.SvgContent)
           .AddClass(Class)
           .Build();


        public static EntIcon Create(EntIconType type , string data)
        {
            return new EntIcon(type, data);
        }

    }


    public enum EntIconType
    {
       ImageTag , IconTag, SvgContent
    }
}