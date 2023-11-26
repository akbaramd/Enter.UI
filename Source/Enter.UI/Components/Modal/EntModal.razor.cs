using Enter.Ui.Components.Modal;
using Enter.Ui.Cores.Bases;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Enter.Ui.Components;

public partial class EntModal : EntComponentBase
{
    private string RootCss => CssBuilder
        .AddCss("ent-modal")
        .AddCss(Options?.Class ?? string.Empty,Options != null)
        .AddCss("ent-modal-sm", Options?.Size == EntModalSize.Small)
        .AddCss("ent-modal-md", Options?.Size == EntModalSize.Medium)
        .AddCss("ent-modal-lg", Options?.Size == EntModalSize.Large)
        .AddCss("ent-modal-xl", Options?.Size == EntModalSize.ExtraLarge)
        .AddCss("ent-modal-fs", Options?.Size == EntModalSize.Fullscreen).Build();

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

    public override void Dispose()
    {
    }
}