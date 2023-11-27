using Enter.Ui.Bases;
using Enter.Ui.Components.Modal;
using Enter.Ui.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Enter.Ui.Components;

public partial class EntModal : EntComponentComponent
{
    protected override void BuildClasses(ClassBuilder builder)
    {
        builder.AddClass("ent-modal")
            .AddClass(Options?.Class ?? string.Empty, Options != null)
            .AddClass("ent-modal-sm", Options?.Size == EntModalSize.Small)
            .AddClass("ent-modal-md", Options?.Size == EntModalSize.Medium)
            .AddClass("ent-modal-lg", Options?.Size == EntModalSize.Large)
            .AddClass("ent-modal-xl", Options?.Size == EntModalSize.ExtraLarge)
            .AddClass("ent-modal-fs", Options?.Size == EntModalSize.Fullscreen);
        base.BuildClasses(builder);
    }

    private ElementReference _modalReference;
    
    [CascadingParameter] public EntModalProvider ModalProvider { get; set; } = default!;



    [Parameter] public string Title { get; set; }

    [Parameter] public RenderFragment ChildContent { get; set; }

    [Parameter] public EntModalOptions? Options { get; set; }
    
    [Parameter] public string? Id { get; set; }


    protected override async Task OnInitializedAsync()
    {
        Options ??= new EntModalOptions
        {
            Size = EntModalSize.Medium,
            ShowCloseButton = true,
            Closeable = true
        };

        await base.OnInitializedAsync();
    }

  
    /// <summary>
    /// Closes the modal with a default Ok result />.
    /// </summary>
    public async Task CloseAsync() 
        => await CloseAsync(ModalResult.Ok());

    /// <summary>
    /// Closes the modal with the specified <paramref name="modalResult"/>.
    /// </summary>
    /// <param name="modalResult"></param>
    public async Task CloseAsync(ModalResult modalResult)
    {
       
        await ModalProvider.DismissInstance(Id, modalResult);
    }

    /// <summary>
    /// Closes the modal and returns a cancelled ModalResult.
    /// </summary>
    public async Task CancelAsync() 
        => await CloseAsync(ModalResult.Cancel());
    
    /// <summary>
    /// Closes the modal returning the specified <paramref name="payload"/> in a cancelled ModalResult.
    /// </summary>
    public async Task CancelAsync<TPayload>(TPayload payload) 
        => await CloseAsync(ModalResult.Cancel(payload));
    private async Task OnContainerClick(MouseEventArgs args)
    {
        if (Options.ShowCloseButton) await CancelAsync();
    }

    private async Task OnModalClick(MouseEventArgs arg)
    {
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);
    }
}