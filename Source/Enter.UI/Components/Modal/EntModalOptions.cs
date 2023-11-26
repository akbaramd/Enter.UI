﻿namespace Enter.Ui.Components.Modal;

public class EntModalOptions
{
    public bool ShowCloseButton { get; set; } = true;
    public bool CloseOnEscapeKey { get; set; } = true;

    public EntModalSize Size { get; set; }
}