using Enter.Ui.Bases;
using Enter.Ui.Core;
using Enter.Ui.Cores.Core;
using Microsoft.AspNetCore.Components;

// ReSharper disable once CheckNamespace
namespace Enter.Ui.Components;

public partial class EntTabPanel : EntBaseComponent
{
    protected override void BuildClasses(ClassBuilder builder)
    {
        builder.AddClass("ent-tab-panel")
            .AddClass("active", Parent.IsActiveTab(Id));
        base.BuildClasses(builder);
    }

    [Parameter] public string Id { get; set; }

    [CascadingParameter] public EntTab? Parent { get; set; }


    [Parameter] public string Title { get; set; }

    [Parameter] public object Icon { get; set; }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);
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