using Enter.UI.Core;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enter.UI.Core.Bases;

namespace Enter.UI.Components
{
    public partial class EntNavMenu : EntBaseComponent
    {
        protected string RootCss => CssClassBuilder.AddClass("ent-nav-menu")
            .Build();

        private readonly List<EntNavMenuGroup> _groups = new List<EntNavMenuGroup>();

        [Parameter]
        public RenderFragment ChildContent { get; set; }


        public void AddGroup(EntNavMenuGroup group)
        {
            _groups.Add(group);
        }
        
        
        public void Toggle(string id)
        {
            foreach (var group in _groups)
            {
                if (group.Id == id)
                {
                    group.IsShow = !group.IsShow;
                }
                else
                {
                    group.IsShow = false;
                }
            }
          
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            _groups.Clear();
        }
    }
}
