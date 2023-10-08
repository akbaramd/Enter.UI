using Enter.UI.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Enter.UI.Models
{
    public class EntPopoverInstance
    {
        public Guid Key { get; set; } = Guid.NewGuid();
        public bool ShowContent { get; set; } = false;
        public RenderFragment ContentFragment { get; set; }
    }
}
