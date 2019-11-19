using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZL.Poem.Application.Poems;

namespace ZL.Poem.WebApi.Pages
{
    public class IndexModel : PageModel
    {
        private  IPoetAppService _appService;
        public  PagedResultDto<CategoryDto> Categories;

        public IndexModel(IPoetAppService appService)
        {
            _appService = appService;
        }
        public void OnGet()
        {
            Categories=_appService.GetAllCategories();
        }
    }
}