using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZL.Poem.Application.Poems;

namespace ZL.Poem.WebApi.Pages
{
    public class SearchPoetModel : PageModel
    {
        /// <summary>
        /// 服务
        /// </summary>
        private  readonly  IPoetAppService _appService;

        /// <summary>
        /// 查询结果
        /// </summary>
        public PagedResultDto<PoetDto> _PoetResult;

        public  string CurrentFilter {get;set;}


        public  int PageSize{get;set;}

        public int CurrentPage { get; set; }
        public SearchPoetModel(IPoetAppService appService)
        {
            _appService = appService;
             PageSize = 6;
            CurrentPage = 0;
            CurrentFilter = "1";
        }

        public void OnGet(string SearchString,int? pageIndex)
        {
             if (pageIndex.HasValue && pageIndex.Value>0)
            {
                CurrentPage = pageIndex.Value;
            }

             if (!string.IsNullOrEmpty(SearchString))
             {
                  CurrentFilter = SearchString;
             }  
            var req = new SearchPoetDto
            {
                Keyword = CurrentFilter,
                SkipCount = CurrentPage * PageSize,
                MaxResultCount = PageSize
            };
            _PoetResult = _appService.SearchPoets(req);
        }
    }
}