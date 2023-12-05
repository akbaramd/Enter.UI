using Enter.Ui.Components;
using Enter.Ui.Core;
using Enter.Ui.Cores.Core;
using Microsoft.AspNetCore.Components;

namespace Enter.Ui.Bases;

public abstract class EntBaseComponent : EntElementComponent, IDisposable, IAsyncDisposable
{
    public abstract override string ComponentName { get; }
   
    protected internal bool Disposed { get; private set; }

    protected internal bool AsyncDisposed { get; private set; }

    protected internal bool IsFirstRender { get; private set; } = false;
    protected internal bool FirstRendered { get; private set; } = false;
    protected internal bool AsyncFirstRendered { get; private set; } = false;
    protected internal bool Initialized { get; private set; } = false;
    protected internal bool AsyncInitialized { get; private set; } = false;
    protected internal bool RenderIsReady => AsyncInitialized && AsyncFirstRendered & FirstRendered && Initialized;
    [Parameter] public bool DarkMode { get; set; }
    [Parameter] public bool VerticalScroll { get; set; } = false;
    [Parameter] public bool HorizontalScroll { get; set; } = false;

    [CascadingParameter] public EntThemeProvider? EntThemeProvider { get; set; }

    protected override void OnInitialized()
    {
        Initialized = true;
        base.OnInitialized();
    }

    protected override Task OnInitializedAsync()
    {
        AsyncInitialized = true;
        return base.OnInitializedAsync();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        IsFirstRender = firstRender;
        if (firstRender)
        {
            AsyncFirstRendered = true;
            StateHasChanged();
        }
        await base.OnAfterRenderAsync(firstRender);
    }

    protected override void OnAfterRender(bool firstRender)
    {
        IsFirstRender = firstRender;
        if (firstRender)
        {
            FirstRendered = true;
            StateHasChanged();
        }
        base.OnAfterRender(firstRender);
    }

       
    
    protected override void BuildClasses(ClassBuilder builder)
    {
        builder.AddClass("ent-dark", DarkMode);
        builder.AddClass("vertical-scroll", VerticalScroll);
        builder.AddClass("horizontal-scroll", HorizontalScroll);
        base.BuildClasses(builder);
    }
    
    public void Dispose()
    {
        Dispose( true );
    }
    
    protected virtual void Dispose( bool disposing )
    {
        if ( !Disposed )
        {
            Disposed = true;
        }
    }

    public async ValueTask DisposeAsync()
    {
        await DisposeAsync( true );

        Dispose( false );
    }

    protected virtual ValueTask DisposeAsync( bool disposing )
    {
        try
        {
            if ( !AsyncDisposed )
            {
                AsyncDisposed = true;
            }

            return default;
        }
        catch ( Exception exc )
        {
            return new ValueTask( Task.FromException( exc ) );
        }
    }
    
}