namespace Enter.UI.Components.Drawer;

[Flags]
public enum EntDrawerMode
{
    Behavior = 0,
    Overlay = 1,

    MobileBehavior = 2,
    TabletBehavior = 4,
    LaptopBehavior = 8,
    DesktopBehavior = 16,
    ScreenBehavior = 32,


    MobileOverlay = 64,
    TabletOverlay = 128,
    LaptopOverlay = 256,
    DesktopOverlay = 512,
    ScreenOverlay = 1028
}