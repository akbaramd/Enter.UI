using Microsoft.AspNetCore.Components;

namespace Enter.UI.Components.Popover
{
    public class EntPopoverInstance
    {
        public Guid Key { get; set; } = Guid.NewGuid();
        public bool ShowContent { get; set; } = false;
        public RenderFragment ContentFragment { get; set; }
        public bool IsConnected { get; set; } = false;
        public string PopoverClass { get; set; }
    }
}
