namespace Enter.UI.Components.Modal;

public class ModalResult
{
    protected internal ModalResult(object? data, Type resultType, bool canceled)
    {
        Data = data;
        DataType = resultType;
        Canceled = canceled;
    }

    public object? Data { get; }
    public Type DataType { get; }
    public bool Canceled { get; }

    [Obsolete("Use Canceled instead", false)]
    public bool Cancelled => Canceled;

    public static ModalResult Ok<T>(T? result)
    {
        return Ok(result, default);
    }

    public static ModalResult Ok()
    {
        return Ok(default);
    }

    public static ModalResult Ok<T>(T? result, Type dialogType)
    {
        return new(result, dialogType, false);
    }

    public static ModalResult Ok(Type dialogType)
    {
        return new(null, dialogType, false);
    }

    public static ModalResult Cancel()
    {
        return new(default, typeof(object), true);
    }
}