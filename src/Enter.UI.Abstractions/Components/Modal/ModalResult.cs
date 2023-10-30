namespace Enter.UI.Abstractions.Components.Modal;

public class ModalResult
{
    public object? Data { get; }
    public Type DataType { get; }
    public bool Canceled { get; }
    [Obsolete("Use Canceled instead", false)]
    public bool Cancelled => Canceled;

    protected internal ModalResult(object? data, Type resultType, bool canceled)
    {
        Data = data;
        DataType = resultType;
        Canceled = canceled;
    }

    public static ModalResult Ok<T>(T? result) => Ok(result, default);
    public static ModalResult Ok() => Ok(default);

    public static ModalResult Ok<T>(T? result, Type dialogType) => new(result, dialogType, false);
    public static ModalResult Ok( Type dialogType) => new(null, dialogType, false);

    public static ModalResult Cancel() => new(default, typeof(object), true);
}