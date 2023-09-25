using Enter.UI.Bases;
using Enter.UI.Core;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enter.UI.Components.NavMenu
{
    public partial class EntNavMenuTextItem : EntBaseComponent
    {
        protected string cssClass => new CssClassBuilder("ent-nav-menu-item ent-nav-menu-item-text")
            .AddClass(Class)
            .Build();

        [Required]
        [Parameter]
        public string  Text { get; set; }


        [Parameter]
        public EntIcon? Icon { get; set; }

        [Parameter]
        public EventCallback Click { get; set; }
    }
}
