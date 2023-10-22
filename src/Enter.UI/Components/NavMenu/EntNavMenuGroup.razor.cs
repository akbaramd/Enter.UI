﻿using Enter.UI.Core;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enter.UI.Core.Bases;

namespace Enter.UI.Components
{
    public partial class EntNavMenuGroup : EntBaseComponent
    {
        protected string RootCss => CssClassBuilder.AddClass("ent-nav-menu-group")
            .AddClass("active",IsShow)
            .Build();
        
        protected string ContainerCss => CssClassBuilder
            .Clear()
            .AddClass("ent-nav-menu-group-container")
            .AddClass("active",IsShow)
            .Build();

        [Parameter]
        public RenderFragment ChildContent { get; set; }
        
        [CascadingParameter]
        public EntNavMenu NavMenu { get; set; }

        public string Id { get; set; }
        
        public bool IsShow { get; set; } = false;

        [Parameter]
        public string Title { get; set; }
        
        [Parameter]
        public string? Icon { get; set; }


        public void ToggleItem()
        {
            NavMenu.Toggle(Id);
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            this.Id = Guid.NewGuid().ToString();
            NavMenu.AddGroup(this);
        }
    }
}