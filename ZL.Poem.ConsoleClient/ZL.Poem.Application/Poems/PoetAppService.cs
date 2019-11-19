using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Security.Cryptography.X509Certificates;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using AutoMapper;
using ZL.Poem.Core.Poems;

namespace ZL.Poem.Application.Poems
{
    ///使用swagger生成注释的时候 要在application中生成而不是跑到api中去生成
    public class PoetAppService : ApplicationService, IPoetAppService
    {
        private readonly IRepository<Poet> _poetRepository;

        private  readonly  IRepository<Category> _categoryRepository;

        private readonly IRepository<Core.Poems.Poem> _poemRepository;

        /// <summary>
        /// PoetApp服务
        /// </summary>
        /// <param name="poetRepository"></param>
        /// <param name="poemRepository"></param>
        public PoetAppService(IRepository<Poet> poetRepository, IRepository<Core.Poems.Poem> poemRepository, IRepository<Category> categoryRepository)
        {
            _poetRepository = poetRepository;
            _poemRepository = poemRepository;
            _categoryRepository = categoryRepository;
        }


        /// <summary>
        /// 获取分页
        /// </summary>
        /// <param name="dto">111</param>
        /// <returns></returns>
        public PagedResultDto<PoetDto> GetPagedPoets(PagedResultRequestDto dto)
        {
            var count = _poetRepository.Count();
            var list = _poetRepository.GetAll().OrderBy(o => o.Id).PageBy(dto).ToList();
            return new PagedResultDto<PoetDto>()
            {
                //新版本 AutoMapper直接注入使用  
                Items = ObjectMapper.Map<List<PoetDto>>(list),
                TotalCount = count,
            };
        }

        /// <summary>
        /// 查询poem
        /// </summary>
        /// <param name="dto">222</param>
        /// <returns></returns>
        public PagedResultDto<PoemDto> SearchPoems(SearchPoemDto dto)
        {
            var res = _poemRepository.GetAllIncluding(c => c.Author);

            res = res.WhereIf(!string.IsNullOrEmpty(dto.Keyword), o => o.Title.Contains(dto.Keyword))
                 .WhereIf(!string.IsNullOrEmpty(dto.AuthorName), o => o.Author.Name == dto.AuthorName);

            if (dto.Categories != null)
            {
                foreach (var category in dto.Categories)
                {
                    res = res.Where(o => o.PoemCategories.Any(q => q.Category.CategoryName == category));
                }
            }

            var count = res.Count();
            var lst = res.OrderBy(o => o.Id).PageBy(dto).ToList();

            return new PagedResultDto<PoemDto>
            {
                TotalCount = count,
                //  Items = lst.MapTo<List<PoemDto>>(),
                Items = ObjectMapper.Map<List<PoemDto>>(lst)
            };
        }

        /// <summary>
        /// 按条件查询诗人
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public PagedResultDto<PoetDto> SearchPoets(SearchPoetDto dto)
        {
            var res=_poetRepository.GetAllList().Skip(dto.SkipCount).Take(dto.MaxResultCount)
                .WhereIf(!string.IsNullOrEmpty(dto.Keyword),x=>x.Name.Contains(dto.Keyword))
                .ToList();
            var count=res.Count();

            return new PagedResultDto<PoetDto>()
            {
                Items = ObjectMapper.Map<List<PoetDto>>(res),
                TotalCount = count
            };
        }

        /// <summary>
        /// 获取诗所有仓库
        /// </summary>
        /// <returns></returns>
        public PagedResultDto<CategoryDto> GetAllCategories()
        {
            var count=_categoryRepository.Count();
            var lst=_categoryRepository.GetAllList();

            return new PagedResultDto<CategoryDto>
            {
                TotalCount = count,
                Items = ObjectMapper.Map<List<CategoryDto>>(lst)
            };
        }
    }
}