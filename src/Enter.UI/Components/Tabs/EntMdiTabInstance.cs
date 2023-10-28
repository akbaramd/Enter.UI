using Enter.UI.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enter.UI.Components
{
    public class EntMdiTabInstance
    {
        public Guid Key { get; set; } = Guid.NewGuid();
        public string Id { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
        public Type ComponentType { get; set; }
        public Dictionary<string, object>? ComponentParameters { get; set; }

        public Func<Task>? OnActivated { get; set; }

        internal Action<string> OnClose { get; set; }

        public void Close()
        {
           OnClose.Invoke(Id);
         
        }

    }
}
