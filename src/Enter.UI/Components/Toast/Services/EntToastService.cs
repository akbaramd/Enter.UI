namespace Enter.UI.Components;

public class EntToastService : IEntToastService
{
    public readonly List<EntToastInstance> ToastInstances = new List<EntToastInstance>();
    public event EventHandler? FragmentsChanged;

    public async Task NotifyAsync(string title, string content, EntToastOptions? options = null)
    {   
        var instance = new EntToastInstance(title, content,options);
        
        ToastInstances.Add(instance);
        var delayMilliseconds = (long)instance.Options.DelaySpan.TotalMilliseconds;
        
        if (delayMilliseconds <= 0)
        {
            delayMilliseconds = 3000; // Set a default delay of 1 second (1000 milliseconds)
        }

        var timer = new Timer(  (s) =>
        {
             CloseAsync(instance.Id);
        }, null,delayMilliseconds, Timeout.Infinite);

        FragmentsChanged?.Invoke(this, EventArgs.Empty);
    }
    
    public async Task CloseAsync(Guid id)
    {
        ToastInstances.Remove(ToastInstances.First(x => x.Id == id));
        FragmentsChanged?.Invoke(this, EventArgs.Empty);
    }
}