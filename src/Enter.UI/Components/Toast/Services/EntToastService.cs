namespace Enter.UI.Components;

public class EntToastService : IEntToastService
{
    public readonly List<EntToastInstance> ToastInstances = new List<EntToastInstance>();

    public event EventHandler? FragmentsChanged;

    public async Task NotifyAsync(string title, string content, EntToastType type = EntToastType.Info, string icon = "fa-light fa-home")
    {
        ToastInstances.Add(new EntToastInstance(type, title, content, icon));
        FragmentsChanged?.Invoke(this, EventArgs.Empty);
    }

    public async Task CloseAsync(Guid id)
    {
        ToastInstances.Remove(ToastInstances.First(x => x.Id == id));
        FragmentsChanged?.Invoke(this, EventArgs.Empty);
    }
}