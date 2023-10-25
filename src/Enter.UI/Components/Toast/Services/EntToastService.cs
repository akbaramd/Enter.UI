namespace Enter.UI.Components;

public class EntToastService : IEntToastService
{
   
    public event EventHandler<EntToastInstance>? InstanceCreated;
    public event EventHandler<Guid>?  InstanceClose;
    
    public async Task NotifyAsync(string title, string content, EntToastOptions? options = null)
    {   
        var instance = new EntToastInstance(title, content,options);
        
        var delayMilliseconds = (long)instance.Options.DelaySpan.TotalMilliseconds;
        
        if (delayMilliseconds <= 0)
        {
            delayMilliseconds = 3000; // Set a default delay of 1 second (1000 milliseconds)
        }

        var timer = new Timer(  (s) =>
        {
             CloseAsync(instance.Id);
        }, null,delayMilliseconds, Timeout.Infinite);

        InstanceCreated?.Invoke( EventArgs.Empty,instance);
    }
    
    public async Task CloseAsync(Guid id)
    {
        InstanceClose?.Invoke( EventArgs.Empty,id);
    }
}