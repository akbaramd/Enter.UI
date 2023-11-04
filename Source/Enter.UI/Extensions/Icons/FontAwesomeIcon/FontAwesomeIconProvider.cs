using Enter.UI.Abstractions.Components.Icon;

namespace Enter.UI.Providers;

public class FontAwesomeIconProvider : IEntIconProvider
{
    
    private static Dictionary<EntIconName, string> names = new()
    {
        { EntIconName.Add, "fa-plus" },
        { EntIconName.Bars, "fa-bars" },
        { EntIconName.ChevronLeft, "fa-chevron-left" },
        { EntIconName.ChevronRight, "fa-chevron-right" },
        { EntIconName.ChevronUp, "fa-chevron-up" },
        { EntIconName.ChevronDown, "fa-chevron-down" },
        { EntIconName.Comment, "fa-comment" },
        { EntIconName.Dashboard, "fa-columns" },
        { EntIconName.Delete, "fa-trash" },
        { EntIconName.Desktop, "fa-desktop" },
        { EntIconName.Edit, "fa-edit" },
        { EntIconName.Eye, "fa-eye" },
        { EntIconName.Folder, "fa-folder" },
        { EntIconName.Home, "fa-home" },
        { EntIconName.Remove, "fa-minus" },
        { EntIconName.Search, "fa-search" },
        { EntIconName.Sort, "fa-sort" },
    };
    
    private static Dictionary<EntIconStyle, string> styles = new()
    {
        { EntIconStyle.Solid, "fas" },
        { EntIconStyle.Regular, "far" },
        { EntIconStyle.Light, "fal" },
        { EntIconStyle.DuoTone, "fad" },
    };
    
    public string GetIconName(EntIconName name)
    {
        return names[name];
    }

    public string GetIconStyle(EntIconStyle name)
    {
        return styles[name];
    }
    
    
    public  string Icon( object icon, EntIconStyle style )
    {
        var iconStyle = GetIconStyle( style );

        if ( icon is EntIconName iconEnum )
        {
            return $"{iconStyle} {GetIconName( iconEnum)}".Trim();
        }
        else if ( icon is string iconName )
        {
            return $"{iconStyle} {iconName}".Trim();
        }
        return iconStyle;
    }

}