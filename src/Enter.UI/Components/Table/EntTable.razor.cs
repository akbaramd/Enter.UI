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

        private int? _currentCount => DataSources?.Count;
        
        private int _currentPage = 1;
        private int _totalPage => (int) Math.Ceiling(decimal.Parse(Total.ToString()) / decimal.Parse(Take.ToString()));


        private bool showLastPaginate = true;
        private bool showNextPaginate = true;
        
        [Parameter] public RenderFragment? HeaderTemplate { get; set; }
        [Parameter] public RenderFragment<T>? RowTemplate { get; set; }
        [Parameter] public List<T>? DataSources { get; set; }
        
        [Parameter] public int Total { get; set; }
        [Parameter] public int Take { get; set; }
        
        
        [Parameter] public EventCallback<int> OnPaginationChange { get; set; }


        protected override async Task OnInitializedAsync()
        {
            DoLogic();
            await base.OnInitializedAsync();
        }

        public async Task NextPage()
        {
            _currentPage++;
            DoLogic();
            await OnPaginationChange.InvokeAsync(_currentPage);
        }
        
        public async Task LastPage()
        {
            _currentPage--;
            DoLogic();
            await OnPaginationChange.InvokeAsync(_currentPage);
        }

        
        public void DoLogic()
        {
            Console.WriteLine(_currentPage);
            showLastPaginate = _currentPage != 1;
            showNextPaginate = _currentPage != _totalPage;
            StateHasChanged();
        }
        
    }   
}