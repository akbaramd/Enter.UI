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
                AddClass(@class);
            }

            return this;
        }

        public CssClassBuilder AddClass(string @class)
        {
            if (!string.IsNullOrWhiteSpace(@class))
            {
                _cssClasses.Add(@class);    
            }
            return this;
        }
        
        public CssClassBuilder Clear()
        {
            _cssClasses.Clear();
            return this;
        }

        public string Build()
        {
            var res= string.Join(" ", _cssClasses);
            return res;
        }
    }
}