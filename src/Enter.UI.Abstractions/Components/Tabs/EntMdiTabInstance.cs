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

        public Func<string,Task> OnActivatedAsync { get; set; } = default!;

        public Func<string,Task> OnCloseAsync { get; set; } = default!;

        public async Task CloseAsync()
        {
          await OnCloseAsync.Invoke(Id);
        }
        
    }
}
