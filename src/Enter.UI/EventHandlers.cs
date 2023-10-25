using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Enter.UI;

[EventHandler("ontransitionend", typeof(EventArgs), enableStopPropagation: true, enablePreventDefault: false)]
[EventHandler("onanimationend", typeof(EventArgs), enableStopPropagation: true, enablePreventDefault: false)]
[EventHandler("onanimationstart", typeof(EventArgs), enableStopPropagation: true, enablePreventDefault: false)]
[EventHandler("onanimationiteration", typeof(EventArgs), enableStopPropagation: true, enablePreventDefault: false)]
[EventHandler("onmouseenter", typeof(MouseEventArgs), enableStopPropagation: true, enablePreventDefault: true)]
[EventHandler("onmouseleave", typeof(MouseEventArgs), enableStopPropagation: true, enablePreventDefault: true)]
public static class EventHandlers
{
}