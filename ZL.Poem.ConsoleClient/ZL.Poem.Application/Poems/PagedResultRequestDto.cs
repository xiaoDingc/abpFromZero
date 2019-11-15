using Abp.Application.Services.Dto;

namespace ZL.Poem.Application.Poems
{
    public class PagedResultRequestDto : IPagedResultRequest
    {
        public int SkipCount { get; set ;}
        public int MaxResultCount { get; set ;}
    }
}