using Enter.UI.Components.Icon;

namespace Enter.UI.Components;

public class EntIconProvider : IEntIconProvider
{
    public string Icon(object icon, EntIconStyle style)
    {
        if (icon is not EntIconName iconName) return icon.ToString();

        switch (iconName)
        {
            case EntIconName.Delete:
                return "ri-delete-bin-line";
            case EntIconName.Remove:
                return "ri-close-line";
            case EntIconName.Add:
                return "ri-add-line";
            case EntIconName.Bars:
                return "ri-menu-2-line";
            case EntIconName.ChevronLeft:
                return "ri-arrow-left-s-line";
            case EntIconName.ChevronRight:
                return "ri-arrow-right-s-line";
            case EntIconName.ChevronUp:
                return "ri-arrow-up-s-line";
            case EntIconName.ChevronDown:
                return "ri-arrow-down-s-line";
            case EntIconName.Comment:
                return "ri-chat-4-line";
            case EntIconName.Dashboard:
                return "ri-stack-line";
            case EntIconName.Desktop:
                return "ri-tv-2-line";
            case EntIconName.Edit:
                return "ri-edit-line";
            case EntIconName.Eye:
                return "ri-eye-line";
            case EntIconName.Folder:
                return "ri-folder-line";
            case EntIconName.Home:
                return "ri-home-line";
            case EntIconName.Search:
                return "ri-search-line";
            case EntIconName.SortAsc:
                return "ri-sort-asc";
            case EntIconName.SortDesc:
                return "ri-sort-desc";
            case EntIconName.User:
                return "ri-user-line";
            case EntIconName.AlignRight:
                return "ri-align-right";
            case EntIconName.AlignLeft:
                return "ri-align-left";
            case EntIconName.AlignCenter:
                return "ri-align-center";
            case EntIconName.Moon:
                return "ri-moon-line";
            case EntIconName.Clock:
                return "ri-time-line";
            case EntIconName.List:
                return "ri-file-list-line";
            case EntIconName.Table:
                return "ri-table-line";
            case EntIconName.Note:
                return "ri-sticky-note-line";
            case EntIconName.Download:
                return "ri-download-line";
            case EntIconName.Upload:
                return "ri-upload-line";
            case EntIconName.Save:
                return "ri-save-line";
            case EntIconName.Logout:
                return "ri-logout-box-line";
            case EntIconName.Login:
                return "ri-login-box-line";
            case EntIconName.Users:
                return "ri-group-line";
            case EntIconName.Shiled:
                return "ri-shield-line";
            case EntIconName.Lock:
                return "ri-lock-line";
            default:
                throw new ArgumentOutOfRangeException();
        }

        return icon.ToString();
    }
}