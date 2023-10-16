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
                .AddClass(heightAndWidthCss, !string.IsNullOrWhiteSpace(heightAndWidthCss))
                .AddClass(flexCss, !string.IsNullOrWhiteSpace(flexCss))
                .AddClass(borderCss, !string.IsNullOrWhiteSpace(borderCss))
                .AddClass(marginCss, !string.IsNullOrWhiteSpace(marginCss))
                .AddClass(paddingCss, !string.IsNullOrWhiteSpace(paddingCss));

        protected StyleBuilder StyleBuilder =>
            new StyleBuilder().AddStyle(AdditionalAttributes.TryGetValue("style", out var @style)
                ? @style.ToString()
                : string.Empty);

        public string Id => (AdditionalAttributes?.ContainsKey("id") == true
            ? AdditionalAttributes["id"]?.ToString() ?? GetId()
            : GetId());


        #region Margin Properties

        protected string marginCss =>
            new CssClassBuilder()
                .AddClass($"m-{Margin}", Margin.HasValue)
                .AddClass($"mobile:m-{MobileMargin}", MobileMargin.HasValue)
                .AddClass($"tablet:m-{TabletMargin}", TabletMargin.HasValue)
                .AddClass($"laptop:m-{LaptopMargin}", LaptopMargin.HasValue)
                .AddClass($"desktop:m-{DesktopMargin}", DesktopMargin.HasValue)
                .AddClass($"screen:m-{ScreenMargin}", ScreenMargin.HasValue)
                .AddClass($"mt-{MarginTop}", MarginTop.HasValue)
                .AddClass($"mobile:mt-{MobileMarginTop}", MobileMarginTop.HasValue)
                .AddClass($"tablet:mt-{TabletMarginTop}", TabletMarginTop.HasValue)
                .AddClass($"laptop:mt-{LaptopMarginTop}", LaptopMarginTop.HasValue)
                .AddClass($"desktop:mt-{DesktopMarginTop}", DesktopMarginTop.HasValue)
                .AddClass($"screen:mt-{ScreenMarginTop}", ScreenMarginTop.HasValue)
                .AddClass($"mb-{MarginBottom}", MarginBottom.HasValue)
                .AddClass($"mobile:mb-{MobileMarginBottom}", MobileMarginBottom.HasValue)
                .AddClass($"tablet:mb-{TabletMarginBottom}", TabletMarginBottom.HasValue)
                .AddClass($"laptop:mb-{LaptopMarginBottom}", LaptopMarginBottom.HasValue)
                .AddClass($"desktop:mb-{DesktopMarginBottom}", DesktopMarginBottom.HasValue)
                .AddClass($"screen:mb-{ScreenMarginBottom}", ScreenMarginBottom.HasValue)
                .AddClass($"ml-{MarginLeft}", MarginLeft.HasValue)
                .AddClass($"mobile:ml-{MobileMarginLeft}", MobileMarginLeft.HasValue)
                .AddClass($"tablet:ml-{TabletMarginLeft}", TabletMarginLeft.HasValue)
                .AddClass($"laptop:ml-{LaptopMarginLeft}", LaptopMarginLeft.HasValue)
                .AddClass($"desktop:ml-{DesktopMarginLeft}", DesktopMarginLeft.HasValue)
                .AddClass($"screen:ml-{ScreenMarginLeft}", ScreenMarginLeft.HasValue)
                .AddClass($"mr-{MarginRight}", MarginRight.HasValue)
                .AddClass($"mobile:mr-{MobileMarginRight}", MobileMarginRight.HasValue)
                .AddClass($"tablet:mr-{TabletMarginRight}", TabletMarginRight.HasValue)
                .AddClass($"laptop:mr-{LaptopMarginRight}", LaptopMarginRight.HasValue)
                .AddClass($"desktop:mr-{DesktopMarginRight}", DesktopMarginRight.HasValue)
                .AddClass($"screen:mr-{ScreenMarginRight}", ScreenMarginRight.HasValue)
                .AddClass($"ms-{MarginStart}", MarginStart.HasValue)
                .AddClass($"mobile:ms-{MobileMarginStart}", MobileMarginStart.HasValue)
                .AddClass($"tablet:ms-{TabletMarginStart}", TabletMarginStart.HasValue)
                .AddClass($"laptop:ms-{LaptopMarginStart}", LaptopMarginStart.HasValue)
                .AddClass($"desktop:ms-{DesktopMarginStart}", DesktopMarginStart.HasValue)
                .AddClass($"screen:ms-{ScreenMarginStart}", ScreenMarginStart.HasValue)
                .AddClass($"me-{MarginEnd}", MarginEnd.HasValue)
                .AddClass($"mobile:me-{MobileMarginEnd}", MobileMarginEnd.HasValue)
                .AddClass($"tablet:me-{TabletMarginEnd}", TabletMarginEnd.HasValue)
                .AddClass($"laptop:me-{LaptopMarginEnd}", LaptopMarginEnd.HasValue)
                .AddClass($"desktop:me-{DesktopMarginEnd}", DesktopMarginEnd.HasValue)
                .AddClass($"screen:me-{ScreenMarginEnd}", ScreenMarginEnd.HasValue)
                .Build();


        [Parameter] public decimal? Margin { get; set; }
        [Parameter] public decimal? MobileMargin { get; set; }
        [Parameter] public decimal? TabletMargin { get; set; }
        [Parameter] public decimal? LaptopMargin { get; set; }
        [Parameter] public decimal? DesktopMargin { get; set; }
        [Parameter] public decimal? ScreenMargin { get; set; }


        [Parameter] public decimal? MarginTop { get; set; }
        [Parameter] public decimal? MobileMarginTop { get; set; }
        [Parameter] public decimal? TabletMarginTop { get; set; }
        [Parameter] public decimal? LaptopMarginTop { get; set; }
        [Parameter] public decimal? DesktopMarginTop { get; set; }
        [Parameter] public decimal? ScreenMarginTop { get; set; }

        [Parameter] public decimal? MarginBottom { get; set; }
        [Parameter] public decimal? MobileMarginBottom { get; set; }
        [Parameter] public decimal? TabletMarginBottom { get; set; }
        [Parameter] public decimal? LaptopMarginBottom { get; set; }
        [Parameter] public decimal? DesktopMarginBottom { get; set; }
        [Parameter] public decimal? ScreenMarginBottom { get; set; }

        [Parameter] public decimal? MarginLeft { get; set; }
        [Parameter] public decimal? MobileMarginLeft { get; set; }
        [Parameter] public decimal? TabletMarginLeft { get; set; }
        [Parameter] public decimal? LaptopMarginLeft { get; set; }
        [Parameter] public decimal? DesktopMarginLeft { get; set; }
        [Parameter] public decimal? ScreenMarginLeft { get; set; }

        [Parameter] public decimal? MarginRight { get; set; }
        [Parameter] public decimal? MobileMarginRight { get; set; }
        [Parameter] public decimal? TabletMarginRight { get; set; }
        [Parameter] public decimal? LaptopMarginRight { get; set; }
        [Parameter] public decimal? DesktopMarginRight { get; set; }
        [Parameter] public decimal? ScreenMarginRight { get; set; }

        [Parameter] public decimal? MarginStart { get; set; }
        [Parameter] public decimal? MobileMarginStart { get; set; }
        [Parameter] public decimal? TabletMarginStart { get; set; }
        [Parameter] public decimal? LaptopMarginStart { get; set; }
        [Parameter] public decimal? DesktopMarginStart { get; set; }
        [Parameter] public decimal? ScreenMarginStart { get; set; }

        [Parameter] public decimal? MarginEnd { get; set; }
        [Parameter] public decimal? MobileMarginEnd { get; set; }
        [Parameter] public decimal? TabletMarginEnd { get; set; }
        [Parameter] public decimal? LaptopMarginEnd { get; set; }
        [Parameter] public decimal? DesktopMarginEnd { get; set; }
        [Parameter] public decimal? ScreenMarginEnd { get; set; }

        #endregion

        #region Padding Properties

        protected string paddingCss =>
            new CssClassBuilder()
                .AddClass($"p-{Padding}", Padding.HasValue)
                .AddClass($"mobile:p-{MobilePadding}", MobilePadding.HasValue)
                .AddClass($"tablet:p-{TabletPadding}", TabletPadding.HasValue)
                .AddClass($"laptop:p-{LaptopPadding}", LaptopPadding.HasValue)
                .AddClass($"desktop:p-{DesktopPadding}", DesktopPadding.HasValue)
                .AddClass($"screen:p-{ScreenPadding}", ScreenPadding.HasValue)
                .AddClass($"pt-{PaddingTop}", PaddingTop.HasValue)
                .AddClass($"mobile:pt-{MobilePaddingTop}", MobilePaddingTop.HasValue)
                .AddClass($"tablet:pt-{TabletPaddingTop}", TabletPaddingTop.HasValue)
                .AddClass($"laptop:pt-{LaptopPaddingTop}", LaptopPaddingTop.HasValue)
                .AddClass($"desktop:pt-{DesktopPaddingTop}", DesktopPaddingTop.HasValue)
                .AddClass($"screen:pt-{ScreenPaddingTop}", ScreenPaddingTop.HasValue)
                .AddClass($"pb-{PaddingBottom}", PaddingBottom.HasValue)
                .AddClass($"mobile:pb-{MobilePaddingBottom}", MobilePaddingBottom.HasValue)
                .AddClass($"tablet:pb-{TabletPaddingBottom}", TabletPaddingBottom.HasValue)
                .AddClass($"laptop:pb-{LaptopPaddingBottom}", LaptopPaddingBottom.HasValue)
                .AddClass($"desktop:pb-{DesktopPaddingBottom}", DesktopPaddingBottom.HasValue)
                .AddClass($"screen:pb-{ScreenPaddingBottom}", ScreenPaddingBottom.HasValue)
                .AddClass($"pl-{PaddingLeft}", PaddingLeft.HasValue)
                .AddClass($"mobile:pl-{MobilePaddingLeft}", MobilePaddingLeft.HasValue)
                .AddClass($"tablet:pl-{TabletPaddingLeft}", TabletPaddingLeft.HasValue)
                .AddClass($"laptop:pl-{LaptopPaddingLeft}", LaptopPaddingLeft.HasValue)
                .AddClass($"desktop:pl-{DesktopPaddingLeft}", DesktopPaddingLeft.HasValue)
                .AddClass($"screen:pl-{ScreenPaddingLeft}", ScreenPaddingLeft.HasValue)
                .AddClass($"pr-{PaddingRight}", PaddingRight.HasValue)
                .AddClass($"mobile:pr-{MobilePaddingRight}", MobilePaddingRight.HasValue)
                .AddClass($"tablet:pr-{TabletPaddingRight}", TabletPaddingRight.HasValue)
                .AddClass($"laptop:pr-{LaptopPaddingRight}", LaptopPaddingRight.HasValue)
                .AddClass($"desktop:pr-{DesktopPaddingRight}", DesktopPaddingRight.HasValue)
                .AddClass($"screen:pr-{ScreenPaddingRight}", ScreenPaddingRight.HasValue)
                .AddClass($"ps-{PaddingStart}", PaddingStart.HasValue)
                .AddClass($"mobile:ps-{MobilePaddingStart}", MobilePaddingStart.HasValue)
                .AddClass($"tablet:ps-{TabletPaddingStart}", TabletPaddingStart.HasValue)
                .AddClass($"laptop:ps-{LaptopPaddingStart}", LaptopPaddingStart.HasValue)
                .AddClass($"desktop:ps-{DesktopPaddingStart}", DesktopPaddingStart.HasValue)
                .AddClass($"screen:ps-{ScreenPaddingStart}", ScreenPaddingStart.HasValue)
                .AddClass($"pe-{PaddingEnd}", PaddingEnd.HasValue)
                .AddClass($"mobile:pe-{MobilePaddingEnd}", MobilePaddingEnd.HasValue)
                .AddClass($"tablet:pe-{TabletPaddingEnd}", TabletPaddingEnd.HasValue)
                .AddClass($"laptop:pe-{LaptopPaddingEnd}", LaptopPaddingEnd.HasValue)
                .AddClass($"desktop:pe-{DesktopPaddingEnd}", DesktopPaddingEnd.HasValue)
                .AddClass($"screen:pe-{ScreenPaddingEnd}", ScreenPaddingEnd.HasValue)
                .Build();


        [Parameter] public decimal? Padding { get; set; }
        [Parameter] public decimal? MobilePadding { get; set; }
        [Parameter] public decimal? TabletPadding { get; set; }
        [Parameter] public decimal? LaptopPadding { get; set; }
        [Parameter] public decimal? DesktopPadding { get; set; }
        [Parameter] public decimal? ScreenPadding { get; set; }


        [Parameter] public decimal? PaddingTop { get; set; }
        [Parameter] public decimal? MobilePaddingTop { get; set; }
        [Parameter] public decimal? TabletPaddingTop { get; set; }
        [Parameter] public decimal? LaptopPaddingTop { get; set; }
        [Parameter] public decimal? DesktopPaddingTop { get; set; }
        [Parameter] public decimal? ScreenPaddingTop { get; set; }

        [Parameter] public decimal? PaddingBottom { get; set; }
        [Parameter] public decimal? MobilePaddingBottom { get; set; }
        [Parameter] public decimal? TabletPaddingBottom { get; set; }
        [Parameter] public decimal? LaptopPaddingBottom { get; set; }
        [Parameter] public decimal? DesktopPaddingBottom { get; set; }
        [Parameter] public decimal? ScreenPaddingBottom { get; set; }

        [Parameter] public decimal? PaddingLeft { get; set; }
        [Parameter] public decimal? MobilePaddingLeft { get; set; }
        [Parameter] public decimal? TabletPaddingLeft { get; set; }
        [Parameter] public decimal? LaptopPaddingLeft { get; set; }
        [Parameter] public decimal? DesktopPaddingLeft { get; set; }
        [Parameter] public decimal? ScreenPaddingLeft { get; set; }

        [Parameter] public decimal? PaddingRight { get; set; }
        [Parameter] public decimal? MobilePaddingRight { get; set; }
        [Parameter] public decimal? TabletPaddingRight { get; set; }
        [Parameter] public decimal? LaptopPaddingRight { get; set; }
        [Parameter] public decimal? DesktopPaddingRight { get; set; }
        [Parameter] public decimal? ScreenPaddingRight { get; set; }

        [Parameter] public decimal? PaddingStart { get; set; }
        [Parameter] public decimal? MobilePaddingStart { get; set; }
        [Parameter] public decimal? TabletPaddingStart { get; set; }
        [Parameter] public decimal? LaptopPaddingStart { get; set; }
        [Parameter] public decimal? DesktopPaddingStart { get; set; }
        [Parameter] public decimal? ScreenPaddingStart { get; set; }

        [Parameter] public decimal? PaddingEnd { get; set; }
        [Parameter] public decimal? MobilePaddingEnd { get; set; }
        [Parameter] public decimal? TabletPaddingEnd { get; set; }
        [Parameter] public decimal? LaptopPaddingEnd { get; set; }
        [Parameter] public decimal? DesktopPaddingEnd { get; set; }
        [Parameter] public decimal? ScreenPaddingEnd { get; set; }

        #endregion

        #region Width and Height Properties

        protected string heightAndWidthCss =>
            new CssClassBuilder()
                .AddClass($"h-{Height}", !string.IsNullOrWhiteSpace(Height))
                .AddClass($"mobile:h-{MobileHeight}", !string.IsNullOrWhiteSpace(MobileHeight))
                .AddClass($"tablet:h-{TabletHeight}", !string.IsNullOrWhiteSpace(TabletHeight))
                .AddClass($"laptop:h-{LaptopHeight}", !string.IsNullOrWhiteSpace(LaptopHeight))
                .AddClass($"desktop:h-{DesktopHeight}", !string.IsNullOrWhiteSpace(DesktopHeight))
                .AddClass($"screen:h-{ScreenHeight}", !string.IsNullOrWhiteSpace(ScreenHeight))
                .AddClass($"w-{Width}", !string.IsNullOrWhiteSpace(Width))
                .AddClass($"mobile:w-{MobileWidth}", !string.IsNullOrWhiteSpace(MobileWidth))
                .AddClass($"tablet:w-{TabletWidth}", !string.IsNullOrWhiteSpace(TabletWidth))
                .AddClass($"laptop:w-{LaptopWidth}", !string.IsNullOrWhiteSpace(LaptopWidth))
                .AddClass($"desktop:w-{DesktopWidth}", !string.IsNullOrWhiteSpace(DesktopWidth))
                .AddClass($"screen:w-{ScreenWidth}", !string.IsNullOrWhiteSpace(ScreenWidth))
                .Build();


        [Parameter] public string? Height { get; set; }
        [Parameter] public string? MobileHeight { get; set; }
        [Parameter] public string? TabletHeight { get; set; }
        [Parameter] public string? LaptopHeight { get; set; }
        [Parameter] public string? DesktopHeight { get; set; }
        [Parameter] public string? ScreenHeight { get; set; }

        [Parameter] public string? Width { get; set; }
        [Parameter] public string? MobileWidth { get; set; }
        [Parameter] public string? TabletWidth { get; set; }
        [Parameter] public string? LaptopWidth { get; set; }
        [Parameter] public string? DesktopWidth { get; set; }
        [Parameter] public string? ScreenWidth { get; set; }

        #endregion

        #region Border Properties

        protected string borderCss =>
            new CssClassBuilder()
                .AddClass($"border-{Border}", Border.HasValue)
                .AddClass($"mobile:border-{MobileBorder}", MobileBorder.HasValue)
                .AddClass($"tablet:border-{TabletBorder}", TabletBorder.HasValue)
                .AddClass($"laptop:border-{LaptopBorder}", LaptopBorder.HasValue)
                .AddClass($"desktop:border-{DesktopBorder}", DesktopBorder.HasValue)
                .AddClass($"screen:border-{ScreenBorder}", ScreenBorder.HasValue)
                .Build();

        [Parameter] public decimal? Border { get; set; }
        [Parameter] public decimal? MobileBorder { get; set; }
        [Parameter] public decimal? TabletBorder { get; set; }
        [Parameter] public decimal? LaptopBorder { get; set; }
        [Parameter] public decimal? DesktopBorder { get; set; }
        [Parameter] public decimal? ScreenBorder { get; set; }

        #endregion

        #region Flex Properties

        protected string flexCss =>
            new CssClassBuilder()
                .AddClass($"flex-grow-1", FlexFill.HasValue && FlexFill.Value)
                .AddClass($"flex-grow-0", FlexFill.HasValue && !FlexFill.Value)
                .AddClass($"mobile:flex-grow-1", MobileFlexFill.HasValue && MobileFlexFill.Value)
                .AddClass($"mobile:flex-grow-0", MobileFlexFill.HasValue && !MobileFlexFill.Value)
                .AddClass($"tablet:flex-grow-1", TabletFlexFill.HasValue && TabletFlexFill.Value)
                .AddClass($"tablet:flex-grow-0", TabletFlexFill.HasValue && !TabletFlexFill.Value)
                .AddClass($"laptop:flex-grow-1", LaptopFlexFill.HasValue && LaptopFlexFill.Value)
                .AddClass($"laptop:flex-grow-0", LaptopFlexFill.HasValue && !LaptopFlexFill.Value)
                .AddClass($"desktop:flex-grow-1", DesktopFlexFill.HasValue && DesktopFlexFill.Value)
                .AddClass($"desktop:flex-grow-0", DesktopFlexFill.HasValue && !DesktopFlexFill.Value)
                .AddClass($"screen:flex-grow-1", ScreenFlexFill.HasValue && ScreenFlexFill.Value)
                .AddClass($"screen:flex-grow-0", ScreenFlexFill.HasValue && !ScreenFlexFill.Value)
                .Build();

        [Parameter] public bool? FlexFill { get; set; }
        [Parameter] public bool? MobileFlexFill { get; set; }
        [Parameter] public bool? TabletFlexFill { get; set; }
        [Parameter] public bool? LaptopFlexFill { get; set; }
        [Parameter] public bool? DesktopFlexFill { get; set; }
        [Parameter] public bool? ScreenFlexFill { get; set; }

        #endregion
        private string GetId()
        {
            _id ??= $"ent-{Guid.NewGuid()}";
            return _id;
        }
    }
}