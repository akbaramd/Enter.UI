using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enter.UI.Core.Contracts
{
    internal interface IMargin
    {
        //Margin 
        [Parameter]
         decimal? Margin { get; set; }
        [Parameter]
         decimal? MobileMargin { get; set; }
        [Parameter]
         decimal? TabletMargin { get; set; }
        [Parameter]
         decimal? LaptopMargin { get; set; }
        [Parameter]
         decimal? DesktopMargin { get; set; }
        [Parameter]
         decimal? ScreenMargin { get; set; }

        //Margin Top
        [Parameter]
         decimal? MarginTop { get; set; }
        [Parameter]
         decimal? MobileMarginTop { get; set; }
        [Parameter]
         decimal? TabletMarginTop { get; set; }
        [Parameter]
         decimal? LaptopMarginTop { get; set; }
        [Parameter]
         decimal? DesktopMarginTop { get; set; }
        [Parameter]
         decimal? ScreenMarginTop { get; set; }
    }
}
