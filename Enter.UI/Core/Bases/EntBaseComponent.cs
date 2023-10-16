using System.ComponentModel;
using Enter.UI.Core.Extensions;
using Microsoft.AspNetCore.Components;

namespace Enter.UI.Core.Bases
{
    public class EntBaseComponent : ComponentBase
    {
        //todo : Remove Style and Create Style Builder

        private string? _id = null;

        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object?> AdditionalAttributes { get; set; } = new Dictionary<string, object?>();

        protected CssClassBuilder CssClassBuilder =>
            new CssClassBuilder()
            .AddClass(AdditionalAttributes.TryGetValue("class", out var @class) ? @class.ToString() : string.Empty)
            .AddClass($"m-{Margin}",Margin.HasValue)
            .AddClass($"mobile:m-{MobileMargin}", MobileMargin.HasValue)
            .AddClass($"tablet:m-{TabletMargin}", TabletMargin.HasValue)
            .AddClass($"laptop:m-{LaptopMargin}", LaptopMargin.HasValue)
            .AddClass($"desktop:m-{DesktopMargin}", DesktopMargin.HasValue)
            .AddClass($"screen:m-{ScreenMargin}", ScreenMargin.HasValue)
            ;

        protected StyleBuilder StyleBuilder =>
            new StyleBuilder().AddStyle(AdditionalAttributes.TryGetValue("style", out var @style) ? @style.ToString() : string.Empty);
        public string Id => (AdditionalAttributes?.ContainsKey("id") == true ? AdditionalAttributes["id"]?.ToString() ?? GetId() : GetId());



        //Margin 
        [Parameter]
        public decimal? Margin { get; set; }
        [Parameter]
        public decimal? MobileMargin { get; set; }
        [Parameter]
        public decimal? TabletMargin { get; set; }
        [Parameter]
        public decimal? LaptopMargin { get; set; }
        [Parameter]
        public decimal? DesktopMargin { get; set; }
        [Parameter]
        public decimal? ScreenMargin { get; set; }

        //Margin Top
        [Parameter]
        public decimal? MarginTop { get; set; }
        [Parameter]
        public decimal? MobileMarginTop { get; set; }
        [Parameter]
        public decimal? TabletMarginTop { get; set; }
        [Parameter]
        public decimal? LaptopMarginTop { get; set; }
        [Parameter]
        public decimal? DesktopMarginTop { get; set; }
        [Parameter]
        public decimal? ScreenMarginTop { get; set; }


        private string GetId()
        {
            _id ??= $"ent-{Guid.NewGuid()}";

            return _id;
        }

    }
}
