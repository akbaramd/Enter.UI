namespace Enter.UI.Abstractions.Components.Tabs
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

        public Action<string> OnClose { get; set; }
        public Action<string> OnActivate { get; set; }

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
