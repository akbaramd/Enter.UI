using Enter.UI.Core;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enter.UI.Cores.Bases;


namespace Enter.UI.Components
{
    public partial class EntNavMenuTextItem : EntComponentBase
    {
        protected string RootCss => CssBuilder
            .Clear()
            .AddCss("ent-nav-menu-item ent-nav-menu-item-text")
            .Build();
        
        protected string IconCss => CssBuilder
            .Clear()
            .AddCss("ent-nav-menu-item-icon")
            .Build();
        
        protected string ContentCss => CssBuilder
            .Clear()
            .AddCss("ent-nav-menu-item-content")
            .Build();

        [Parameter]
        public object Icon { get; set; }
        
        [Required]
        [Parameter]
        public string  Text { get; set; }



        [Parameter]
        public EventCallback Click { get; set; }
        public override void Dispose()
        {
            
        }
    }
}
