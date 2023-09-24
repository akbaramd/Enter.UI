using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enter.UI.Core
{
    public class CssClassBuilder
    {
        private List<string> CssClasses = new List<string> { };

        public CssClassBuilder(string @class = "")
        {
            CssClasses.Add(@class);
        }

        public CssClassBuilder AddClass(string? @class, bool condition)
        {
            if (condition && !string.IsNullOrWhiteSpace(@class))
            {
                CssClasses.Add(@class);
            }
            return this;
        }

        public CssClassBuilder AddClass(string? @class)
        {
            if (!string.IsNullOrWhiteSpace(@class))
            {
                CssClasses.Add(@class);
            }
            return this;
        }


        public string Build()
        {
            return string.Join(" ", CssClasses);
        }


    }
}
