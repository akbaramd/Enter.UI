namespace Enter.UI.Core
{
    public class CssBuilder
    {
        private readonly List<string> _cssClasses = new List<string> { };
        
        public CssBuilder()
        {
        }
        public CssBuilder(string @class)
        {
            AddCss(@class);
        }

        public CssBuilder AddCss(string @class, bool condition  )
        {
            if (condition)
            {
                AddCss(@class);
            }

            return this;
        }

        public CssBuilder AddCss(string @class )
        {
            if (!string.IsNullOrWhiteSpace(@class) && _cssClasses.All(x=> !x.Equals(@class)))
            {
                _cssClasses.Add(@class);    
            }
            return this;
        }
        
        
        public CssBuilder AddDarkModeCss(string @class, bool condition )
        {
            if (condition)
            {
                AddDarkModeCss(@class);
            }

            return this;
        }

        public CssBuilder AddDarkModeCss(string @class )
        {
            if (!string.IsNullOrWhiteSpace(@class)   && _cssClasses.All(x=> !x.Equals(@class)))
            {
                _cssClasses.Add($"dark:{@class}");    
            }
            return this;
        }
        
        
        public CssBuilder AddResponsiveModeCss(string @class, bool condition )
        {
            if (condition)
            {
                AddResponsiveModeCss(@class);
            }

            return this;
        }

        public CssBuilder AddResponsiveModeCss(string @class )
        {
            if (!string.IsNullOrWhiteSpace(@class) && _cssClasses.All(x=> !x.Equals(@class)))
            {
                _cssClasses.Add($"responsive:{@class}");    
            }
            return this;
        }
        
        public CssBuilder Clear()
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