using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using AutoMapper;
using ZL.Poem.Core.Poems;

namespace ZL.Poem.Application.Poems
{
    public class PoemAppService:ApplicationService,IPoetAppService
    {
        private  readonly  IRepository<Poet>  _poetRepository;

        public PoemAppService(IRepository<Poet> poetRepository)
        {
            _poetRepository = poetRepository;
        }


        public PagedResultDto<PoetDto> GetPagedPoets(PagedResultRequestDto dto)
        {
            var count=_poetRepository.Count();
            var list=_poetRepository.GetAll().OrderBy(o => o.Id).PageBy(dto).ToList();
            return new PagedResultDto<PoetDto>()
            {
                //新版本 AutoMapper直接注入使用  
                Items = ObjectMapper.Map<List<PoetDto>>(list),
                TotalCount = count,
            };
        }
    }
}