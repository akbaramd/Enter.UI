using Enter.Ui.Cores.Bases;
using Microsoft.AspNetCore.Components;

// ReSharper disable once CheckNamespace
namespace Enter.Ui.Components;

public partial class EntTabPanel : EntComponentBase
{
    protected string RootCss => CssBuilder
        .AddCss("ent-tab-panel")
        .AddCss("active", Parent.IsActiveTab(Id))
        .Build();


    [Parameter] public string Id { get; set; }

    [CascadingParameter] public EntTab? Parent { get; set; }

    [Parameter] public RenderFragment ChildContent { get; set; }

    [Parameter] public string Title { get; set; }

    [Parameter] public object Icon { get; set; }

    public override void Dispose()
    {
    }

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        if (Parent != null)
        {
            if (string.IsNullOrWhiteSpace(Id)) Id = Guid.NewGuid().ToString();
            await Parent.AddTabAsync(this);
        }
    }
}