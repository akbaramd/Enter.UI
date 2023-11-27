using Enter.Ui.Bases;
using Enter.Ui.Core;
using Microsoft.AspNetCore.Components;

// ReSharper disable once CheckNamespace
namespace Enter.Ui.Components;

public partial class EntTable<T> : EntComponentComponent
{
    private int _currentPage = 1;

    protected override void BuildClasses(ClassBuilder builder)
    {
        builder.AddClass("ent-table");
        base.BuildClasses(builder);
    }

    private int _totalPage => (int)Math.Ceiling(decimal.Parse(Total.ToString()) / decimal.Parse(Take.ToString()));


    [Parameter] public RenderFragment? HeaderTemplate { get; set; }
    [Parameter] public RenderFragment<T>? RowTemplate { get; set; }
    [Parameter] public List<T>? DataSources { get; set; }

    [Parameter] public int Total { get; set; }
    [Parameter] public int Take { get; set; }
    [Parameter] public EventCallback<int> OnPaginationChange { get; set; }


    public async Task PaginationChangedCallback(int page)
    {
        _currentPage = page;
        await OnPaginationChange.InvokeAsync(_currentPage);
    }


    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);
    }
}