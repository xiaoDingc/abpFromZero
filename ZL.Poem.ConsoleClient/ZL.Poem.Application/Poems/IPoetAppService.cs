using System.Collections.Generic;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ZL.Poem.Core.Poems;

namespace ZL.Poem.Application.Poems
{
    public interface IPoetAppService:IApplicationService
    {
        /// <summary>
        /// 获取诗人分页接口
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        PagedResultDto<PoetDto> GetPagedPoets(PagedResultRequestDto dto);

        /// <summary>
        /// 按条件查询诗，条件是关键字（模糊查询），作者(精确查询)，分类（属于所有分类）
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        PagedResultDto<PoemDto> SearchPoems(SearchPoemDto dto);

        /// <summary>
        /// 按条件查询诗人
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        PagedResultDto<PoetDto> SearchPoets(SearchPoetDto dto);

        /// <summary>
        /// 获取诗所有仓库
        /// </summary>
        /// <returns></returns>
        PagedResultDto<CategoryDto> GetAllCategories();
    }
}