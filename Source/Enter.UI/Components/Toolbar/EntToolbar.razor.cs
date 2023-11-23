﻿using Enter.UI.Core;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enter.UI.Cores.Bases;


namespace Enter.UI.Components
{
    public partial class EntToolbar : EntComponentBase
    {
        protected string RootCss => CssBuilder.AddCss("ent-toolbar")
            .Build();

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        public override void Dispose()
        {
            
        }
    }
}
