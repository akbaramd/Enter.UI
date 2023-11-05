using Enter.UI.Core;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enter.UI.Abstractions.Core.Bases;
using Microsoft.JSInterop;

namespace Enter.UI.Components
{
    public partial class EntTable<T> : EntComponentBase
    {
        protected string RootCss => CssClassBuilder.AddClass("ent-table")
            .Build();

        
        
        private int _currentPage = 1;
        private int _totalPage => (int) Math.Ceiling(decimal.Parse(Total.ToString()) / decimal.Parse(Take.ToString()));


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
            throw new NotImplementedException();
        }
    }   
}