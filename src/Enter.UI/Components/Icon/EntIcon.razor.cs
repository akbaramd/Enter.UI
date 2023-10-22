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
using System.Reflection.Metadata;

namespace Enter.UI.Components
{
    public partial class EntIcon : EntBaseComponent
    {

        [Required] [Parameter] public string? Icon { get; set; }
        
        [Parameter]
        public EventCallback Click { get; set; }


        [Parameter]
        public string Fill { get; set; } = "none";

        [Parameter]
        public string Stroke { get; set; } = "currentColor";

        [Parameter]
        public int StrokeWidth { get; set; } = 2;


        [Parameter] public string ViewBox { get; set; } = "0 0 24 24";


        private string RootCss => CssClassBuilder
            .AddClass("ent-icon")
            .AddClass($"h-{Size} w-{Size}",Size != null)
            .Build();

        
        [Parameter]
        public int? Size { get; set; } = 4;
       
    }



}