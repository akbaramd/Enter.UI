using Microsoft.AspNetCore.Components;

namespace Enter.Ui.Core;

public static class EventUtil
{
    /// <summary>
    ///     Converts the provided <see cref="Action" /> callback into a non-rendering event handler.
    /// </summary>
    /// <param name="callback">The action callback to be converted.</param>
    /// <returns>A non-rendering event handler.</returns>
    public static Action AsNonRenderingEventHandler(Action callback)
    {
        return new SyncReceiver(callback).Invoke;
    }

    /// <summary>
    ///     Converts the provided <see cref="Action{TValue}" /> callback into a non-rendering event handler.
    /// </summary>
    /// <typeparam name="TValue">The type of the callback argument.</typeparam>
    /// <param name="callback">The action callback to be converted.</param>
    /// <returns>A non-rendering event handler.</returns>
    public static Action<TValue> AsNonRenderingEventHandler<TValue>(Action<TValue> callback)
    {
        return new SyncReceiver<TValue>(callback).Invoke;
    }

    /// <summary>
    ///     Converts the provided <see cref="Func{Task}" /> callback into a non-rendering event handler.
    /// </summary>
    /// <param name="callback">The asynchronous callback to be converted.</param>
    /// <returns>A non-rendering event handler.</returns>
    public static Func<Task> AsNonRenderingEventHandler(Func<Task> callback)
    {
        return new AsyncReceiver(callback).Invoke;
    }

    /// <summary>
    ///     Converts the provided <see cref="Func{TValue, Task}" /> callback into a non-rendering event handler.
    /// </summary>
    /// <typeparam name="TValue">The type of the callback argument.</typeparam>
    /// <param name="callback">The asynchronous callback to be converted.</param>
    /// <returns>A non-rendering event handler.</returns>
    public static Func<TValue, Task> AsNonRenderingEventHandler<TValue>(Func<TValue, Task> callback)
    {
        return new AsyncReceiver<TValue>(callback).Invoke;
    }

    private record SyncReceiver(Action Callback) : ReceiverBase
    {
        public void Invoke()
        {
            Callback();
        }
    }

    private record SyncReceiver<T>(Action<T> Callback) : ReceiverBase
    {
        public void Invoke(T arg)
        {
            Callback(arg);
        }
    }

    private record AsyncReceiver(Func<Task> Callback) : ReceiverBase
    {
        public Task Invoke()
        {
            return Callback();
        }
    }

    private record AsyncReceiver<T>(Func<T, Task> Callback) : ReceiverBase
    {
        public Task Invoke(T arg)
        {
            return Callback(arg);
        }
    }

    private record ReceiverBase : IHandleEvent
    {
        public Task HandleEventAsync(EventCallbackWorkItem item, object? arg)
        {
            return item.InvokeAsync(arg);
        }
    }
}