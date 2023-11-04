using Enter.UI.Abstractions.Components.Icon;

namespace Enter.UI.Components;

public class EntIconProvider : IEntIconProvider
{
    public string Icon(object icon, EntIconStyle style)
    {
        if (icon is not EntIconName iconName) return icon.ToString();
        
       switch (iconName)
            {
                case EntIconName.Delete:
                    return """<g id="web-app" stroke="none" stroke-width="1" fill-rule="evenodd"><g id="trash" fill-rule="nonzero"><path d="M4,5 L7,5 L7,4 C7,2.8954305 7.8954305,2 9,2 L15,2 C16.1045695,2 17,2.8954305 17,4 L17,5 L20,5 C20.5522847,5 21,5.44771525 21,6 C21,6.55228475 20.5522847,7 20,7 L19,7 L19,20 C19,21.1045695 18.1045695,22 17,22 L7,22 C5.8954305,22 5,21.1045695 5,20 L5,7 L4,7 C3.44771525,7 3,6.55228475 3,6 C3,5.44771525 3.44771525,5 4,5 Z M7,7 L7,20 L17,20 L17,7 L7,7 Z M9,5 L15,5 L15,4 L9,4 L9,5 Z M9,9 L11,9 L11,18 L9,18 L9,9 Z M13,9 L15,9 L15,18 L13,18 L13,9 Z" id="Shape"></path></g></g>""";
                case EntIconName.Remove:
                    return """<g id="web-app" stroke="none" stroke-width="1" fill-rule="evenodd"><g id="close" ><polygon id="Shape" points="10.6568542 12.0710678 5 6.41421356 6.41421356 5 12.0710678 10.6568542 17.7279221 5 19.1421356 6.41421356 13.4852814 12.0710678 19.1421356 17.7279221 17.7279221 19.1421356 12.0710678 13.4852814 6.41421356 19.1421356 5 17.7279221"></polygon></g></g>""";
                case EntIconName.Add:
                    return  """<g id="web-app" stroke="none" stroke-width="1"  fill-rule="evenodd"><g id="plus"><path d="M13,13 L13,20 C13,20.5522847 12.5522847,21 12,21 C11.4477153,21 11,20.5522847 11,20 L11,13 L4,13 C3.44771525,13 3,12.5522847 3,12 C3,11.4477153 3.44771525,11 4,11 L11,11 L11,4 C11,3.44771525 11.4477153,3 12,3 C12.5522847,3 13,3.44771525 13,4 L13,11 L20,11 C20.5522847,11 21,11.4477153 21,12 C21,12.5522847 20.5522847,13 20,13 L13,13 Z" id="Shape"></path></g></g>"""
                case EntIconName.Bars:
                    return  """<g id="web-app" stroke="none" stroke-width="1"  fill-rule="evenodd"><g id="bar" ><path d="M3,16 L21,16 L21,18 L3,18 L3,16 Z M3,11 L21,11 L21,13 L3,13 L3,11 Z M3,6 L21,6 L21,8 L3,8 L3,6 Z" id="Shape"></path></g></g>""";
                case EntIconName.ChevronLeft:
                    return """<g id="directional" stroke="none" stroke-width="1"  fill-rule="evenodd"><g id="arrow-left" ><polygon id="Shape" points="15 4 17 6 11 12 17 18 15 20 7 12"></polygon></g></g>""";
                case EntIconName.ChevronRight:
                    return  """<g id="directional" stroke="none" stroke-width="1"  fill-rule="evenodd"><g id="arrow-right" ><polygon id="Shape" points="9.0047481 4 17.0047481 12 9.0047481 20 7 18 13.0047481 12 7 6"></polygon></g></g>""";
                case EntIconName.ChevronUp:
                    return  """<g id="directional" stroke="none" stroke-width="1"  fill-rule="evenodd"><g id="arrow-up" ><polygon id="Shape" points="4 15 12 7 20 15 18 17 12 11 6 17"></polygon></g></g>""";
                case EntIconName.ChevronDown:
                    return  """<g id="directional" stroke="none" stroke-width="1"  fill-rule="evenodd"><g id="arrow-down" ><polygon id="Shape" points="6 7 12 13 18 7 20 9 12 17 4 9"></polygon></g></g>""";
                case EntIconName.Comment:
                    return """<g id="web-app" stroke="none" stroke-width="1"  fill-rule="evenodd"><g id="comment-o"  fill-rule="nonzero"><path d="M5,21 L5,16.843038 C3.74920013,15.3831855 3,13.5242246 3,11.5 C3,6.80557963 7.02943725,3 12,3 C16.9705627,3 21,6.80557963 21,11.5 C21,16.1944204 16.9705627,20 12,20 C10.2641033,20 8.64299134,19.535851 7.26820965,18.7317903 L5,21 Z M12,18 C15.8659932,18 19,15.0898509 19,11.5 C19,7.91014913 15.8659932,5 12,5 C8.13400675,5 5,7.91014913 5,11.5 C5,15.0898509 8.13400675,18 12,18 Z" id="Shape"></path></g></g>""";
                case EntIconName.Dashboard:
                    break;
                case EntIconName.Desktop:
                    break;
                case EntIconName.Edit:
                    return  """<g id="text-edit" stroke="none" stroke-width="1"  fill-rule="evenodd"><g id="edit" ><path d="M5,20 L19,20 C19.5522847,20 20,20.4477153 20,21 C20,21.5522847 19.5522847,22 19,22 L5,22 C4.44771525,22 4,21.5522847 4,21 C4,20.4477153 4.44771525,20 5,20 Z M4,15 C4,15 7.33323693,11.6666667 13.9997108,5 L17,8 C10.3333333,14.6666667 7,18 7,18 C6.34392558,18 5.34392558,18 4,18 C4,16.6105922 4,15.6105922 4,15 Z M15,4 L16.9997108,2 L20,5 L17.9989741,7.00102587 L15,4 Z" id="Shape"></path></g></g>""";
                case EntIconName.Eye:
                    break;
                case EntIconName.Folder:
                    
                    return  """ <g id="web-app" stroke="none" stroke-width="1"  fill-rule="evenodd"><g id="folder"  fill-rule="nonzero"><path d="M11,5 L19,5 C20.1045695,5 21,5.8954305 21,7 L21,19 C21,20.1045695 20.1045695,21 19,21 L5,21 C3.8954305,21 3,20.1045695 3,19 C3,9.66666667 3,5 3,5 C3,3.9000001 3.9000001,3 5,3 C5,3 6.33333333,3 9,3 L11,5 Z M5,7 L5,19 L19,19 L19,7 L5,7 Z" id="Shape"></path></g></g>""";
                case EntIconName.Home:
                    return  """ <g id="web-app" stroke="none" stroke-width="1"  fill-rule="evenodd"><g id="home"  fill-rule="nonzero"><path d="M12,5.56124969 L5,11.1612497 L5,19 L10,19 L10,15 L14,15 L14,19 L19,19 L19,11.6418745 C19,11.3380908 18.8619103,11.0507779 18.624695,10.8610057 L12,5.56124969 Z M12,3 L19.8740851,9.29926811 C20.5857308,9.86858467 21,10.7305234 21,11.6418745 L21,19 C21,20.1045695 20.1045695,21 19,21 L5,21 C3.8954305,21 3,20.1045695 3,19 L3,11.1612497 C3,10.5536823 3.27617944,9.97905645 3.7506099,9.59951208 L12,3 Z" id="Shape"></path></g></g>""";
                case EntIconName.Search:
                    return  """<g id="web-app" stroke="none" stroke-width="1"  fill-rule="evenodd"><g id="search" ><path d="M16.3250784,14.8989201 L21.704633,20.2784747 C22.0984557,20.6722974 22.0984557,21.3108102 21.704633,21.704633 C21.3108102,22.0984557 20.6722974,22.0984557 20.2784747,21.704633 L14.8989201,16.3250784 C13.5453296,17.3749907 11.8456542,18 10,18 C5.581722,18 2,14.418278 2,10 C2,5.581722 5.581722,2 10,2 C14.418278,2 18,5.581722 18,10 C18,11.8456542 17.3749907,13.5453296 16.3250784,14.8989201 Z M10,16 C13.3137085,16 16,13.3137085 16,10 C16,6.6862915 13.3137085,4 10,4 C6.6862915,4 4,6.6862915 4,10 C4,13.3137085 6.6862915,16 10,16 Z" id="Shape"></path></g></g>""";
                case EntIconName.Sort:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        return  icon.ToString();
    }
}