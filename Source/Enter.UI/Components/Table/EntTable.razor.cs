using Enter.Ui.Cores.Bases;
using Microsoft.AspNetCore.Components;

// ReSharper disable once CheckNamespace
namespace Enter.Ui.Components;

public partial class EntTable<T> : EntComponentBase
{
    private int _currentPage = 1;

    protected string RootCss => CssBuilder.AddCss("ent-table")
        .Build();

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


    public override void Dispose()
    {
    }
}