using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Enter.UI;

[EventHandler("ontransitionend", typeof(EventArgs), true, false)]
[EventHandler("onanimationend", typeof(EventArgs), true, false)]
[EventHandler("onanimationstart", typeof(EventArgs), true, false)]
[EventHandler("onanimationiteration", typeof(EventArgs), true, false)]
[EventHandler("onmouseenter", typeof(MouseEventArgs), true, true)]
[EventHandler("onmouseleave", typeof(MouseEventArgs), true, true)]
public static class EventHandlers
{
}