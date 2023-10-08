using System.Reflection;
using Enter.UI.Attributes;
using Enter.UI.Core.Enums;

namespace Enter.UI.Core.Extensions;

public static class OriginExtensions
{
    public static string GetCssClass(this Origin origin)
    {
        FieldInfo field = origin.GetType().GetField(origin.ToString());
        CssClassAttribute attribute = (CssClassAttribute)Attribute.GetCustomAttribute(field, typeof(CssClassAttribute));

        if (attribute != null)
        {
            return attribute.Value;
        }

        return null; // Or throw an exception if desired behavior is to always have a valid CssClass
    }
}