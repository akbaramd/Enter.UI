﻿namespace Enter.UI.Components
{
    public class EntMdiTabInstance
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
        public Type ComponentType { get; set; }
        public Dictionary<string, object>? ComponentParameters { get; set; }

        public Func<Task>? OnActivated { get; set; }

        internal Action<string> OnClose { get; set; }
        internal Action<string> OnActivate { get; set; }

        public void Close()
        {
           OnClose.Invoke(Id);
        }
        
        public void Activate()
        {
            OnActivate.Invoke(Id);
        }
    }
}
