using Enter.UI.Core;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enter.UI.Core.Bases;

namespace Enter.UI.Components
{
    public partial class EntNavMenuTextItem : EntBaseComponent
    {
        protected string RootCss => CssClassBuilder
            .Clear()
            .AddClass("ent-nav-menu-item ent-nav-menu-item-text")
            .Build();
        
        protected string IconCss => CssClassBuilder
            .Clear()
            .AddClass("ent-nav-menu-item-icon")
            .Build();
        
        protected string ContentCss => CssClassBuilder
            .Clear()
            .AddClass("ent-nav-menu-item-content")
            .Build();


        public string Icon { get; set; }
        
        [Required]
        [Parameter]
        public string  Text { get; set; }

        [Parameter]
        public EventCallback Click { get; set; }
    }
}
