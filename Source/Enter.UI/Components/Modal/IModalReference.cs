namespace Enter.UI.Components.Modal;

public interface IModalReference
{
    Task<ModalResult> Result { get; }

    void Close();
    void Close(ModalResult result);
}