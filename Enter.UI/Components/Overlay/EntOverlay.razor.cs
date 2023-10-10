using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Enter.UI.Core.Bases;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;


namespace Enter.UI.Components
{
#nullable enable
    public partial class EntOverlay : EntBaseComponent, IAsyncDisposable
    {
        private bool _visible;

        protected string Classname =>
             CssClassBuilder.AddClass("ent-overlay")
                .AddClass("ent-overlay-absolute", Absolute)
                .Build();

        protected string ScrimClassname =>
             CssClassBuilder.Clear()
                 .AddClass("ent-overlay-scrim")
                .AddClass("ent-overlay-dark", DarkBackground)
                .AddClass("ent-overlay-light", LightBackground)
                .Build();

     

        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        [Parameter]
        public EventCallback<bool> VisibleChanged { get; set; }

        [Parameter]
        public bool Visible
        {
            get => _visible;
            set
            {
                if (_visible == value)
                    return;
                _visible = value;
                VisibleChanged.InvokeAsync(_visible);
            }
        }

        [Parameter]
        public bool AutoClose { get; set; }
        
        [Parameter]
        public bool LockScroll { get; set; } = true;

        [Parameter]
        public string LockScrollClass { get; set; } = "scroll-locked";

        
        [Parameter]
        public bool DarkBackground { get; set; }

        [Parameter]
        public bool LightBackground { get; set; }

        [Parameter]
        public bool Absolute { get; set; }

        [Parameter]
        public int ZIndex { get; set; } = 5;

        [Parameter]
        [Obsolete($"This will be removed in v7.")]
        public object? CommandParameter { get; set; }
        
        [Parameter]
        [Obsolete($"Use {nameof(OnClick)} instead. This will be removed in v7.")]
        public ICommand? Command { get; set; }

        [Parameter]
        public EventCallback<MouseEventArgs> OnClick { get; set; }

        protected internal async Task OnClickHandlerAsync(MouseEventArgs ev)
        {
            if (AutoClose)
                Visible = false;
            await OnClick.InvokeAsync(ev);
#pragma warning disable CS0618
            if (Command?.CanExecute(CommandParameter) ?? false)
            {
                Command.Execute(CommandParameter);
            }
#pragma warning restore CS0618
        }

        //if not visible or CSS `position:absolute`, don't lock scroll
        protected override async Task OnAfterRenderAsync(bool firstTime)
        {
            if (!LockScroll || Absolute)
                return;

            // if (Visible)
            //     await BlockScrollAsync();
            // else
            //     await UnblockScrollAsync();
        }

        //locks the scroll attaching a CSS class to the specified element, in this case the body
        // private ValueTask BlockScrollAsync()
        // {
        //     return ScrollManager.LockScrollAsync("body", LockScrollClass);
        // }
        //
        // //removes the CSS class that prevented scrolling
        // private ValueTask UnblockScrollAsync()
        // {
        //     return ScrollManager.UnlockScrollAsync("body", LockScrollClass);
        // }
        //
        // //When disposing the overlay, remove the class that prevented scrolling
        // public ValueTask DisposeAsync()
        // {
        //     if (IsJSRuntimeAvailable)
        //     {
        //         return UnblockScrollAsync();
        //     }
        //
        //     return ValueTask.CompletedTask;
        // }
    }
}
