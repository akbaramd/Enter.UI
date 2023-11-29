using Enter.Ui.Bases;
using Enter.Ui.Core;
using Enter.Ui.Cores.Core;
using Microsoft.AspNetCore.Components;

// ReSharper disable once CheckNamespace
namespace Enter.Ui.Components;

public partial class EntNavMenu : EntBaseComponent
{   public override string ComponentName => this.GetType().Name;
    private readonly List<EntNavMenuGroup> _groups = new();

    protected override void BuildClasses(ClassBuilder builder)
    {
        builder.AddClass("ent-nav-menu");
        base.BuildClasses(builder);
    }

    public string ActiveItemId { get; set; } = string.Empty;

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

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);
    }
}