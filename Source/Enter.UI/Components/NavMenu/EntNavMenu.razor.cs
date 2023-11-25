using Enter.UI.Cores.Bases;
using Microsoft.AspNetCore.Components;

namespace Enter.UI.Components;

public partial class EntNavMenu : EntComponentBase
{
    private readonly List<EntNavMenuGroup> _groups = new();

    protected string RootCss => CssBuilder.AddCss("ent-nav-menu")
        .Build();

    [Parameter] public RenderFragment ChildContent { get; set; }

    protected override void OnAfterRender(bool firstRender)
    {
        base.OnAfterRender(firstRender);
    }

    public void AddGroup(EntNavMenuGroup group)
    {
        _groups.Add(group);
    }


    public void Toggle(string id)
    {
        foreach (var group in _groups)
            if (group.Id == id)
                group.IsShow = !group.IsShow;
            else
                group.IsShow = false;
        StateHasChanged();
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();
        _groups.Clear();
    }

    public override void Dispose()
    {
    }
}