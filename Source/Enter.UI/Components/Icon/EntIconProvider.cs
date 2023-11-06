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
                    return
                        """<g id="web-app" stroke="none" stroke-width="1"  fill-rule="evenodd"><g id="plus"><path d="M13,13 L13,20 C13,20.5522847 12.5522847,21 12,21 C11.4477153,21 11,20.5522847 11,20 L11,13 L4,13 C3.44771525,13 3,12.5522847 3,12 C3,11.4477153 3.44771525,11 4,11 L11,11 L11,4 C11,3.44771525 11.4477153,3 12,3 C12.5522847,3 13,3.44771525 13,4 L13,11 L20,11 C20.5522847,11 21,11.4477153 21,12 C21,12.5522847 20.5522847,13 20,13 L13,13 Z" id="Shape"></path></g></g>""";
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
                    return  """<g id="brand" stroke="none" stroke-width="1"  fill-rule="evenodd"><g id="codepen" fill="#050101"><path d="M22,15.0469028 C22,15.0847805 21.9973335,15.1221113 21.9923424,15.1594421 C21.9904964,15.1715438 21.9875564,15.1841925 21.9855053,15.1962943 C21.9810611,15.2204977 21.9768221,15.2447012 21.9704636,15.2683577 C21.9668399,15.282579 21.9615753,15.2961849 21.9570628,15.3099275 C21.9502256,15.3309175 21.9434569,15.3520443 21.9350472,15.3731027 C21.9292356,15.3872556 21.9220566,15.4009299 21.9158348,15.4146041 C21.9066047,15.43409 21.8971011,15.4529605 21.8866402,15.4719677 C21.8789143,15.485095 21.8702995,15.4982907 21.8620949,15.511418 C21.8505401,15.5293313 21.8387803,15.5466977 21.8258581,15.563517 C21.8163544,15.5766443 21.8066457,15.5887461 21.7961849,15.6008478 C21.7827157,15.6165732 21.7684945,15.632367 21.7535211,15.6470669 C21.7421715,15.65869 21.7310953,15.6702448 21.7193354,15.680774 C21.7038151,15.6949952 21.6872692,15.7086695 21.6704499,15.7217968 C21.6577328,15.7318474 21.6451525,15.7418296 21.6316833,15.7512649 C21.6267606,15.7544783 21.6223164,15.758649 21.6172569,15.7617941 L12.4768905,21.8555996 C12.3324901,21.9518665 12.1664843,22.0002051 12,22.0002051 C11.8340626,22.0002051 11.6677834,21.9518665 11.523383,21.8555996 L2.38274306,15.7617941 C2.37795706,15.758649 2.37351292,15.7544783 2.3687953,15.7512649 C2.35532613,15.7418296 2.34247231,15.7318474 2.3298236,15.7217968 C2.31300424,15.7086695 2.29666348,15.6949952 2.28114317,15.680774 C2.26931492,15.6702448 2.25803364,15.65869 2.24668399,15.6470669 C2.23171065,15.632367 2.21783126,15.6165732 2.20381512,15.6008478 C2.1938329,15.5887461 2.18385068,15.5766443 2.17441542,15.563517 C2.16176672,15.5466977 2.14966498,15.5293313 2.13831533,15.511418 C2.12963216,15.4982907 2.12149597,15.485095 2.11363326,15.4719677 C2.10310406,15.4529605 2.09366881,15.43409 2.08443867,15.4146041 C2.07787502,15.4009299 2.07124299,15.3872556 2.06522631,15.3731027 C2.05681663,15.3520443 2.049706,15.3309175 2.04314235,15.3099275 C2.03842472,15.2961849 2.0337071,15.282579 2.02974156,15.2683577 C2.02338302,15.2447012 2.01921236,15.2204977 2.01469985,15.1962943 C2.01264871,15.1841925 2.00950362,15.1715438 2.00786271,15.1594421 C2.0028716,15.1221113 2,15.0847805 2,15.0469028 L2,8.95309722 C2,8.91521947 2.0028716,8.87788869 2.00786271,8.84103651 C2.00950362,8.82845617 2.01264871,8.81635444 2.01469985,8.80370573 C2.01921236,8.77950226 2.02338302,8.75529878 2.02974156,8.73164228 C2.0337071,8.71742103 2.03842472,8.70374675 2.04314235,8.69007247 C2.049706,8.66901408 2.05681663,8.64802407 2.06522631,8.62744428 C2.07124299,8.6132914 2.07787502,8.59907015 2.08443867,8.58539587 C2.09366881,8.56591002 2.10310406,8.54697115 2.11363326,8.52857924 C2.12149597,8.51490496 2.12963216,8.50177766 2.13831533,8.48858198 C2.14966498,8.47073704 2.16176672,8.45337071 2.17441542,8.43648298 C2.18385068,8.42390264 2.1938329,8.41125393 2.20381512,8.39922057 C2.21783126,8.38342677 2.23171065,8.36763298 2.24668399,8.35286476 C2.25803364,8.34131 2.26931492,8.32975523 2.28114317,8.31922604 C2.29666348,8.30500479 2.31300424,8.29133051 2.3298236,8.27813483 C2.34247231,8.2681526 2.35532613,8.25817038 2.3687953,8.24873513 C2.37351292,8.24552167 2.37795706,8.24135102 2.38274306,8.23820593 L11.523383,2.14440038 C11.8121838,1.95186654 12.1880213,1.95186654 12.4768905,2.14440038 L21.6172569,8.23820593 C21.6223164,8.24135102 21.6267606,8.24552167 21.6316833,8.24873513 C21.6451525,8.25817038 21.6577328,8.2681526 21.6704499,8.27813483 C21.6872692,8.29133051 21.7038151,8.30500479 21.7193354,8.31922604 C21.7310953,8.32975523 21.7421715,8.34131 21.7535211,8.35286476 C21.7684945,8.36763298 21.7827157,8.38342677 21.7961849,8.39922057 C21.8066457,8.41125393 21.8163544,8.42390264 21.8258581,8.43648298 C21.8387803,8.45337071 21.8505401,8.47073704 21.8620949,8.48858198 C21.8702995,8.50177766 21.8789143,8.51490496 21.8866402,8.52857924 C21.8971011,8.54697115 21.9066047,8.56591002 21.9158348,8.58539587 C21.9220566,8.59907015 21.9292356,8.6132914 21.9350472,8.62744428 C21.9434569,8.64802407 21.9502256,8.66901408 21.9570628,8.69007247 C21.9615753,8.70374675 21.9668399,8.71742103 21.9704636,8.73164228 C21.9768221,8.75529878 21.9810611,8.77950226 21.9855053,8.80370573 C21.9875564,8.81635444 21.9904964,8.82845617 21.9923424,8.84103651 C21.9973335,8.87788869 22,8.91521947 22,8.95309722 L22,15.0469028 Z M3.71886367,10.5617667 L3.71886367,13.4382196 L5.86914399,12.0000273 L3.71886367,10.5617667 Z M11.1406605,8.47386845 L11.1406605,4.4653904 L4.40696704,8.95417749 L7.41489813,10.9663476 L11.1406605,8.47386845 Z M19.5933133,8.95417065 L12.8595515,4.46538356 L12.8595515,8.47386162 L16.5855873,10.9663408 L19.5933133,8.95417065 Z M4.40694653,15.0458362 L11.14064,19.5346233 L11.14064,15.5260768 L7.41494599,13.034213 L4.40694653,15.0458362 Z M12.859531,15.5261042 L12.859531,19.5346506 L19.5932928,15.0458635 L16.5855668,13.0342404 L12.859531,15.5261042 Z M12.0000137,9.96681936 L8.96042664,11.9999795 L12.0000137,14.033208 L15.0398058,11.9999795 L12.0000137,9.96681936 Z M20.281362,13.4382401 L20.281362,10.5617872 L18.1314235,11.9999795 L20.281362,13.4382401 Z" id="Shape"></path></g></g>""";
                case EntIconName.Desktop:
                     return  """<g id="brand" stroke="none" stroke-width="1"  fill-rule="evenodd"><g id="codepen" fill="#050101"><path d="M22,15.0469028 C22,15.0847805 21.9973335,15.1221113 21.9923424,15.1594421 C21.9904964,15.1715438 21.9875564,15.1841925 21.9855053,15.1962943 C21.9810611,15.2204977 21.9768221,15.2447012 21.9704636,15.2683577 C21.9668399,15.282579 21.9615753,15.2961849 21.9570628,15.3099275 C21.9502256,15.3309175 21.9434569,15.3520443 21.9350472,15.3731027 C21.9292356,15.3872556 21.9220566,15.4009299 21.9158348,15.4146041 C21.9066047,15.43409 21.8971011,15.4529605 21.8866402,15.4719677 C21.8789143,15.485095 21.8702995,15.4982907 21.8620949,15.511418 C21.8505401,15.5293313 21.8387803,15.5466977 21.8258581,15.563517 C21.8163544,15.5766443 21.8066457,15.5887461 21.7961849,15.6008478 C21.7827157,15.6165732 21.7684945,15.632367 21.7535211,15.6470669 C21.7421715,15.65869 21.7310953,15.6702448 21.7193354,15.680774 C21.7038151,15.6949952 21.6872692,15.7086695 21.6704499,15.7217968 C21.6577328,15.7318474 21.6451525,15.7418296 21.6316833,15.7512649 C21.6267606,15.7544783 21.6223164,15.758649 21.6172569,15.7617941 L12.4768905,21.8555996 C12.3324901,21.9518665 12.1664843,22.0002051 12,22.0002051 C11.8340626,22.0002051 11.6677834,21.9518665 11.523383,21.8555996 L2.38274306,15.7617941 C2.37795706,15.758649 2.37351292,15.7544783 2.3687953,15.7512649 C2.35532613,15.7418296 2.34247231,15.7318474 2.3298236,15.7217968 C2.31300424,15.7086695 2.29666348,15.6949952 2.28114317,15.680774 C2.26931492,15.6702448 2.25803364,15.65869 2.24668399,15.6470669 C2.23171065,15.632367 2.21783126,15.6165732 2.20381512,15.6008478 C2.1938329,15.5887461 2.18385068,15.5766443 2.17441542,15.563517 C2.16176672,15.5466977 2.14966498,15.5293313 2.13831533,15.511418 C2.12963216,15.4982907 2.12149597,15.485095 2.11363326,15.4719677 C2.10310406,15.4529605 2.09366881,15.43409 2.08443867,15.4146041 C2.07787502,15.4009299 2.07124299,15.3872556 2.06522631,15.3731027 C2.05681663,15.3520443 2.049706,15.3309175 2.04314235,15.3099275 C2.03842472,15.2961849 2.0337071,15.282579 2.02974156,15.2683577 C2.02338302,15.2447012 2.01921236,15.2204977 2.01469985,15.1962943 C2.01264871,15.1841925 2.00950362,15.1715438 2.00786271,15.1594421 C2.0028716,15.1221113 2,15.0847805 2,15.0469028 L2,8.95309722 C2,8.91521947 2.0028716,8.87788869 2.00786271,8.84103651 C2.00950362,8.82845617 2.01264871,8.81635444 2.01469985,8.80370573 C2.01921236,8.77950226 2.02338302,8.75529878 2.02974156,8.73164228 C2.0337071,8.71742103 2.03842472,8.70374675 2.04314235,8.69007247 C2.049706,8.66901408 2.05681663,8.64802407 2.06522631,8.62744428 C2.07124299,8.6132914 2.07787502,8.59907015 2.08443867,8.58539587 C2.09366881,8.56591002 2.10310406,8.54697115 2.11363326,8.52857924 C2.12149597,8.51490496 2.12963216,8.50177766 2.13831533,8.48858198 C2.14966498,8.47073704 2.16176672,8.45337071 2.17441542,8.43648298 C2.18385068,8.42390264 2.1938329,8.41125393 2.20381512,8.39922057 C2.21783126,8.38342677 2.23171065,8.36763298 2.24668399,8.35286476 C2.25803364,8.34131 2.26931492,8.32975523 2.28114317,8.31922604 C2.29666348,8.30500479 2.31300424,8.29133051 2.3298236,8.27813483 C2.34247231,8.2681526 2.35532613,8.25817038 2.3687953,8.24873513 C2.37351292,8.24552167 2.37795706,8.24135102 2.38274306,8.23820593 L11.523383,2.14440038 C11.8121838,1.95186654 12.1880213,1.95186654 12.4768905,2.14440038 L21.6172569,8.23820593 C21.6223164,8.24135102 21.6267606,8.24552167 21.6316833,8.24873513 C21.6451525,8.25817038 21.6577328,8.2681526 21.6704499,8.27813483 C21.6872692,8.29133051 21.7038151,8.30500479 21.7193354,8.31922604 C21.7310953,8.32975523 21.7421715,8.34131 21.7535211,8.35286476 C21.7684945,8.36763298 21.7827157,8.38342677 21.7961849,8.39922057 C21.8066457,8.41125393 21.8163544,8.42390264 21.8258581,8.43648298 C21.8387803,8.45337071 21.8505401,8.47073704 21.8620949,8.48858198 C21.8702995,8.50177766 21.8789143,8.51490496 21.8866402,8.52857924 C21.8971011,8.54697115 21.9066047,8.56591002 21.9158348,8.58539587 C21.9220566,8.59907015 21.9292356,8.6132914 21.9350472,8.62744428 C21.9434569,8.64802407 21.9502256,8.66901408 21.9570628,8.69007247 C21.9615753,8.70374675 21.9668399,8.71742103 21.9704636,8.73164228 C21.9768221,8.75529878 21.9810611,8.77950226 21.9855053,8.80370573 C21.9875564,8.81635444 21.9904964,8.82845617 21.9923424,8.84103651 C21.9973335,8.87788869 22,8.91521947 22,8.95309722 L22,15.0469028 Z M3.71886367,10.5617667 L3.71886367,13.4382196 L5.86914399,12.0000273 L3.71886367,10.5617667 Z M11.1406605,8.47386845 L11.1406605,4.4653904 L4.40696704,8.95417749 L7.41489813,10.9663476 L11.1406605,8.47386845 Z M19.5933133,8.95417065 L12.8595515,4.46538356 L12.8595515,8.47386162 L16.5855873,10.9663408 L19.5933133,8.95417065 Z M4.40694653,15.0458362 L11.14064,19.5346233 L11.14064,15.5260768 L7.41494599,13.034213 L4.40694653,15.0458362 Z M12.859531,15.5261042 L12.859531,19.5346506 L19.5932928,15.0458635 L16.5855668,13.0342404 L12.859531,15.5261042 Z M12.0000137,9.96681936 L8.96042664,11.9999795 L12.0000137,14.033208 L15.0398058,11.9999795 L12.0000137,9.96681936 Z M20.281362,13.4382401 L20.281362,10.5617872 L18.1314235,11.9999795 L20.281362,13.4382401 Z" id="Shape"></path></g></g>""";
                case EntIconName.Edit:
                    return  """<g id="text-edit" stroke="none" stroke-width="1"  fill-rule="evenodd"><g id="edit" ><path d="M5,20 L19,20 C19.5522847,20 20,20.4477153 20,21 C20,21.5522847 19.5522847,22 19,22 L5,22 C4.44771525,22 4,21.5522847 4,21 C4,20.4477153 4.44771525,20 5,20 Z M4,15 C4,15 7.33323693,11.6666667 13.9997108,5 L17,8 C10.3333333,14.6666667 7,18 7,18 C6.34392558,18 5.34392558,18 4,18 C4,16.6105922 4,15.6105922 4,15 Z M15,4 L16.9997108,2 L20,5 L17.9989741,7.00102587 L15,4 Z" id="Shape"></path></g></g>""";
                case EntIconName.Eye:
                    break;
                case EntIconName.Folder:
                    return  """<g id="web-app" stroke="none" stroke-width="1"  fill-rule="evenodd"><g id="folder"  fill-rule="nonzero"><path d="M11,5 L19,5 C20.1045695,5 21,5.8954305 21,7 L21,19 C21,20.1045695 20.1045695,21 19,21 L5,21 C3.8954305,21 3,20.1045695 3,19 C3,9.66666667 3,5 3,5 C3,3.9000001 3.9000001,3 5,3 C5,3 6.33333333,3 9,3 L11,5 Z M5,7 L5,19 L19,19 L19,7 L5,7 Z" id="Shape"></path></g></g>""";
                case EntIconName.Home:
                    return  """ <g id="web-app" stroke="none" stroke-width="1"  fill-rule="evenodd"><g id="home"  fill-rule="nonzero"><path d="M12,5.56124969 L5,11.1612497 L5,19 L10,19 L10,15 L14,15 L14,19 L19,19 L19,11.6418745 C19,11.3380908 18.8619103,11.0507779 18.624695,10.8610057 L12,5.56124969 Z M12,3 L19.8740851,9.29926811 C20.5857308,9.86858467 21,10.7305234 21,11.6418745 L21,19 C21,20.1045695 20.1045695,21 19,21 L5,21 C3.8954305,21 3,20.1045695 3,19 L3,11.1612497 C3,10.5536823 3.27617944,9.97905645 3.7506099,9.59951208 L12,3 Z" id="Shape"></path></g></g>""";
                case EntIconName.Search:
                    return  """<g id="web-app" stroke="none" stroke-width="1"  fill-rule="evenodd"><g id="search" ><path d="M16.3250784,14.8989201 L21.704633,20.2784747 C22.0984557,20.6722974 22.0984557,21.3108102 21.704633,21.704633 C21.3108102,22.0984557 20.6722974,22.0984557 20.2784747,21.704633 L14.8989201,16.3250784 C13.5453296,17.3749907 11.8456542,18 10,18 C5.581722,18 2,14.418278 2,10 C2,5.581722 5.581722,2 10,2 C14.418278,2 18,5.581722 18,10 C18,11.8456542 17.3749907,13.5453296 16.3250784,14.8989201 Z M10,16 C13.3137085,16 16,13.3137085 16,10 C16,6.6862915 13.3137085,4 10,4 C6.6862915,4 4,6.6862915 4,10 C4,13.3137085 6.6862915,16 10,16 Z" id="Shape"></path></g></g>""";
                case EntIconName.Sort:
                    break;
                case EntIconName.User:
                    return """<g id="web-app" stroke="none" stroke-width="1"  fill-rule="evenodd"><g id="user"  fill-rule="nonzero"><path d="M12,12 C9.790861,12 8,10.209139 8,8 C8,5.790861 9.790861,4 12,4 C14.209139,4 16,5.790861 16,8 C16,10.209139 14.209139,12 12,12 Z M12,15 C15.1858467,15 18.0454815,15.5712647 20,18.0625268 C20,18.7758847 20,19.4217091 20,20 C9.33333333,20 4,20 4,20 C4,20 4,19.1325637 4,18.0625268 C5.95451855,15.5712647 8.81415326,15 12,15 Z" id="Shape"></path></g></g>""";
                case EntIconName.AlignRight:
                    return """<g id="production" stroke="none" stroke-width="1"  fill-rule="evenodd"><g id="align-right" ><path d="M17,21 C17,21.5522847 16.5522847,22 16,22 C15.4477153,22 15,21.5522847 15,21 L15,3 C15,2.44771525 15.4477153,2 16,2 C16.5522847,2 17,2.44771525 17,3 L17,21 Z M11,5 C12.1045695,5 13,5.8954305 13,7 C13,8.1045695 12.1045695,9 11,9 L5,9 C3.8954305,9 3,8.1045695 3,7 C3,5.8954305 3.8954305,5 5,5 L11,5 Z M11,12 C12.1045695,12 13,12.8954305 13,14 C13,15.1045695 12.1045695,16 11,16 L7,16 C5.8954305,16 5,15.1045695 5,14 C5,12.8954305 5.8954305,12 7,12 L11,12 Z" id="Shape"></path></g></g>""";
                case EntIconName.AlignLeft:
                    return """<g id="production" stroke="none" stroke-width="1"  fill-rule="evenodd"><g id="align-left" ><path d="M7,21 C7,21.5522847 6.55228475,22 6,22 C5.44771525,22 5,21.5522847 5,21 L5,3 C5,2.44771525 5.44771525,2 6,2 C6.55228475,2 7,2.44771525 7,3 L7,21 Z M11,9 C9.8954305,9 9,8.1045695 9,7 C9,5.8954305 9.8954305,5 11,5 L17,5 C18.1045695,5 19,5.8954305 19,7 C19,8.1045695 18.1045695,9 17,9 L11,9 Z M11.0000001,12 L15,12 C16.1045695,12 17,12.8954305 17,14 C17,15.1045695 16.1045695,16 15,16 L11,16 C9.8954305,16 9,15.1045695 9,14 C9,12.8954305 9.8954305,12 11,12 Z" id="Shape"></path></g></g>""";
                case EntIconName.Moon:
                    return  """<g id="weather" stroke="none" stroke-width="1"  fill-rule="evenodd"><g id="moon" ><path d="M12.9692809,3.00081693 C10.5519709,4.3657756 8.91601003,6.98857416 8.91601003,10 C8.91601003,14.418278 12.4375663,18 16.7816261,18 C17.9282696,18 19.0176067,17.7504503 20,17.3018363 C18.3906054,19.5435802 15.7869372,21 12.8488181,21 C7.96175079,21 4,16.9705627 4,12 C4,7.02943725 7.96175079,3 12.8488181,3 C12.8890356,3 12.9291904,3.00027288 12.9692809,3.00081693 Z" id="Shape"></path></g></g>""";
                case EntIconName.Clock:
                    return  """<g id="web-app" stroke="none" stroke-width="1"  fill-rule="evenodd"><g id="clock" ><path d="M12,22 C6.4771525,22 2,17.5228475 2,12 C2,6.4771525 6.4771525,2 12,2 C17.5228475,2 22,6.4771525 22,12 C22,17.5228475 17.5228475,22 12,22 Z M20,12 C20,7.581722 16.418278,4 12,4 C7.581722,4 4,7.581722 4,12 C4,16.418278 7.581722,20 12,20 C16.418278,20 20,16.418278 20,12 Z M16,11 C16.5522847,11 17,11.4477153 17,12 C17,12.5522847 16.5522847,13 16,13 C14,13 13,13 13,13 C11.8999996,13 11,12.1000004 11,11 C11,11 11,9.66666667 11,7 C11,6.44771525 11.4477153,6 12,6 C12.5522847,6 13,6.44771525 13,7 L13,11 L16,11 Z" id="Shape"></path></g></g>""";
                case EntIconName.List:
                    return  """<g id="text-edit" stroke="none" stroke-width="1"  fill-rule="evenodd"><g id="list-bullet" ><path d="M10,4 L20,4 C20.5522847,4 21,4.44771525 21,5 C21,5.55228475 20.5522847,6 20,6 L10,6 C9.44771525,6 9,5.55228475 9,5 C9,4.44771525 9.44771525,4 10,4 Z M10,11 L20,11 C20.5522847,11 21,11.4477153 21,12 C21,12.5522847 20.5522847,13 20,13 L10,13 C9.44771525,13 9,12.5522847 9,12 C9,11.4477153 9.44771525,11 10,11 Z M10,18 L20,18 C20.5522847,18 21,18.4477153 21,19 C21,19.5522847 20.5522847,20 20,20 L10,20 C9.44771525,20 9,19.5522847 9,19 C9,18.4477153 9.44771525,18 10,18 Z M5,7 C3.8954305,7 3,6.1045695 3,5 C3,3.8954305 3.8954305,3 5,3 C6.1045695,3 7,3.8954305 7,5 C7,6.1045695 6.1045695,7 5,7 Z M5,14 C3.8954305,14 3,13.1045695 3,12 C3,10.8954305 3.8954305,10 5,10 C6.1045695,10 7,10.8954305 7,12 C7,13.1045695 6.1045695,14 5,14 Z M5,21 C3.8954305,21 3,20.1045695 3,19 C3,17.8954305 3.8954305,17 5,17 C6.1045695,17 7,17.8954305 7,19 C7,20.1045695 6.1045695,21 5,21 Z" id="Shape"></path></g></g>""";
                case EntIconName.Table:
                    return  """<g id="text-edit" stroke="none" stroke-width="1"  fill-rule="evenodd"><g id="table"  fill-rule="nonzero"><path d="M4,4 L20,4 C21.1045695,4 22,4.8954305 22,6 L22,18 C22,19.1045695 21.1045695,20 20,20 L4,20 C2.8954305,20 2,19.1045695 2,18 L2,6 C2,4.8954305 2.8954305,4 4,4 Z M13,14 L13,18 L20,18 L20,14 L13,14 Z M4,14 L4,18 L11,18 L11,14 L4,14 Z M13,8 L13,12 L20,12 L20,8 L13,8 Z M4,8 L4,12 L11,12 L11,8 L4,8 Z" id="Shape"></path></g></g>""";
                case EntIconName.Note:
                    return  """ <g id="web-app" stroke="none" stroke-width="1"  fill-rule="evenodd"><g id="book"  fill-rule="nonzero"><path d="M13,16.0056677 L20,15.9589048 L20,5.99176953 L14.8295635,5.99886367 L13.0155542,7.8128729 L13,16.0056677 Z M11,7.8128729 L9.17880413,6.03818338 L4,6.00275313 L4,15.9589048 L11,16.0056513 L11,7.8128729 Z M10,4.04375471 L12,6 L14,4 L19.9972559,3.99177141 C21.1018243,3.99025588 21.9984826,4.88445696 21.9999981,5.98902542 L22,15.9589048 C22,17.0581347 21.1128866,17.9513379 20.0136825,17.958858 L14,18 L12.0040931,20 L10,18 L3.98631753,17.958858 C2.88711335,17.9513379 2,17.0581347 2,15.9589048 L2,6.00275313 C2,4.89818363 2.8954305,4.00275313 4,4.00275313 C4.00304058,4.00275313 6.00304058,4.01642032 10,4.04375471 Z" id="Shape"></path></g></g>""";
                case EntIconName.Download:
                    return  """<g id="web-app" stroke="none" stroke-width="1"  fill-rule="evenodd"><g id="download" ><path d="M5,19 L19,19 C19.5522847,19 20,19.4477153 20,20 C20,20.5522847 19.5522847,21 19,21 L5,21 C4.44771525,21 4,20.5522847 4,20 C4,19.4477153 4.44771525,19 5,19 Z M13,13.1752814 L16.2426407,9.93264074 L17.6568542,11.3468543 L12,17.0037086 L6.34314575,11.3468543 L7.75735931,9.93264074 L11,13.1752814 L11,2 L13,2 L13,13.1752814 Z" id="Shape"></path></g></g>""";
                case EntIconName.Upload:
                    return  """<g id="web-app" stroke="none" stroke-width="1"  fill-rule="evenodd"><g id="upload" ><path d="M13,5.82842712 L13,17 L11,17 L11,5.82842712 L7.75735931,9.07106781 L6.34314575,7.65685425 L12,2 L17.6568542,7.65685425 L16.2426407,9.07106781 L13,5.82842712 Z M5,19 L19,19 C19.5522847,19 20,19.4477153 20,20 C20,20.5522847 19.5522847,21 19,21 L5,21 C4.44771525,21 4,20.5522847 4,20 C4,19.4477153 4.44771525,19 5,19 Z" id="Shape"></path></g></g>""";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        return  icon.ToString();
    }
}