using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enter.UI.Core
{
    public class CssClassBuilder
    {
        private readonly List<string> _cssClasses = new List<string> { };

        public CssClassBuilder()
        {
        }

        public CssClassBuilder(string @class)
        {
            AddClass(@class);
        }

        public CssClassBuilder AddClass(string @class, bool condition)
        {
            if (condition)
            {
                _cssClasses.Add(@class);
            }

            return this;
        }

        public CssClassBuilder AddClass(string @class)
        {
            _cssClasses.Add(@class);
            return this;
        }


        public string Build()
        {
            return string.Join(" ", _cssClasses);
        }
    }
}