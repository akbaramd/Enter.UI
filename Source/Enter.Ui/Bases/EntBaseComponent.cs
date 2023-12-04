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

    protected internal bool FirstRendered { get; private set; } = false;
    protected internal bool Initialized { get; private set; } = false;
    protected internal bool RenderIsReady  => Initialized && FirstRendered;
    [Parameter] public bool DarkMode { get; set; }

    [CascadingParameter] public EntThemeProvider? EntThemeProvider { get; set; }

    protected override void OnInitialized()
    {
        Initialized = true;
        base.OnInitialized();
    }

    protected override Task OnInitializedAsync()
    {
        Initialized = true;
        return base.OnInitializedAsync();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await OnFirstAfterRenderAsync();
            FirstRendered = true;
            StateHasChanged();
        }
        await base.OnAfterRenderAsync(firstRender);
    }

    protected override void OnAfterRender(bool firstRender)
    {
        if (firstRender)
        {
            OnFirstAfterRender();
            FirstRendered = true;
            StateHasChanged();
        }
        base.OnAfterRender(firstRender);
    }

    protected virtual void OnFirstAfterRender(){}

    protected virtual Task OnFirstAfterRenderAsync()=> Task.CompletedTask;
       
    
    protected override void BuildClasses(ClassBuilder builder)
    {
        builder.AddClass("ent-dark", DarkMode);
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