using Abp.Application.Services;
using Abp.Application.Services.Dto;

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
    }
}