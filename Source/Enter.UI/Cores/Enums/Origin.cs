﻿using Enter.Ui.Core.Attributes;

namespace Enter.Ui.Core.Enums;

public enum Origin
{
    [CssClass("top-left")] TopLeft,
    [CssClass("top-center")] TopCenter,
    [CssClass("top-right")] TopRight,
    [CssClass("center-left")] CenterLeft,
    [CssClass("center-center")] CenterCenter,
    [CssClass("center-right")] CenterRight,
    [CssClass("bottom-left")] BottomLeft,
    [CssClass("bottom-center")] BottomCenter,
    [CssClass("bottom-right")] BottomRight
}